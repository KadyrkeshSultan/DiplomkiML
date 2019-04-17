using Algorithmia;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AgeDetection
{
    public partial class MainForm : Form
    {
        private OpenFileDialog _openFileDialog;
        private SaveFileDialog _saveFileDialog;
        private string _filePath = "";
        private string _fileName = "";
        private ProgressBarForm _progressForm;
        private readonly BackgroundWorker _bw = new BackgroundWorker();
        private readonly Client _client;
        private Image _resultImage;
        private string[] _testImages = { "https://avatars.mds.yandex.net/get-pdb/805781/0e77a054-59ad-4e3c-9a94-bc87fb3de3c9/s1200", "https://i.ibb.co/myxQY3j/1615-children.jpg" };
        private bool _flagTest = false;
        private List<AgeResult> _ageResults;

        public MainForm()
        {
            InitializeComponent();
            string key = ConfigurationManager.AppSettings["algoKey"];
            _client = new Client(key);
            _ageResults = new List<AgeResult>();

            _openFileDialog = new OpenFileDialog();
            _openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            _openFileDialog.Title = "Выберите изображение";

            _saveFileDialog = new SaveFileDialog();
            _saveFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            _saveFileDialog.Title = "Сохраните файл";

            _bw.DoWork += Processing;
            _bw.RunWorkerCompleted += BwRunWorkerCompleted;

            this.pctBoxStart.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pctBoxStart.BorderStyle = BorderStyle.FixedSingle;
            this.gridListAgeResults.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
        }

        private void btnFileChoose_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            _flagTest = false;
            _filePath = _openFileDialog.FileName;
            _fileName = new FileInfo(_filePath).Name;

            this.pctBoxStart.Image = Image.FromFile(_filePath);
            Logging($"Выбран файл: {_filePath}");
        }

        private void BwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Logging("Обработка изображения завершена");
            if(_ageResults.Count > 0)
            {
                GenTableLayoutPanel();
            }
            _progressForm.Close();
        }

        private void Processing(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            try
            {
                if (_flagTest)
                {
                    _ageResults.Clear();
                    _ageResults.AddRange(GetAlgoResult(_filePath));
                    return;
                }
                string dirPath = "data://.my/images/";
                var dir = _client.dir(dirPath);
                string fileName = _fileName;
                if (!dir.exists())
                {
                    dir.create();
                }

                var destination = dir.file(fileName);
                if (!destination.exists())
                {
                    var dataFile = destination.put(File.OpenRead(_filePath));
                }

                _ageResults.Clear();
                _ageResults.AddRange(GetAlgoResult(dirPath + fileName));
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private AgeResult[] GetAlgoResult(string filePath)
        {
            var algo = _client.algo("deeplearning/AgeClassification/2.0.0");
            var input = "{ " + "\"image\" :\"" + filePath + "\"}";

            algo.setOptions(300);

            var response = algo.pipeJson<object>(input);
            JObject res = (JObject)response.result;
            var result = ((JArray)res["results"]);

            return result.Select(f => f.ToObject<AgeResult>()).ToArray();
        }

        private void btnAlgoStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                MessageBox.Show("Выберите файл!", "Выбор файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!_bw.IsBusy)
            {
                Logging("Начат процесс обработки изображения");
                _progressForm = new ProgressBarForm();
                _progressForm.Show(this);
                _bw.RunWorkerAsync();
                Logging("Обработка изображения...");
            }
        }

        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        
        private void lblTestImage1_Click(object sender, EventArgs e)
        {
            _filePath = _testImages[0];
            this.pctBoxStart.Load(_filePath);
            _flagTest = true;
            Logging("Выбрано изображение 1");
        }

        private void lblTestImage2_Click(object sender, EventArgs e)
        {
            _filePath = _testImages[1];
            this.pctBoxStart.Load(_filePath);
            _flagTest = true;
            Logging("Выбрано изображение 2");
        }

        private void Logging(string message)
        {
            this.txtConsoleOutput.AppendText($"[{DateTime.Now.ToString()}]: {message}\r\n");
        }

        private void GenTableLayoutPanel()
        {
            this.gridListAgeResults.Controls.Clear();
            var gridList = new TableLayoutPanel();
            gridList.ColumnCount = 1;
            gridList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            gridList.Dock = DockStyle.Fill;
            gridList.Name = "gridList";
            gridList.Location = new System.Drawing.Point(0, 0);
            gridList.RowCount = _ageResults.Count + 1;

            for(int i = 0; i< gridList.RowCount - 1; i++)
            {
                gridList.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
                gridList.Controls.Add(GetGridAgeResult(string.Empty,_ageResults[i]), 0, i);
            }

            gridList.RowStyles.Add(new RowStyle(SizeType.AutoSize, 80F));
            gridList.Controls.Add(new Label() { Dock = DockStyle.Fill }, 0, gridList.RowCount);

            this.gridListAgeResults.Controls.Add(gridList, 0, 0);
        }

        private TableLayoutPanel GetGridAgeResult(string imgPath, AgeResult ageResult)
        {
            var grid = new TableLayoutPanel();

            grid.ColumnCount = 2;
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            grid.Dock = DockStyle.Fill;
            grid.Name = "gridGen";
            grid.RowCount = 2;
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;

            var pct = new PictureBox();
            pct.SizeMode = PictureBoxSizeMode.StretchImage;
            pct.Dock = DockStyle.Fill;
            pct.Load("https://i.ibb.co/mNnH91W/240px-Vorschriftszeichen-1-svg.png");

            var label1 = new Label() {Dock= DockStyle.Fill };
            var label2 = new Label() { Dock = DockStyle.Fill };
            var age = ageResult.age.OrderByDescending(f => f.confidence).FirstOrDefault();
            label1.Text = $"Диапазон Возраста: {age.ageRange.min}-{age.ageRange.max}.";
            label2.Text = $"Точность: {age.confidence}.";
            grid.Controls.Add(label1, 1, 0);
            grid.Controls.Add(label2, 1, 1);
            grid.Controls.Add(pct, 0, 0);
            grid.SetRowSpan(pct, 2);

            return grid;
        }
    }
}

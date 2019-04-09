using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Algorithmia;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Colorize
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
        private string[] _testImages = { "https://photos.gurushots.com/unsafe/0x500/4b4aade50f485120cd49672ff573f93a/3_a84d3d8b7f7e2639c3cd4aca5fe59b19.jpg", "https://avatars.mds.yandex.net/get-pdb/998741/22b0ebf3-44fe-45d4-8472-a7389d105905/s1200?webp=false" };
        private bool _flagTest = false;

        public MainForm()
        {
            InitializeComponent();
            string key = ConfigurationManager.AppSettings["algoKey"];
            _client = new Client(key);

            _openFileDialog = new OpenFileDialog();
            _openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            _openFileDialog.Title = "Выберите изображение";

            _saveFileDialog = new SaveFileDialog();
            _saveFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            _saveFileDialog.Title = "Сохраните файл";

            _bw.DoWork += Processing;
            _bw.RunWorkerCompleted += BwRunWorkerCompleted;

            this.pctBoxStart.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pctBoxEnd.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnFileChoose_Click(object sender, EventArgs e)
        {
            _flagTest = false;
            if(_openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            _filePath = _openFileDialog.FileName;
            _fileName = new FileInfo(_filePath).Name;

            this.pctBoxStart.Image = Image.FromFile(_filePath);
        }

        private void BwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _progressForm.Close();
        }

        private void Processing(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            try
            {
                if (_flagTest)
                {
                    using (var imageFile = GetAlgoResult(_filePath))
                    {
                        _resultImage = Image.FromStream(imageFile);
                        this.pctBoxEnd.Image = _resultImage;
                    }
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
                
                using (var imageFile = GetAlgoResult(dirPath + fileName))
                {
                    _resultImage = Image.FromStream(imageFile);
                    this.pctBoxEnd.Image = _resultImage;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private FileStream GetAlgoResult(string filePath)
        {
            var algo = _client.algo("deeplearning/ColorfulImageColorization/1.1.13");
            var input = "{ " + "\"image\" :\"" + filePath + "\"}";

            algo.setOptions(300);

            var response = algo.pipeJson<object>(input);
            JObject res = (JObject)response.result;
            string output = (string)res["output"];
            return _client.file(output).getFile();
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
                _progressForm = new ProgressBarForm();
                _progressForm.Show(this);
                _bw.RunWorkerAsync();
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

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_fileName))
            {
                _saveFileDialog.FileName = _fileName;
            }
            if(_saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            if(_resultImage == null)
            {
                return;
            }

            try
            {
                string fileName = _saveFileDialog.FileName;
                System.IO.File.WriteAllBytes(fileName, ImageToByteArray(_resultImage));
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblTestImage1_Click(object sender, EventArgs e)
        {
            _filePath = _testImages[0];
            this.pctBoxStart.Load(_filePath);
            _flagTest = true;
        }

        private void lblTestImage2_Click(object sender, EventArgs e)
        {
            _filePath = _testImages[1];
            this.pctBoxStart.Load(_filePath);
            _flagTest = true;
        }
    }
}

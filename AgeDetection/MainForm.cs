﻿using Algorithmia;
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
        private string[] _testImages = { "https://i.ibb.co/ssQ15CQ/image.jpg", "https://i.ibb.co/cr2gp4n/1.jpg" };
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
            this.pctBoxEnd.SizeMode = PictureBoxSizeMode.StretchImage;
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
            
            _progressForm.Close();
        }

        private void Processing(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            try
            {
                if (_flagTest)
                {
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

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_fileName))
            {
                _saveFileDialog.FileName = _fileName;
            }
            if (_saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            if (_resultImage == null)
            {
                return;
            }

            try
            {
                string fileName = _saveFileDialog.FileName;
                System.IO.File.WriteAllBytes(fileName, ImageToByteArray(_resultImage));
                Logging($"Изображение сохранено по пути: {fileName}");
            }
            catch (Exception err)
            {
                Logging($"Ошибка: {err.Message}");
                MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}

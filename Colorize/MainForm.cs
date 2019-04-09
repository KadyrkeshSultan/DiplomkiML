using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Algorithmia;

namespace Colorize
{
    public partial class MainForm : Form
    {
        private OpenFileDialog openFileDialog;
        private string filePath = "";
        private ProgressBarForm progressForm;
        private readonly BackgroundWorker _bw = new BackgroundWorker();
        private readonly Client client;


        public MainForm()
        {
            InitializeComponent();
            client = new Client("");
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog.Title = "Выберите изображение";

            _bw.DoWork += Processing;
            _bw.RunWorkerCompleted += BwRunWorkerCompleted;
        }

        private void btnFileChoose_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            filePath = openFileDialog.FileName;
            this.pctBoxStart.Image = Image.FromFile(filePath);
            this.pctBoxStart.SizeMode = PictureBoxSizeMode.StretchImage;
            progressForm = new ProgressBarForm();
            progressForm.Show();
            _bw.RunWorkerAsync();
        }

        private void BwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressForm.Close();
        }

        private void Processing(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            Thread.Sleep(4000);
        }
    }
}

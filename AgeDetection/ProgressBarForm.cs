using System.Windows.Forms;

namespace AgeDetection
{
    public partial class ProgressBarForm : Form
    {
        public ProgressBarForm()
        {
            InitializeComponent();
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}

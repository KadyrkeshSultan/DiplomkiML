namespace AgeDetection
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeaderText = new System.Windows.Forms.Label();
            this.txtConsoleOutput = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTestImage2 = new System.Windows.Forms.Label();
            this.lblTestImage1 = new System.Windows.Forms.Label();
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.gridAlgorithm = new System.Windows.Forms.TableLayoutPanel();
            this.lblAlgoDesc = new System.Windows.Forms.Label();
            this.btnFileChoose = new System.Windows.Forms.Button();
            this.btnAlgoStart = new System.Windows.Forms.Button();
            this.pctBoxStart = new System.Windows.Forms.PictureBox();
            this.gridListAgeResults = new System.Windows.Forms.TableLayoutPanel();
            this.gridMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gridAlgorithm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxStart)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMain
            // 
            this.gridMain.ColumnCount = 2;
            this.gridMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.gridMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.gridMain.Controls.Add(this.lblHeaderText, 0, 0);
            this.gridMain.Controls.Add(this.txtConsoleOutput, 1, 2);
            this.gridMain.Controls.Add(this.panel1, 0, 1);
            this.gridMain.Controls.Add(this.gridAlgorithm, 1, 1);
            this.gridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMain.Location = new System.Drawing.Point(0, 0);
            this.gridMain.Name = "gridMain";
            this.gridMain.RowCount = 4;
            this.gridMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.gridMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.gridMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.gridMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.gridMain.Size = new System.Drawing.Size(800, 450);
            this.gridMain.TabIndex = 0;
            // 
            // lblHeaderText
            // 
            this.lblHeaderText.AutoSize = true;
            this.lblHeaderText.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridMain.SetColumnSpan(this.lblHeaderText, 2);
            this.lblHeaderText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHeaderText.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHeaderText.Location = new System.Drawing.Point(3, 0);
            this.lblHeaderText.Name = "lblHeaderText";
            this.lblHeaderText.Size = new System.Drawing.Size(794, 80);
            this.lblHeaderText.TabIndex = 0;
            this.lblHeaderText.Text = "Классификация возрастного диапазона по фотографии";
            this.lblHeaderText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtConsoleOutput
            // 
            this.txtConsoleOutput.BackColor = System.Drawing.Color.LightGray;
            this.txtConsoleOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsoleOutput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtConsoleOutput.Location = new System.Drawing.Point(123, 375);
            this.txtConsoleOutput.Multiline = true;
            this.txtConsoleOutput.Name = "txtConsoleOutput";
            this.txtConsoleOutput.Size = new System.Drawing.Size(674, 71);
            this.txtConsoleOutput.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTestImage2);
            this.panel1.Controls.Add(this.lblTestImage1);
            this.panel1.Controls.Add(this.lblAlgorithm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(114, 286);
            this.panel1.TabIndex = 3;
            // 
            // lblTestImage2
            // 
            this.lblTestImage2.AutoSize = true;
            this.lblTestImage2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTestImage2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestImage2.Location = new System.Drawing.Point(9, 43);
            this.lblTestImage2.Name = "lblTestImage2";
            this.lblTestImage2.Size = new System.Drawing.Size(103, 17);
            this.lblTestImage2.TabIndex = 4;
            this.lblTestImage2.Text = "Изображение 2";
            this.lblTestImage2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTestImage2.Click += new System.EventHandler(this.lblTestImage2_Click);
            // 
            // lblTestImage1
            // 
            this.lblTestImage1.AutoSize = true;
            this.lblTestImage1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTestImage1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestImage1.Location = new System.Drawing.Point(9, 23);
            this.lblTestImage1.Name = "lblTestImage1";
            this.lblTestImage1.Size = new System.Drawing.Size(103, 17);
            this.lblTestImage1.TabIndex = 3;
            this.lblTestImage1.Text = "Изображение 1";
            this.lblTestImage1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTestImage1.Click += new System.EventHandler(this.lblTestImage1_Click);
            // 
            // lblAlgorithm
            // 
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAlgorithm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAlgorithm.Location = new System.Drawing.Point(0, 0);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(173, 21);
            this.lblAlgorithm.TabIndex = 2;
            this.lblAlgorithm.Text = "Примеры фотографий:";
            // 
            // gridAlgorithm
            // 
            this.gridAlgorithm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAlgorithm.BackColor = System.Drawing.Color.White;
            this.gridAlgorithm.ColumnCount = 3;
            this.gridAlgorithm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.gridAlgorithm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.gridAlgorithm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.gridAlgorithm.Controls.Add(this.lblAlgoDesc, 0, 0);
            this.gridAlgorithm.Controls.Add(this.btnFileChoose, 0, 1);
            this.gridAlgorithm.Controls.Add(this.btnAlgoStart, 1, 1);
            this.gridAlgorithm.Controls.Add(this.pctBoxStart, 0, 2);
            this.gridAlgorithm.Controls.Add(this.gridListAgeResults, 2, 2);
            this.gridAlgorithm.Location = new System.Drawing.Point(123, 83);
            this.gridAlgorithm.Name = "gridAlgorithm";
            this.gridAlgorithm.RowCount = 3;
            this.gridAlgorithm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.gridAlgorithm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.gridAlgorithm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.gridAlgorithm.Size = new System.Drawing.Size(674, 286);
            this.gridAlgorithm.TabIndex = 4;
            // 
            // lblAlgoDesc
            // 
            this.lblAlgoDesc.AutoSize = true;
            this.gridAlgorithm.SetColumnSpan(this.lblAlgoDesc, 3);
            this.lblAlgoDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlgoDesc.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAlgoDesc.Location = new System.Drawing.Point(3, 0);
            this.lblAlgoDesc.Name = "lblAlgoDesc";
            this.lblAlgoDesc.Size = new System.Drawing.Size(668, 40);
            this.lblAlgoDesc.TabIndex = 0;
            this.lblAlgoDesc.Text = "Выберите изображение и нажмите \"Обработать\". Чем больше изображение, тем дольше о" +
    "бработка изображения.";
            // 
            // btnFileChoose
            // 
            this.btnFileChoose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFileChoose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFileChoose.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFileChoose.ForeColor = System.Drawing.Color.Black;
            this.btnFileChoose.Location = new System.Drawing.Point(52, 43);
            this.btnFileChoose.Name = "btnFileChoose";
            this.btnFileChoose.Size = new System.Drawing.Size(179, 34);
            this.btnFileChoose.TabIndex = 1;
            this.btnFileChoose.Text = "Выбрать изображение";
            this.btnFileChoose.UseVisualStyleBackColor = false;
            this.btnFileChoose.Click += new System.EventHandler(this.btnFileChoose_Click);
            // 
            // btnAlgoStart
            // 
            this.btnAlgoStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlgoStart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAlgoStart.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAlgoStart.ForeColor = System.Drawing.Color.Black;
            this.btnAlgoStart.Location = new System.Drawing.Point(286, 43);
            this.btnAlgoStart.Name = "btnAlgoStart";
            this.btnAlgoStart.Size = new System.Drawing.Size(88, 34);
            this.btnAlgoStart.TabIndex = 2;
            this.btnAlgoStart.Text = "Обработать";
            this.btnAlgoStart.UseVisualStyleBackColor = false;
            this.btnAlgoStart.Click += new System.EventHandler(this.btnAlgoStart_Click);
            // 
            // pctBoxStart
            // 
            this.pctBoxStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctBoxStart.Location = new System.Drawing.Point(3, 83);
            this.pctBoxStart.Name = "pctBoxStart";
            this.pctBoxStart.Size = new System.Drawing.Size(277, 200);
            this.pctBoxStart.TabIndex = 3;
            this.pctBoxStart.TabStop = false;
            // 
            // gridListAgeResults
            // 
            this.gridListAgeResults.ColumnCount = 1;
            this.gridListAgeResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gridListAgeResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridListAgeResults.Location = new System.Drawing.Point(380, 83);
            this.gridListAgeResults.Name = "gridListAgeResults";
            this.gridListAgeResults.RowCount = 1;
            this.gridListAgeResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gridListAgeResults.Size = new System.Drawing.Size(291, 200);
            this.gridListAgeResults.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridMain);
            this.Name = "MainForm";
            this.Text = "Классификация возрастного диапазона по фотографии человека";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gridMain.ResumeLayout(false);
            this.gridMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gridAlgorithm.ResumeLayout(false);
            this.gridAlgorithm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxStart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel gridMain;
        private System.Windows.Forms.Label lblHeaderText;
        private System.Windows.Forms.TextBox txtConsoleOutput;
        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTestImage1;
        private System.Windows.Forms.TableLayoutPanel gridAlgorithm;
        private System.Windows.Forms.Label lblAlgoDesc;
        private System.Windows.Forms.Button btnFileChoose;
        private System.Windows.Forms.Button btnAlgoStart;
        private System.Windows.Forms.PictureBox pctBoxStart;
        private System.Windows.Forms.Label lblTestImage2;
        private System.Windows.Forms.TableLayoutPanel gridListAgeResults;
    }
}


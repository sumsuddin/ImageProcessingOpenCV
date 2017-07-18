namespace ImageProcessingOpenCV
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
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.btImageProcess = new System.Windows.Forms.Button();
            this.btLoad = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMain.Location = new System.Drawing.Point(12, 12);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(302, 302);
            this.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            // 
            // btImageProcess
            // 
            this.btImageProcess.Location = new System.Drawing.Point(524, 291);
            this.btImageProcess.Name = "btImageProcess";
            this.btImageProcess.Size = new System.Drawing.Size(75, 23);
            this.btImageProcess.TabIndex = 1;
            this.btImageProcess.Text = "Process";
            this.btImageProcess.UseVisualStyleBackColor = true;
            this.btImageProcess.Click += new System.EventHandler(this.btImageProcess_Click);
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(523, 13);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(75, 23);
            this.btLoad.TabIndex = 2;
            this.btLoad.Text = "Load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(321, 15);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(196, 20);
            this.tbPath.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 326);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.btLoad);
            this.Controls.Add(this.btImageProcess);
            this.Controls.Add(this.pbMain);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Button btImageProcess;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.TextBox tbPath;
    }
}
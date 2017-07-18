using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessingOpenCV.InterfacingNative;

namespace ImageProcessingOpenCV
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            string imagePath = tbPath.Text;

            Image image = Image.FromFile(imagePath);
            pbMain.Image = image;
        }

        private void btImageProcess_Click(object sender, EventArgs e)
        {
            Image oldImage = pbMain.Image;
            NativeCommunication nativeCommunicator = new NativeCommunication();
            pbMain.Image = nativeCommunicator.ConvertImage(oldImage);
            pbMain.Invalidate();
            oldImage.Dispose();
        }
    }
}

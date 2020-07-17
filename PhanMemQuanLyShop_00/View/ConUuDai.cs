using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PhanMemQuanLyShop_00.View
{
    public partial class ConUuDai : DevExpress.XtraEditors.XtraForm
    {
        public ConUuDai()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = OpenFileDialog1.Filter = "JPG files (*.jpg)|*.jpg|All files (*.*)|*.*";
            OpenFileDialog1.FilterIndex = 1;
            OpenFileDialog1.RestoreDirectory = true;
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = OpenFileDialog1.FileName;
                txtLinkAnh.Text = OpenFileDialog1.FileName;
            }
        }
    }
}
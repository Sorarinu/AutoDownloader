using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDownloader
{
    public partial class frmProgress : Form
    {
        public frmProgress(string Max)
        {
            InitializeComponent();

            progressBar1.Maximum = 100; //ProgressBarの最大値を100に設定

            lblMax.Text = Max;
        }
    }
}

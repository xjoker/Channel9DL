using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Channel9DL
{
    public partial class MainForm : Form
    {

        GetVideoAndSubtitle gva = new GetVideoAndSubtitle();
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList al = gva.GetVideoList(textBox1.Text.ToString());
        }
    }
}

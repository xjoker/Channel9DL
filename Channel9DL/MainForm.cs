using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Channel9DL
{
    public partial class MainForm : Form
    {


        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Thread th = new Thread(adad);
            th.IsBackground = true;
            th.Start();
        }
        private void adad()
        {
            run.gogo(textBox1.Text);
        }

        //*********************************************

        public void SettbxVideoDownList(string text)
        {
            tbxVideoDownList.Text = text;
        }

        public void SetlabVideoProgress(string text)
        {
           
            labVideoProgress.Text = text;
        }


        //*********************************************






        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            tbxVideoDownList.Text = "";

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //回车键事件
            if (e.KeyCode == Keys.Enter)
            {
                this.button1_Click(sender, e);
            }
        }
    }
}

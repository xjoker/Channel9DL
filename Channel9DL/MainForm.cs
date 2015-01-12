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
        SubtitleMake sm = new SubtitleMake();
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //ArrayList al = gva.GetVideoList(textBox1.Text.ToString());
            videoLib.video vd = gva.GetVideoList(textBox1.Text.ToString());


            List<string> test1 = new List<string>(vd.vAndd.Keys);
            List<string> test2 = new List<string>(vd.vAndd.Values);

            int ccc = vd.url.Count;
            for (int i = 0; i < ccc;i++ )
            {
                Console.WriteLine(test1[i]);
                Console.WriteLine(test2[i]);
                Console.WriteLine(vd.url[i]);
            }


                foreach (var a in vd.url)
                {

                    //string subtitle = gva.GetSubtitleAddress(a.ToString());
                    //sm.Subtitle(subtitle, vd.vAndd.Keys.ToString());

                }
        }
    }
}

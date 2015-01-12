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


        GetVideoAndSubtitle gva = new GetVideoAndSubtitle();

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取视频地址
            videoLib.video vd = gva.GetVideoList(textBox1.Text.ToString());

            //计数，记录总共的视频数量
            int ccc = vd.url.Count;

            //判断是否有数据传回
            if(ccc>0)
            {
                //显示视频总数
                labVideoCount.Text = ccc.ToString();

                //视频名称（正规名称）
                List<string> videoName = new List<string>(vd.vAndd.Keys);

                //视频下载地址
                List<string> videoAddress = new List<string>(vd.vAndd.Values);


                Thread.Sleep(500);

                for (int i = 0; i < ccc; i++)
                {
                    //进度显示
                    labVideoProgress.Text = (i + 1).ToString() + " / " + ccc;

                    //将视频地址丢入textbox
                    //后续做个调用迅雷吧...........
                    tbxVideoDownList.Text += videoAddress[i].ToString() + "\n";

                    //提取视频的名称
                    string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(videoAddress[i]);

                    //传入视频名称和字幕下载地址
                    SubtitleMake.Subtitle(vd.url[i].ToString(), fileNameWithoutExtension);


                }
                //日志下
                tbxLogBox.Text += "字幕下载完成！ \n";
            }
        }

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
            if(e.KeyCode==Keys.Enter)
            {
                this.button1_Click(sender, e);
            }
        }
    }
}

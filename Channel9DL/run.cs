using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Channel9DL
{
    class run
    {

        public System.Windows.Forms.TextBox Box = null;


        public void RefreshTextBox(string msg)
        {
            if (Box == null) return;
            MainForm.SettbxVideoDown dt = new MainForm.SettbxVideoDown(RefreshTextBox);

            if (Box.InvokeRequired)
            {
                Box.Invoke(dt, new object[] { msg });
            }
            else
            {
                Box.Text += msg;
            }
        }

        public void gogo(object obj)
        {
            string url = obj as string;

            GetVideoAndSubtitle gva = new GetVideoAndSubtitle();
            //获取视频地址
            videoLib.video vd = gva.GetVideoList(url);

            //计数，记录总共的视频数量
            int ccc = vd.url.Count;

            //判断是否有数据传回
            if (ccc > 0)
            {
                //显示视频总数

               

                //labVideoCount.Text = ccc.ToString();

                //视频名称（正规名称）
                List<string> videoName = new List<string>(vd.vAndd.Keys);

                //视频下载地址
                List<string> videoAddress = new List<string>(vd.vAndd.Values);

                

                for (int i = 0; i < ccc; i++)
                {
                    //进度显示
                    //labVideoProgress.Text = (i + 1).ToString() + " / " + ccc;
                    //SetlabVideoProgress((i + 1).ToString() + " / " + ccc);
                    


                    //将视频地址丢入textbox
                    //后续做个调用迅雷吧...........
                    //tbxVideoDownList.Text += videoAddress[i].ToString() + "\n";
                   // mf.SettbxVideoDownList(videoAddress[i].ToString() + "\n");
                    RefreshTextBox(videoAddress[i].ToString() + "\n");

                    //提取视频的名称
                    string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(videoAddress[i]);

                    //传入视频名称和字幕下载地址
                    SubtitleMake.Subtitle(vd.url[i].ToString(), fileNameWithoutExtension);


                }
                //日志下
                //tbxLogBox.Text += "字幕下载完成！ \n";
            }
        }
    }
}

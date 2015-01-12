using System;
using System.IO;
using System.Net;
using System.Text;

namespace Channel9DL
{
    public class SubtitleMake
    {
        /// <summary>
        /// 下载字幕并且处理
        /// </summary>
        /// <param name="url">字幕的地址</param>
        /// <param name="name">视频名称</param>
        /// <param name="language">传入要下载的字幕语言种类，默认简中</param>
        public void Subtitle(string url,string name,string language="zh-cn")
        {

            WebClient client = new WebClient();

            try
            {
                System.Collections.Specialized.NameValueCollection VarPar = new System.Collections.Specialized.NameValueCollection();

                //POST参数，这个将返回简体中文的字幕
                VarPar.Add("l", language);

                //获取返回的数据
                byte[] remoteInfo = client.UploadValues(url, "POST", VarPar);

                //解码为string类型
                string sRemoteInfo = System.Text.Encoding.UTF8.GetString(remoteInfo);

                //将所有的","替换为SRT字幕要求的","
                sRemoteInfo = sRemoteInfo.Replace(".", ",");

                //转为流
                byte[] str = Encoding.UTF8.GetBytes(sRemoteInfo);
                MemoryStream stream = new MemoryStream(str);

                //利用StringBuilder做文件的分析存储容器
                StringBuilder sbSRT = new StringBuilder();

                StreamReader sr = new StreamReader(stream);

                //已经读取的行数
                int lineCount = 0;

                //实际的行数(也就是去掉前三行无关的信息)
                int line = 1;

                while (sr.Peek() > 0)
                {
                    lineCount++;
                    if (lineCount > 3)
                    {
                        sbSRT.AppendLine(line++.ToString());//字幕标号

                        //读取3行
                        sbSRT.AppendLine(sr.ReadLine());//时间戳
                        sbSRT.AppendLine(sr.ReadLine());//字幕内容
                        sbSRT.AppendLine(sr.ReadLine());//空行
                    }
                    else
                    {
                        //去掉前三行无关的信息
                        sr.ReadLine();
                    }

                }

                //存储在程序的目录下，和视频文件同名
                string savePath = System.Environment.CurrentDirectory+"\\" + name + ".srt";

                StreamWriter sw = new StreamWriter(savePath, true, System.Text.Encoding.UTF8);
                sw.Write(sbSRT);
                sw.Close();

                Console.WriteLine("字幕下载完毕");
            }
            catch
            {

                System.Windows.Forms.MessageBox.Show("获取字幕失败！可能这个视频没有简体字幕！");
            }
        }

    }
}

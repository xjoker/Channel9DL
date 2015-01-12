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
        public static void Subtitle(string url,string name,string language="zh-cn")
        {
            GetVideoAndSubtitle gvas = new GetVideoAndSubtitle();

            WebClient client = new WebClient();

            try
            {

                //分析字幕地址
                url = gvas.GetSubtitleAddress(url);

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


                //字幕解析
                //字幕开始第一行都是"WEBVTT"开头，但是下面的空行不一定是2行还是3行
                //现在只能读一行判断一行，而且字幕有的是2行或者3行的，并不一定是一行
                //这只能做了个循环判断字幕的内容了...
                //这代码简直糟透了... 但是能用.....
                string readread = null;
                while (sr.Peek() > 0)
                {
                    lineCount++;

                    readread = sr.ReadLine();

                    if (readread != "WEBVTT" && readread != "")
                    {
                        sbSRT.AppendLine(line++.ToString());//字幕标号
                        sbSRT.AppendLine(readread);//字幕内容
                        readread = sr.ReadLine();
                        while(readread!="")
                        {
                            sbSRT.AppendLine(readread);//字幕内容
                            readread = sr.ReadLine();
                        }
                    }
                    sbSRT.AppendLine("");//添加空行

                }

                //存储在程序的目录下，和视频文件同名
                string savePath = System.Environment.CurrentDirectory+"\\" + name + ".srt";

                StreamWriter sw = new StreamWriter(savePath, true, System.Text.Encoding.UTF8);
                sw.Write(sbSRT);
                sw.Close();

                Console.WriteLine("字幕下载完毕");
            }
            catch(Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.ToString());
                System.Windows.Forms.MessageBox.Show("获取字幕失败！\n可能这个视频没有简体字幕，或者程序目录没有写入权限");
            }
        }

    }
}

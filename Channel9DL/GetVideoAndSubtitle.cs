using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml.Linq;
using System.Linq;


namespace Channel9DL
{
    class GetVideoAndSubtitle
    {

        HtmlWeb webClient = new HtmlWeb();

        HtmlDocument videoUrl = null;

        HtmlNodeCollection hrefList = null;//XPath



        /// <summary>
        /// 获取字幕地址
        /// </summary>
        /// <param name="url">视频所在的网页</param>
        /// <returns>返回完整的视频地址，如果没有地址会返回空值</returns>
        public string GetSubtitleAddress(string url)
        {

            //加载需要分析的网页....
            videoUrl = webClient.Load(url);

            //XPath匹配
            hrefList = videoUrl.DocumentNode.SelectNodes(".//a[@data-language='zh-cn']");

            //无结果会为空值
            if (hrefList != null)
            {
                foreach (HtmlNode href in hrefList)
                {
                    HtmlAttribute att = href.Attributes["href"];
                    Console.WriteLine("字幕：");
                    Console.WriteLine(att.Value);
                    return att.Value;
                }

            }

            return null;
        }

        /// <summary>
        /// 获取页面的所有视频链接
        /// 通过读取微软提供的RSS来获得地址
        /// </summary>
        /// <param name="url">课程地址</param>
        /// <returns>返回视频名称、下载地址、视频页面</returns>
        public videoLib.video GetVideoList(string url)
        {
            //分析标题的XPath
            string classList = "/html/head/link[24]";

            videoLib.video vd = new videoLib.video();

            vd.url = new ArrayList();//初始化url数组

            Dictionary<string, string> videoList = new Dictionary<string, string>();

            string rss = null;

           
            try
            {
                //判断URL合法
                videoUrl = webClient.Load(url);

                //XPath匹配
                hrefList = videoUrl.DocumentNode.SelectNodes(classList);


                try
                {
                    //分析主代码块
                    if (hrefList != null)
                    {
                        //搜索出RSS的地址
                        foreach (HtmlNode href in hrefList)
                        {
                            HtmlAttribute att = href.Attributes["href"];

                            Console.WriteLine("RSS：");
                            Console.WriteLine(att.Value);
                            //拼合地址
                            rss = "http://channel9.msdn.com" + att.Value;
                            Console.WriteLine(rss);

                        }

                        WebClient client = new WebClient();

                        //拉取RSS文件
                        byte[] list = client.DownloadData(rss);

                        string aa = Encoding.UTF8.GetString(list);

                        XElement xe = XElement.Parse(aa);


                        //linq查询出视频的名称、下载地址、视频页面地址
                        var a = from x in xe.Descendants("item")
                                select new
                                {
                                    title = x.Element("title").Value,
                                    mp4 = x.Element("enclosure").FirstAttribute.Value,
                                    link = x.Element("link").Value,
                                };

                        foreach (var b in a)
                        {
                            //将视频标题和下载地址存入字典
                            videoList.Add(b.title, b.mp4);
                            //存入自定义的类型中
                            vd.vAndd = videoList;
                            vd.url.Add(b.link);
                        }


                    }

                    return vd;
                }
                catch
                {

                    System.Windows.Forms.MessageBox.Show("页面解析异常，或者输入的地址不正确！");
                    return vd;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("URL不正确！");
                return vd;
            }

            

        }


    }
}

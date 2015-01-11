using HtmlAgilityPack;
using System;
using System.Collections;


namespace Channel9DL
{
    class GetVideoAndSubtitle
    {

        HtmlWeb webClient = new HtmlWeb();

        HtmlDocument videoUrl = null;

        HtmlNodeCollection hrefList = null;//XPath

        public HtmlDocument VideoUrl
        {
            get { return videoUrl; }
            set { videoUrl = value; }
        }

        /// <summary>
        /// 获取视频地址
        /// </summary>
        /// <param name="url">视频所在的网页</param>
        /// <returns>返回完整的视频地址，如果没有地址会返回空值</returns>
        public string GetVideoAddress(string url)
        {
            //加载需要分析的网页....
            videoUrl = webClient.Load(url);

            //XPath匹配
            hrefList = videoUrl.DocumentNode.SelectNodes("//*[@id='video-download']/ul/li[4]/div/a");
            //*[@id="video-download"]/ul/li[4]/div/a
            
            //*[@id="video-download"]/ul  一部分视频是这样的...
            //*[@id="video-download"]/ul 另一部分是这样.....
            // 巨硬你大爷的.....

            //无结果会为空值
            if (hrefList != null)
            {
                foreach (HtmlNode href in hrefList)
                {
                    HtmlAttribute att = href.Attributes["href"];
                    Console.WriteLine("视频地址(High MP4)：");
                    Console.WriteLine(att.Value);
                    return att.Value;
                }

            }

            return null;
        }

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
        /// </summary>
        /// <param name="url">课程地址</param>
        /// <returns>返回列表</returns>
        public ArrayList GetVideoList(string url)
        {
            videoUrl = webClient.Load(url);

            ArrayList videoList = new ArrayList();


            //分析标题的XPath
            string classList = ".//a[@class='title']";

            //XPath匹配
            hrefList = videoUrl.DocumentNode.SelectNodes(classList);

            //得到课程数量
            int count = hrefList.Count;

            if(hrefList!=null)
            {
                foreach (HtmlNode href in hrefList)
                {
                    HtmlAttribute att = href.Attributes["href"];
                    Console.WriteLine("课程详细地址：");
                    Console.WriteLine(url + att.Value);
                    videoList.Add((string)("http://channel9.msdn.com/" + att.Value));

                    Console.WriteLine(GetVideoAddress("http://channel9.msdn.com/" + att.Value));

                }

            }

            return videoList;

        }


    }
}

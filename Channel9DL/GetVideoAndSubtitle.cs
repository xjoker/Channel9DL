using HtmlAgilityPack;
using System;


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


     
    }
}

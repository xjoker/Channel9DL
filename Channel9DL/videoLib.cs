using System.Collections;
using System.Collections.Generic;

namespace Channel9DL
{
    class videoLib
    {
        /// <summary>
        /// 视频类
        /// 用来返回多个值的
        /// 第一个字典型返回的是视频名称和下载地址
        /// 第二个ArrayList用来储存视频页面的URL
        /// </summary>
        public struct video
        {
            public Dictionary<string, string> vAndd;
            public ArrayList url;
        }
    }
}

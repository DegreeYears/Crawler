using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CrawlingDecInfoCMD
{
    class DoIO
    {
        /// <summary>
        /// 保存数据到文件中
        /// 在bin/data下手动新建dec.txt
        /// </summary>
        /// <param name="txt"></param>
        public void WriteTxt(string txt,string url) {
            FileStream fs = new FileStream(url, FileMode.Append);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(txt);
            sr.Close();
            fs.Close();
        }
        /// <summary>
        /// 保存图片到本地
        /// </summary>
        /// <param name="imgUrl"></param>
        public void SaveHttpImg(string imgUrl) {

        }
    }
}

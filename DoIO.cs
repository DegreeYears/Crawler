using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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
        public void WriteTxt(string txt, string url)
        {
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
        public void SaveHttpImg(string imgUrl)
        {
            var fs = new FileStream(imgUrl, FileMode.Open);
            var sr = new StreamReader(fs);
            var nextLine = "";
            var list_dec = new List<string>();
            //按行读取
            while ((nextLine = sr.ReadLine()) != null)
            {
                var list_info = new List<string>();
                var arr_info = nextLine.Split(',');

                list_dec.Add(arr_info[4].Substring(5)); ;
            }
            sr.Close();
            //下载图片，list_dec中为图片地址
            var savePath = @"..\..\..\bin\data\img\";
            var defaultType = ".png";
            foreach (var item in list_dec)
            {
                if (item.ToString().Length <= 33)
                {
                    break;
                }
                var imgName = item.ToString().Substring(33);
                var arrayByte = new byte[1024];

                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http:" + item.ToString());
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
                    request.Timeout = 5000;
                    request.AllowAutoRedirect = false;

                    WebResponse response = request.GetResponse();
                    Stream stream = response.GetResponseStream();
                    var imgLong = response.ContentLength;
                    int l = 0;
                    FileStream fso = new FileStream(savePath + imgName, FileMode.Create);

                    while (l < imgLong)
                    {
                        int i = stream.Read(arrayByte, 0, 1024);
                        fso.Write(arrayByte, 0, i);
                        l += i;
                    }
                    fso.Close();
                    stream.Close();
                    response.Close();
                }
                catch (Exception)
                {

                    Console.WriteLine(imgName); ;
                }
            }
        }

        public List<List<string>> ReadTxt(string url)
        {
            var fs = new FileStream(url, FileMode.Open);
            var sr = new StreamReader(fs);
            var nextLine = "";
            var list_dec = new List<List<string>>();
            //按行读取
            while ((nextLine = sr.ReadLine()) != null)
            {
                var list_info = new List<string>();
                foreach (var arr in nextLine.Split(','))
                {
                    list_info.Add(arr);
                }
                list_dec.Add(list_info);
            }
            sr.Close();
            return list_dec;
        }

        public List<string> ReadTxt2(string url)
        {
            var fs = new FileStream(url, FileMode.Open);
            var sr = new StreamReader(fs);
            var nextLine = "";
            var list_dec = new List<string>();
            //按行读取
            while ((nextLine = sr.ReadLine()) != null)
            {
                list_dec.Add(nextLine.ToString()); 
            }
            sr.Close();
            return list_dec;
        }
    }
}

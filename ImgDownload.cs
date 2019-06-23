using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CrawlingDecInfoCMD
{
    class ImgDownload
    {
        public void SaveImageForWeb()
        {
            var fs = new FileStream(@"..\..\..\bin\data\dec2.txt", FileMode.Open);
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
    }
}

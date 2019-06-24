using HtmlAgilityPack;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

namespace CrawlingDecInfoCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            //insert into database
            var doIO = new DoIO();
            var list_dec = new List<string>();
            list_dec = doIO.ReadTxt2(@"..\..\..\bin\data\dec3.txt");
            var dbHelper = new DBHelper();
            var hstList = new List<Hashtable>();
            foreach (var item in list_dec)
            {
                try
                {
                    var hs = new Hashtable();
                    var list_info = new List<string>();
                    var arr_info = item.Split(',');
                    var arr_decName = arr_info[0].Substring(3).Split(',', '|');
                    hs.Add("DecName_CN", arr_info[0].Substring(3));
                    hs.Add("Wear", arr_info[1].Substring(4));
                    hs.Add("Type", arr_decName[0]);
                    hs.Add("Image", arr_info[4].Substring(38));
                    hs.Add("DecPrice_CSGOID", 1);
                    hstList.Add(hs);
                    Console.WriteLine(list_dec.IndexOf(item));
                }
                catch (Exception e)
                {

                    Console.WriteLine(list_dec.IndexOf(item)+" -> error!");
                }
            }

            dbHelper.InsertData(hstList);

            //在线图片下载
            /*
            DoIO doIO = new DoIO();
            doIO.SaveHttpImg(@"..\..\..\bin\data\dec2.txt");
            */
            
            //数据处理执行程序
            /*
            DataAccess dataAccess = new DataAccess();
            dataAccess.DataAccess_IgxeCsgo();
            */
            //爬虫执行程序
            /*
            var doIO = new DoIO();
            var crawler = new Crawler();//调用爬虫的核心程序
            var crawlingIgxeDec = new CrawlingIgxeDec();

            crawler.OnStart += (s, e) =>
            {
                Console.WriteLine("=====================================");
                Console.WriteLine("爬虫开始抓取地址:" + e.Uri.ToString());
            };
            crawler.OnError += (s, e) =>
            {
                Console.WriteLine("爬虫抓取出错:" + e.Message);
            };
            crawler.OnComplete += (s, e) =>
            {
                crawlingIgxeDec.GetDecInfo(e.PageSource, doIO);
            };
            //爬取igxe饰品信息
            for (int i = 1; i <= 515; i++)
            {
                var uri = "https://www.igxe.cn/csgo/730?is_buying=0&is_stattrak%5B%5D=0&is_stattrak%5B%5D=0&sort=3&ctg_id=0&type_id=0&page_no=" + i + "&page_size=20&rarity_id=0&exterior_id=0&quality_id=0&capsule_id=0&_t=1560502035978";
                //不使用代理
                crawler.Start(new Uri(uri), null).Wait();
                //使用代理
                //var agentIp = "222.189.144.72";
                //var agentIpPort = 9999;
                //crawler.Start(new Uri(uri), new WebProxy(agentIp, agentIpPort)).Wait();
            }*/
        }
    }
}

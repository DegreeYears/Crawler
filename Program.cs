using HtmlAgilityPack;
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.Xml;

namespace CrawlingDecInfoCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.DataAccess_IgxeCsgo();
            //var doIO = new DoIO();
            //var crawler = new Crawler();//调用爬虫的核心程序
            //var crawlingIgxeDec = new CrawlingIgxeDec();

            //crawler.OnStart += (s, e) =>
            //{
            //    Console.WriteLine("=====================================");
            //    Console.WriteLine("爬虫开始抓取地址:" + e.Uri.ToString());
            //};
            //crawler.OnError += (s, e) =>
            //{
            //    Console.WriteLine("爬虫抓取出错:" + e.Message);
            //};
            //crawler.OnComplete += (s, e) =>
            //{
            //    crawlingIgxeDec.GetDecInfo(e.PageSource,doIO);
            //};
            ////爬取igxe饰品信息
            //for (int i = 1; i <= 515; i++)
            //{
            //    var uri = "https://www.igxe.cn/csgo/730?is_buying=0&is_stattrak%5B%5D=0&is_stattrak%5B%5D=0&sort=3&ctg_id=0&type_id=0&page_no=" + i + "&page_size=20&rarity_id=0&exterior_id=0&quality_id=0&capsule_id=0&_t=1560502035978";
            //    //不使用代理
            //    crawler.Start(new Uri(uri), null).Wait();
            //    //使用代理
            //    //var agentIp = "222.189.144.72";
            //    //var agentIpPort = 9999;
            //    //crawler.Start(new Uri(uri), new WebProxy(agentIp, agentIpPort)).Wait();
            //}
        }
    }
}

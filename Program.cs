using System;
using System.Net;
using System.Xml;

namespace CrawlingDecInfoCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = "https://www.igxe.cn/csgo/730?is_buying=0&is_stattrak%5B%5D=0&is_stattrak%5B%5D=0&sort=3&ctg_id=0&type_id=0&page_no=1&page_size=20&rarity_id=0&exterior_id=0&quality_id=0&capsule_id=0&_t=1560502035978";
            //var list = new List<City>();
            var crawler = new Crawler();//调用爬虫的核心程序

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
                //解析html
                //Console.WriteLine(e.PageSource);
                //Console.WriteLine("=====================================");
                //Console.WriteLine("耗时：" + e.Milliseconds);
                //Console.WriteLine("线程：" + e.ThreadId);
                //Console.WriteLine("地址：" + e.Uri.ToString());
            };
            crawler.Start(new Uri(uri), new WebProxy("112.85.129.143", 9999)).Wait();
        }
    }
}

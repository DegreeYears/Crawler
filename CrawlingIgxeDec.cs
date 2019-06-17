using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrawlingDecInfoCMD
{
    class CrawlingIgxeDec
    {
        public void GetDecInfo(string pageSource,DoIO doIO)
        {
            //解析html Install-Package HtmlAgilityPack
            //结合Xpath
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(pageSource);
            string xpatnDiv = "//div[@class='dataList']";
            HtmlNodeCollection htmlNode_dec = htmlDoc.DocumentNode.SelectNodes(xpatnDiv)[0].SelectNodes("//a[@class='single csgo']");

            foreach (var item in htmlNode_dec)
            {
                //防止全局匹配 重要
                var xpath = item.XPath;
                //磨损度
                string label_dec = null;
                if (item.SelectSingleNode(xpath + "//div[@class='label']") != null)
                {
                    label_dec = (item.SelectSingleNode(xpath + "//div[@class='label']").InnerText);
                }
                //饰品名
                string name_dec = item.SelectSingleNode(xpath + "//div[@class='name']").InnerText;
                //igxe价格
                string price_dec = item.SelectSingleNode(xpath + "//div[@class='inf clearfix']").SelectSingleNode(xpath + "//div[@class='price fl']").SelectSingleNode(xpath + "//span").InnerText
                + item.SelectSingleNode(xpath + "//div[@class='inf clearfix']").SelectSingleNode(xpath + "//div[@class='price fl']").SelectSingleNode(xpath + "//sub").InnerText;
                //在售数量
                string count_dec_html = item.SelectSingleNode(xpath + "//div[@class='inf clearfix']").SelectSingleNode(xpath + "//div[@class='sum fr']").InnerText;
                string count_dec = count_dec_html.Replace("在售：", "");
                //图片地址
                string img_dec = item.SelectSingleNode(xpath + "//div[@class='img']").SelectSingleNode(xpath + "//img").Attributes["src"].Value;
                string txt = "饰品:" + name_dec + ",磨损度：" + label_dec + ",价格：" + price_dec + ",在售数量：" + count_dec + ",图片地址：" + img_dec;
                Console.WriteLine(txt);
                doIO.WriteTxt(txt);
            }
        }
    }
}

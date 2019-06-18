using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CrawlingDecInfoCMD
{
    /// <summary>
    /// 处理数据
    /// </summary>
    class DataAccess
    {
        /// <summary>
        /// 处理IgxeCsgo数据
        /// </summary>
        public void DataAccess_IgxeCsgo() {
            try
            {
                var fs = new FileStream(@"..\..\..\bin\data\dec2.txt", FileMode.Open);
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
                var list_count = new List<string>();
                DoIO doIO = new DoIO();
                /*
                for (int i = 0; i < list_dec.Count; i++)
                {
                    for (int j = i+1; j < list_dec.Count; j++)
                    {
                        if (list_dec[i].First() == list_dec[j].First() && list_dec[i][1] == list_dec[j][1])
                        {
                            //list_dec.Remove(list_dec[j]);//删除重复行
                            Console.WriteLine((i + 1) + "," + (j + 1));
                        }
                    }
                }
                //重新保存
                foreach (var item in list_dec)
                {
                    string txt = null;
                    foreach (var item1 in item)
                    {
                        txt += item1 + ",";
                    }
                    
                    doIO.WriteTxt(txt, "..\\..\\..\\bin\\data\\dec2.txt");
                }
                */
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CrawlingDecInfoCMD
{
    public class Crawler
    {
        public event EventHandler<OnStartEventArgs> OnStart;//启动
        public event EventHandler<OnCompleteEventArgs> OnComplete;//complete
        public event EventHandler<Exception> OnError;//error
        public CookieContainer CookiesContainer { get; set; }//Cookie Cantainer
        public Crawler() { }
        public async Task<string> Start(Uri uri, WebProxy proxy = null)
        {
            return await Task.Run(() =>
            {
                var pageSource = string.Empty;
                try
                {
                    if (this.OnStart != null)
                    {
                        this.OnStart(this, new OnStartEventArgs(uri));
                    }
                    var watch = new Stopwatch();
                    var request = (HttpWebRequest)WebRequest.Create(uri);
                    request.Accept = "*/*";
                    request.ContentType = "application/x-www-form-urlencoded";//文档类型及编码
                    request.AllowAutoRedirect = false; //禁止alllow auto
                    //设置 User-Agent,伪装成GoogleChrome
                    request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
                    request.Timeout = 5000;//5秒超时
                    request.KeepAlive = true;
                    request.Method = "Get";
                    if (proxy != null)
                    {
                        request.Proxy = proxy;//设置代理服务器IP，伪装请求地址
                    }
                    request.CookieContainer = this.CookiesContainer;
                    request.ServicePoint.ConnectionLimit = int.MaxValue;//最大请求连接数
                    var response = (HttpWebResponse)request.GetResponse();//获得请求响应
                    foreach (Cookie cookie in response.Cookies)
                    {
                        this.CookiesContainer.Add(cookie);
                    }
                    var stream = response.GetResponseStream();//获获取响应流
                    var reader = new StreamReader(stream, Encoding.UTF8);//以UTF-8的方式读取流
                    pageSource = reader.ReadToEnd();//获取网页源代码
                    watch.Stop();
                    var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;//获取当前任务线程Id
                    var milliseconds = watch.ElapsedMilliseconds;//获取请求执行时间
                    reader.Close();//释放资源
                    stream.Close();
                    request.Abort();
                    response.Close();
                    if (this.OnComplete != null)
                    {
                        this.OnComplete(this, new OnCompleteEventArgs(uri, threadId, milliseconds, pageSource));
                    }
                }
                catch (Exception ex)
                {
                    if (this.OnError != null)
                    {
                        this.OnError(this, ex);
                    }
                }
                return pageSource;
            });
        }
    }
    /// <summary>
    /// strat
    /// </summary>
    public class OnStartEventArgs
    {
        public Uri Uri { get; set; }

        public OnStartEventArgs(Uri uri)
        {
            this.Uri = uri;
        }
    }
    /// <summary>
    /// complete
    /// </summary>
    public class OnCompleteEventArgs
    {
        public Uri Uri { get; private set; }
        public int ThreadId { get; private set; } // Thread ID
        public string PageSource { get; private set; } // Source
        public long Milliseconds { get; private set; } //
        public OnCompleteEventArgs(Uri uri, int threadId, long milliseconds, string pageSource)
        {
            Uri = uri;
            ThreadId = threadId;
            Milliseconds = milliseconds;
            PageSource = pageSource;
        }
    }

}

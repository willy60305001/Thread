using CH07;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch07
{
    class Program
    {
        static void Main(string[] args)
        {


            // 範例一
            //Console.WriteLine("********** 請輸入 PID **********");
            //Console.Write("PID：");
            //string PID = Console.ReadLine();
            //int procID = int.Parse(PID);
            //sample.EnumThreadsForPID(procID);
            //Console.ReadLine();

            //範例二 無執行緒
            //sample.Write1To50();
            //sample.Write51To100();
            //Console.ReadLine();

            // 範例三
            //建立新執行緒
            //Thread t = new Thread(sample.Write1To50);
            //// 啟動執行緒
            //t.Start();
            //// 同時主執行緒也會執行
            //sample.Write51To100();
            //Console.ReadLine();

            // 範例四
            // 建立新執行緒
            //Thread t1 = new Thread(sample.MyBackgroundTask);
            //Thread t2 = new Thread(sample.MyBackgroundTask);
            //Thread t3 = new Thread(sample.MyBackgroundTask);

            //t1.Start("(1)");
            //t2.Start("(2)");
            //t3.Start("(3)");

            //for (int i = 0; i < 500; i++)
            //{
            //    Console.Write("(4)");
            //}
            //Console.ReadLine();

            // 範例五
            //Thread t1 = new Thread(sample.MyBackgroundTask);
            //Thread t2 = new Thread(sample.MyBackgroundTask);
            //Thread t3 = new Thread(sample.MyBackgroundTask);

            //t1.Start("(1)");
            //Thread.Sleep(5000);
            //t2.Start("(2)");
            //Thread.Sleep(5000);
            //t3.Start("(3)");

            ////主執行緒會暫停等所有join執行緒結束
            //t1.Join();
            //t2.Join();
            //t3.Join();

            //for (int i = 0; i < 500; i++)
            //{
            //    Console.Write("(4)");
            //}
            //Console.ReadLine();

            // 範例六
            //Thread t1 = new Thread(sample.AddToCart);
            //Thread t2 = new Thread(sample.AddToCart);

            //t1.Start(3000);
            //t2.Start(1000);

            //Console.ReadLine();

            // 範例七
            //Thread t = new Thread(sample.MyWork);
            //t.IsBackground = false;
            //t.Start();

            // 範例八
            //ThreadPool.QueueUserWorkItem(new WaitCallback(sample.MyTask));

            // for (int i = 0; i < 500; i++)
            // {
            //    Console.Write("[MAIN:" + Thread.CurrentThread.ManagedThreadId + "]");
            // }
            //Console.ReadLine();

            // 範例九 工作取消
            //CancellationTokenSource cts = new CancellationTokenSource();
            //ThreadPool.QueueUserWorkItem(state => sample.MyCancelTask(cts.Token));

            //Console.WriteLine("請輸入Y/N決定是否取消工作");
            //string result = Console.ReadLine();

            //while (true)
            //{
            //    if (result == "Y")
            //    {
            //        cts.Cancel();
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("請輸入Y/N決定是否取消工作");
            //        result = Console.ReadLine();
            //    }
            //}
            //Console.ReadLine();


            // 範例十 工作逾時
            //CancellationTokenSource cts = new CancellationTokenSource(5000);
            //ThreadPool.QueueUserWorkItem(state => sample.MyCancelTask2(cts.Token));

            //Console.WriteLine("請輸入Y/N決定是否取消工作");
            //string result = Console.ReadLine();

            //while (true)
            //{
            //    if (result == "Y")
            //    {
            //        cts.Cancel();
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("請輸入Y/N決定是否取消工作");
            //        result = Console.ReadLine();
            //    }
            //}
            //Console.ReadLine();

            // 範例十一
            //sample.TaskRun3();

            // 範例十二
            //sample.ContinueWith();

            // 範例十三
            //sample.Awaiter();

        }

        static async Task<string> MyDownloadPageAsync(string url)
        {
            var webClient = new WebClient();

            Task<string> task = webClient.DownloadStringTaskAsync(url);
            string content = await task;

            Console.WriteLine("網頁內容1");
            Console.WriteLine("網頁內容2");
            Console.WriteLine("網頁內容3");

            return content;
        }
    }
}

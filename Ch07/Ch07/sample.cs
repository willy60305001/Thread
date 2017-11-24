using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CH07
{
    public static class sample
    {
        public static void EnumThreadsForPID(int PID)
        {
            Process proc = null;
            try
            {
                proc = Process.GetProcessById(PID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            // 列出指定PID執行緒中每一個執行緒資訊
            Console.WriteLine("執行緒名稱：{0}", proc.ProcessName);
            ProcessThreadCollection threads = proc.Threads;
            foreach (ProcessThread pt in threads)
            {
                string info = string.Format("Thread ID:{0}\t" +
                                            "Start Time:{1}\t" +
                                            "Priority:{2}",
                                            pt.Id,
                                            pt.StartTime,
                                            pt.PriorityLevel);
                Console.WriteLine(info);
            }
            Console.WriteLine("********************");
        }

        public static void Write1To50()
        {
            for (int i = 1; i <= 50; i++)
            {
                Console.Write(i + ",");
            }
        }

        public static void Write51To100()
        {
            for (int i = 51; i <= 100; i++)
            {
                Console.Write(i + ",");
            }
        }

        public static void new10Thread()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(() =>
                {
                    Console.WriteLine(string.Format("{0}:{1}",
                        Thread.CurrentThread.Name, i));
                });
                t.Name = string.Format("執行緒{0}", i);
                t.IsBackground = true;
                t.Start();
            }
            Console.ReadLine();
        }

        public static void new10Thread(int i)
        {
            Thread t = new Thread(() =>
            {
                Console.WriteLine(string.Format("{0}:{1}",
                    Thread.CurrentThread.Name, i));
            });
            t.Name = string.Format("執行緒{0}", i);
            t.IsBackground = true;
            t.Start();
        }

        public static void MyBackgroundTask(object parm)
        {
            
            for (int i = 0; i < 500; i++)
            {
                Console.Write(parm);
            }
            
        }

        private static int itemCount = 0;
        private static object locker = new Object();

        public static void AddToCart(object simulateDelay)
        {
            lock (locker)
            {
                itemCount++;

                /*
                 * 用 Thread.Sleep 來模擬這項工作所花的時間，時間長短
                 * 由呼叫端傳入的 simulateDelay 參數指定，以便藉由改變
                 * 此參數來觀察共享變數值的變化。
                 */
                Thread.Sleep((int)simulateDelay);
                Console.WriteLine("Items in cart: {0}", itemCount);
            }
            
        }

        public static void MyWork()
        {
            while (true) ;
        }

        public static void MyTask(object state)
        {
            for (int i = 0; i < 500; i++)
            {
                Console.Write("[" + Thread.CurrentThread.ManagedThreadId + "]");
            }
        }

        public static void MyCancelTask(CancellationToken token)
        {
            int i = 0;
            while(true)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("使用者要求取消工作! 進度:" + i.ToString() + "%");
                    return;
                }

                //處理工作... 
                Thread.Sleep(200);
                
                if (i < 100)
                {
                    i++;
                }
                
            }

        }

        public static void MyCancelTask2(CancellationToken token)
        {
            int i = 0;
            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("工作逾時! 進度:" + i.ToString() + "%");
                    return;
                }

                //處理工作... 
                Thread.Sleep(200);

                if (i < 100)
                {
                    i++;
                }

            }

        }

        internal static string MyDownloadPage(string url)
        {
            var webClient = new WebClient();  
            string htmlCode = webClient.DownloadString(url);

            return htmlCode;
        }

        public static void TaskRun1()
        {
            Task task = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("From Task.");
            });
            // 因為Task被 Thread.Sleep 暫停，回應 false
            Console.WriteLine(task.IsCompleted);
            // 封鎖執行緒，等待Task完成
            task.Wait();
            // Task已完成，回應 True
            Console.WriteLine(task.IsCompleted);
            Console.ReadLine();
        }

        public static void TaskRun2()
        {
            Task<int> task = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("From Task.");
                return 1;
            });
            // 如果Task未完成，封鎖執行緒
            int result = task.Result;
            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static Task<int> getN3()
        {
            Task<int> task = Task.Run(() => Enumerable.Range(1, 5000000).Count(n => (n % 3) == 0));
            return task;
        }

        public static void TaskRun3()
        {
            Task<int> task = getN3();
            Console.WriteLine("Task 執行中...");
            Console.WriteLine("整除3的個數有:" + task.Result);
            Console.ReadLine();
        }

        public static void ContinueWith()
        {
            Task<int> task = getN3();
            task.ContinueWith(c =>
            {
                int result = task.Result;
                Console.WriteLine("整除3的個數有:" + result);
            });
            Console.WriteLine("Task 執行中...");
            Console.ReadLine();
        }

        public static void Awaiter()
        {
            Task<int> task = getN3();
            var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int result = awaiter.GetResult();
                Console.WriteLine("整除3的個數有:" + result);
            });

            Console.WriteLine("Task 執行中...");
            Console.ReadLine();
        }



        
    }
}

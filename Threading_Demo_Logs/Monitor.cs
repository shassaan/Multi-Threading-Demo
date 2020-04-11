using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threading_Demo_Logs
{
    public class MyMonitor
    {
        public delegate void Warning(int d,string time);
        public event Warning onData;
        public event Warning onEvenData;
        public event Warning onOddData;
        public event Warning onPrimeData;



        public void readData(int start , int end , int interval)
        {
            var r = new Random();
            int data;
            while (true)
            {
                data = r.Next(start, end);
                if (onData!=null)
                {
                    onData(data,DateTime.Now.TimeOfDay.ToString());
                }
                if (data % 2 == 0)
                {
                    if (onEvenData != null)
                    {
                        onEvenData(data,DateTime.Now.TimeOfDay.ToString());
                    }
                }
                if (data % 2 != 0)
                {
                    if (onOddData != null)
                    {
                        onOddData(data,DateTime.Now.TimeOfDay.ToString());
                    }
                }

                if (isPrime(data))
                {
                    if (onPrimeData !=null)
                    {
                        onPrimeData(data,DateTime.Now.TimeOfDay.ToString());
                    }
                }

                Thread.Sleep(interval*1000);
            }


        }


        private bool isPrime(int num)
        {
            bool isPrime = true;
            Console.WriteLine("Prime Numbers : ");
            for (int i = 2; i <= 100; i++)
            {
                for (int j = 2; j <= 100; j++)
                {

                    if (i != j && i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }

                }
                if (isPrime)
                {
                    Console.Write("\t" + i);
                }
                isPrime = true;

            }
            return isPrime;
        }
    }
}

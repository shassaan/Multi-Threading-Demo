using System;
using System.Threading;
using System.Windows.Forms;

namespace Threading_Demo_Logs
{
    public partial class Logger : Form
    {
        MyMonitor monitor;
        public static int i;
        public Logger(MyMonitor m)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            monitor = m;

            //Thread.CurrentThread.IsBackground = true;
        }

        private void assignAll(int data , string time) {
             dgvAll.Rows.Add(++i, data, time);
             //Application.DoEvents();
            //textBox1.Text += data;
            //textBox1.Text += Environment.NewLine;
                
        }

        private void assignOdd(int data, string time)
        {


            //textBox1.Text += data;
            //textBox1.Text += Environment.NewLine;
            dgvOdd.Rows.Add(++i, data, time);
           // Application.DoEvents();


        }

        private void assignEven(int data, string time)
        {
            
                dgvEven.Rows.Add(++i, data, time);
                Application.DoEvents();

        }

        private void assignPrime(int data, string time)
        {
            
                dgvPrime.Rows.Add(++i, data, time);
            //Application.DoEvents();

          
        }

        private void Logger_Load(object sender, EventArgs e)
        {

            

            
                monitor.onData += assignAll;

            
                monitor.onOddData += assignOdd;

            
                monitor.onEvenData += assignEven;

            
                monitor.onPrimeData += assignPrime;

           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}

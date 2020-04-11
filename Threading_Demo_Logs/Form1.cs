using System;
using System.Threading;
using System.Windows.Forms;
using Threading_Demo_Logs;

namespace Threading_Demo_Logss
{
    public partial class Form1 : Form
    {
        //SpTasksEntities _db = new SpTasksEntities();
        MyMonitor m;
         public Form1()
        {
            
                InitializeComponent();
                m = new MyMonitor();
            
            
        }
        
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
            {

                m.readData(int.Parse(txtFrom.Text),int.Parse(txtTo.Text),int.Parse(txtInterval.Text));

        });

            t.Start();
        }

        private void btnViewLog_Click(object sender, EventArgs e)
        {
                new Logger(m).Show();
        }
    }
}

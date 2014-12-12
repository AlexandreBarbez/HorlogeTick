using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorlogeTP
{
    public partial class Form1 : Form
    {
        private typeDate longeurDate;
        private Thread lethread;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.longeurDate = typeDate.dateHeure;        
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.longeurDate = typeDate.dateHeure;
            forceRefresh();
        }
        private void rbtnDate_CheckedChanged(object sender, EventArgs e)
        {
            this.longeurDate = typeDate.date;
        }

        private void rbtnHeure_CheckedChanged(object sender, EventArgs e)
        {
            this.longeurDate = typeDate.heure;
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            //lethread.Abort();
            this.Close();
        }

        private void refreshHorloge()
        {

            MethodInvoker monObjetAInvoquer = delegate
            {
                switch (this.longeurDate)
                {
                    case typeDate.dateHeure:
                        this.lblDateHeure.Text = "Time " + DateTime.Now.ToLongDateString() + DateTime.Now.TimeOfDay.ToString();
                        break;
                    case typeDate.date:
                        this.lblDateHeure.Text = "Time " + DateTime.Now.ToShortDateString();
                        break;
                    case typeDate.heure:
                        this.lblDateHeure.Text = "Time " + DateTime.Now.TimeOfDay.ToString();
                        break;
                    default:
                        break;
                }
            };
            this.Invoke(monObjetAInvoquer);
        }
        private void forceRefresh()
        {
            Thread threadRefresh = new Thread(this.refreshHorloge);
            threadRefresh.IsBackground = true;
            threadRefresh.Start();
        }
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            this.refreshHorloge();
        }

    }
    public enum typeDate
    {
        dateHeure, date, heure
    }
   
}

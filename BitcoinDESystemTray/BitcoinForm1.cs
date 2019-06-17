using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Threading;
using System.Net;
using Newtonsoft.Json;

namespace BitcoinDESystemTray
{
    public partial class BitcoinWindow : Form
    {
        //invisible form
        protected override void SetVisibleCore(bool value)
        {
            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
                value = false;
            }
            base.SetVisibleCore(value);
        }

        /*protected override void OnFormClosing(FormClosingEventArgs e)
        {

        }*/

        public BitcoinWindow()
        {
            InitializeComponent();
            try
            {
                Thread myThread = new Thread(delegate () { bitcoinDE_run(); });
                myThread.IsBackground = true;
                myThread.Start();

            }
            catch (Exception e)
            {
                MessageBox.Show("Fatal Error: " + e.Message);
                this.Close();
            }
        }

        private void bitcoinDE_run()
        {
            try
            {
                string json;
                string newToolTip = "Buy: 0.00€ Sell: 0.00€ ~Price: 0.00€ (" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "h)";
                string importentMessage = "";
                string importentLink = "";
                string old_importentMessage = "";
                string old_importentLink = "";
                double buyPrice = 0;
                double sellPrice = 0;
                double averagePrice = 0;
                double old_averagePrice = 0;

                while (true)
                {
                    json = new TimedWebClient { Timeout = 20000 }.DownloadString("http://miner-control.de/bitcoin_de.json");
                    if (json != "")
                    {
                        dynamic dynJSON = JsonConvert.DeserializeObject(json);
                        buyPrice = ((dynJSON.buyPrice != null && dynJSON.buyPrice != "") ? Convert.ToDouble(dynJSON.buyPrice) : 0);
                        sellPrice = ((dynJSON.sellPrice != null && dynJSON.sellPrice != "") ? Convert.ToDouble(dynJSON.sellPrice) : 0);
                        averagePrice = ((dynJSON.averagePrice != null && dynJSON.averagePrice != "") ? Convert.ToDouble(dynJSON.averagePrice) : 0);
                        old_averagePrice = ((dynJSON.averagePrice_3h != null && dynJSON.averagePrice_3h != "") ? Convert.ToDouble(dynJSON.averagePrice_3h) : 0);

                        newToolTip = "Buy: " + string.Format("{0:N2}", buyPrice) + "€ Sell: " + string.Format("{0:N2}", sellPrice) + "€ ~Price: " + string.Format("{0:N2}", averagePrice) + "€ (" + ((dynJSON.lastUpdateTime != null && dynJSON.lastUpdateTime != "") ? dynJSON.lastUpdateTime : "xx:xx:xx") + "h)";
                        importentMessage = ((dynJSON.importentMessage != null && dynJSON.importentMessage != "") ? dynJSON.importentMessage : "");
                        importentLink = ((dynJSON.importentLink != null && dynJSON.importentLink != "") ? dynJSON.importentLink : "");
                    }
                    if (averagePrice > old_averagePrice)
                    {
                        bitcoinIcon.Icon = new Icon(GetType(), "bitcoin_green.ico");
                    }
                    else if (averagePrice < old_averagePrice)
                    {
                        bitcoinIcon.Icon = new Icon(GetType(), "bitcoin_red.ico");
                    }
                    else
                    {
                        bitcoinIcon.Icon = new Icon(GetType(), "bitcoin.ico");
                    }
                    old_averagePrice = averagePrice;

                    //Info Ballon
                    if (importentMessage != old_importentMessage && importentLink != old_importentLink && importentLink != "" && importentMessage != "")
                    {
                        bitcoinIcon.BalloonTipText = importentMessage + " : Click here to open.";
                        bitcoinIcon.ShowBalloonTip(5000);
                    }

                    //Set all Infos to bar
                    bitcoinIcon.BalloonTipText = bitcoinIcon.Text = newToolTip;

                    if (importentMessage != "")
                    {
                        importentToolStripMenuItem.Text = importentMessage;
                        importentToolStripMenuItem.Tag = importentLink;
                        importentToolStripMenuItem.Visible = true;
                    }
                    else
                    {
                        importentToolStripMenuItem.Visible = false;
                    }

                    //Wait 1 min 
                    Thread.Sleep(60000); //60000 = 1 min
                    json = "";
                    old_importentMessage = importentMessage;
                    old_importentLink = importentLink;
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("Fatal Error: " + e.Message);
                bitcoinDE_run();
            }


        }

        private class TimedWebClient : WebClient
        {
            // Timeout in milliseconds, default = 600,000 msec
            public int Timeout { get; set; }

            public TimedWebClient()
            {
                this.Timeout = 300000;
            }

            protected override WebRequest GetWebRequest(Uri address)
            {
                var objWebRequest = base.GetWebRequest(address);
                objWebRequest.Timeout = this.Timeout;
                return objWebRequest;
            }
        }

        private void BitcoinWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
            }
        }

        private void bitcoinIcon_MouseClick(object sender, MouseEventArgs e)
        {
           if( e.Button == MouseButtons.Left) { 
            bitcoinIcon.ShowBalloonTip(5000);
                //this.Show();
                //this.WindowState = FormWindowState.Normal;
                ///this.ShowInTaskbar = true;
                /// 
                }
            }

        private void openBitcoindeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bitcoin.de/de/r/v8tznb");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void importentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (importentToolStripMenuItem.Tag != null && importentToolStripMenuItem.Tag.ToString() != "")
            {
                System.Diagnostics.Process.Start(importentToolStripMenuItem.Tag.ToString());
            }
        }

        private void bitcoinIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            if (importentToolStripMenuItem.Tag != null && importentToolStripMenuItem.Tag.ToString() != "")
            {
                System.Diagnostics.Process.Start(importentToolStripMenuItem.Tag.ToString());
            }
        }
    }


}

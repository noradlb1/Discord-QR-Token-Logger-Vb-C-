using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace Discord_QR_Token_Stealer
{
    public partial class infoPanel : Form
    {
        public infoPanel()
        {
            InitializeComponent();
        }

        void openUrl(string url)
        {
            var proc = new Process();
            var info = new ProcessStartInfo();
            info.FileName = url;
            proc.StartInfo = info;
            proc.Start();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            openUrl("https://verlox.cc");

        }

        private void label2_Click(object sender, EventArgs e)
        {
            openUrl("https://github.com/verlox");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCRoxxUj5BCM4DPP9aF7jQ9w");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/developers.syriaa");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://t.me/MONSTERMCSY");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://magholarabeee.blogspot.com");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotificationDialog
{
    public partial class NotificationDialog : Form
    {
        List<string> x = new List<string>();
        public NotificationDialog()
        {
            InitializeComponent();
        }
        public NotificationDialog(string title, string message, DialogType type)
        {

            InitializeComponent();
            x.Add(@"Res\success.png");
            x.Add(@"Res\warning.png");
            x.Add(@"Res\alert.png");
            x.Add(@"Res\notification.png");
            bunifuCustomLabel1.Text = title;
            bunifuCustomLabel2.Text = message;
            bunifuFormFadeTransition1.ShowAsyc(this);
            shower.Start();
            switch (type)
            {
                case DialogType.success:
                    this.BackColor = Color.FromArgb(36, 150, 241);
                    bunifuImageButton1.Image = Properties.Resources.success;
                    break;
                case DialogType.warning:
                    this.BackColor = Color.FromArgb(255, 129, 4);
                    bunifuImageButton1.Image = Properties.Resources.warning;
                    break;
                case DialogType.alert:
                    this.BackColor = Color.FromArgb(220, 21, 62);
                    bunifuImageButton1.Image = Properties.Resources.alert;
                    break;
                case DialogType.notify:
                    this.BackColor = Color.FromArgb(65, 63, 65);
                    bunifuImageButton1.Image = Properties.Resources.notification;
                    break;

            }
        }
        public static void ShowNotificationDialog(String Title, String Message, DialogType type)
        {
            new NotificationDialog(Title, Message, type).Show();
        }

        public enum DialogType
        { success, warning, alert, notify }
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Exitor.Start();

        }

        private void Exitor_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.1;
            }
            else
            {
                this.Hide();
            }
        }



        private void Closer_Tick(object sender, EventArgs e)
        {
            Exitor.Start();
        }

        private void NotificationDialog_Load(object sender, EventArgs e)
        {
            const int margin = 10;
            int x = Screen.PrimaryScreen.WorkingArea.Right -
                this.Width - margin;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom -
                this.Height - margin;
            this.Location = new Point(x, y);

            Closer.Start();
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void shower_Tick(object sender, EventArgs e)
        {

        }

        private void NotificationDialog_MouseEnter(object sender, EventArgs e)
        {
            Closer.Stop();
        }

        private void NotificationDialog_MouseLeave(object sender, EventArgs e)
        {
            Closer.Start();
        }
    }
}

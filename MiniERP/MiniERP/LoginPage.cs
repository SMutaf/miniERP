using MiniERP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniERP
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();

            setDesign();

            setLoginPanelPosition();

            setInformations();

            setFirms();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            
        }

        private void setDesign()
        {
            // form sayfasının  alt sekmeye atılmasını veya büyük erkan yapılmamasını sağlar
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            //form sayfasının başlığını siler tasarım için 
            this.Text = "";
            // form sayfasını yeniden boyutlanabilirliğini engeller
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            //app çalıştığında login formunu ekranın ortasında başlatır
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void setLoginPanelPosition()
        {
            //Login bileşenlerini tutucak paneli formun tam ortasına getirir
            LoginPanel.Location = new Point(
                (this.ClientSize.Width - LoginPanel.Width) / 2,
                (this.ClientSize.Height - LoginPanel.Height) / 2
            );
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            //şifrenin * şeklinde görünmememsini sağlar
            passwordTextBox.UseSystemPasswordChar = true;
        }

        private void settingButton_Click(object sender, EventArgs e)
        {
            //ayarlar sayfsaını açar ve login pagein etkileşimini ayarlar sayfası açık kaldığı sürece kapatır
            SettingsPage settingsPage = new SettingsPage();
            settingsPage.ShowDialog();
        }

        private void setInformations()
        {
            //Serveri ve veri tabının adını labellara yerleştirir
            DataBaseHelper db = new DataBaseHelper();
            db.getConnectionInfo(serverLabel, dataBaseLabel);
        }

        private void setFirms()
        {
            //veri tabanıda bulunan firmaları combobaxa item kısmına ekler
            DataBaseHelper db = new DataBaseHelper();
            db.getFirms(firmComboBox);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            /* isim şifre ve firma parametlerini veritabanındaki doğrulama metoduna gönderir 
             * ve true değeri dödüğünde firmanın çalışan bilgileriinin olucağı control page
             * sayfasını açar */
            DataBaseHelper db = new DataBaseHelper();
            bool adminControl = db.adminAuthentication(
                userNameTextBox.Text
                , passwordTextBox.Text,
                firmComboBox.SelectedItem?.ToString());

            if (adminControl) 
            {
               ControlPage controlPage = new ControlPage(userNameTextBox.Text.ToString());
               this.Hide();

                controlPage.FormClosed += (s, args) => this.Close();//control paneli kapandığında arkada gizlenmiş olan login pagedi sonlandırır
                controlPage.Show();
            }
        }
    }
}

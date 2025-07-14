using MiniERP.Backend.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniERP.GUI.FirmControlGui
{
    public partial class FormAddAdmin : Form
    {
        public FormAddAdmin()
        {
            InitializeComponent();
            SetFormDesign();
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            string adminName = txtAdminName.Text.Trim();
            string password = txtPassword.Text;
            string passwordAgain = txtPasswordAgain.Text;

            if (string.IsNullOrWhiteSpace(adminName) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(passwordAgain)){
                MessageBox.Show("Tüm alanları doldurmalısınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;}
            if (password != passwordAgain){MessageBox.Show("Şifreler uyuşmuyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;}
            if (password.Length < 8){MessageBox.Show("Şifre en az 8 karakter olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;}

            try
            {
                DatabaseManager manager = new DatabaseManager();
                manager.CreateDatabaseAdminUser(adminName, password);

                MessageBox.Show("Admin başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Admin eklenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetFormDesign()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Text = "Admin Ekleme Paneli";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            txtPassword.UseSystemPasswordChar = true;
            txtPasswordAgain.UseSystemPasswordChar = true;
        }
    }
}

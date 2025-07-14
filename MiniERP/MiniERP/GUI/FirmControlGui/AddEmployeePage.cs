using MiniERP.Backend.Services;
using MiniERP.Backend.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace MiniERP.GUI
{
    public partial class AddEmployeePage : Form
    {
        public AddEmployeePage()
        {
            InitializeComponent();
            SetFormDesign();
            SetComBoxes();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInformationFormats())
            {
                AddEmployee();
                this.Close();
            }
        }

        private bool CheckInformationFormats()
        {
            string fullName = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string phone = textBox3.Text.Trim();
            string address = textBox4.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName)){MessageBox.Show("İsim soyisim boş olamaz.");return false;}

            if (!IsValidEmail(email)){MessageBox.Show("Geçersiz email formatı.");return false;}

            if (!IsValidPhoneNumber(phone)){MessageBox.Show("Telefon numarası 11 haneli ve sadece rakamlardan oluşmalıdır.");return false;}

            if (string.IsNullOrWhiteSpace(address)){MessageBox.Show("Adres boş olamaz.");return false;}

            if (comboBoxDepartman.SelectedItem == null){MessageBox.Show("Lütfen bir departman seçiniz.");return false;}

            if (comboRole.SelectedItem == null){MessageBox.Show("Lütfen bir rol seçiniz.");return false;}

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string number)
        {
            return number.All(char.IsDigit) && number.Length == 11;
        }

        private void SetComBoxes()
        {
            FirmDatabaseService dbService = new FirmDatabaseService();
            dbService.GetRoleAndDepertmans(comboBoxDepartman, comboRole);
        }

        private void AddEmployee()
        {
            string fullName = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string phone = textBox3.Text.Trim();
            string address = textBox4.Text.Trim();

            int departmentId = ((KeyValuePair<int, string>)comboBoxDepartman.SelectedItem).Key;
            int roleId = ((KeyValuePair<int, string>)comboRole.SelectedItem).Key;

            EmployeeDataBaseService employeeServis = new EmployeeDataBaseService();
            FirmDatabaseService firmService = new FirmDatabaseService();
      
            int firmId = firmService.GetFirmIdByName(UserSession.firm);
            bool isSuccess = employeeServis.AddEmployee(fullName, email, phone, address, departmentId, roleId, firmId, out string errorMessage);

            if (isSuccess)
            {
                MessageBox.Show("Çalışan başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ekleme başarısız: " + errorMessage, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetFormDesign()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Text = "Çalışan Ekleme Paneli";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}

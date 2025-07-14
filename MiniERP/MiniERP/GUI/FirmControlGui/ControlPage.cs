using Microsoft.VisualBasic.ApplicationServices;
using MiniERP.Backend.Services;
using MiniERP.Backend.Session;
using MiniERP.GUI;
using MiniERP.GUI.FirmControlGui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniERP
{
    public partial class ControlPage : Form
    {

        private string firm;
        public ControlPage(string sqlUsername, string sqlUserpass, string firm)
        {
            InitializeComponent();
            this.firm = firm;
            UserSession.SetUserSession(sqlUsername, sqlUserpass, firm);
            GetFirmInformations();
            SetFormDesign();
        }

        private void buttonEmployeeAdd_Click(object sender, EventArgs e)
        {
            AddEmployeePage addEmployeePage = new AddEmployeePage();
            addEmployeePage.ShowDialog();

            GetFirmInformations();
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir çalışan seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridViewEmployees.SelectedRows[0];
            string fullName = selectedRow.Cells["Ad Soyad"].Value.ToString();

            DialogResult dialogResult = MessageBox.Show($"{fullName} adlı çalışanı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            EmployeeDataBaseService employeeService = new EmployeeDataBaseService();
            int employeeId = employeeService.GetEmployeeIdByFullName(fullName);
            if (employeeId == -1)
            {
                MessageBox.Show("Employee ID alınamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EmployeeDataBaseService dbService = new EmployeeDataBaseService();
            bool success = dbService.DeleteEmployee(employeeId, out string error);

            if (success)
            {
                MessageBox.Show("Çalışan başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetFirmInformations(); 
            }
            else
            {
                MessageBox.Show("Silme başarısız: " + error, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            FormAddAdmin formAddAdmin = new FormAddAdmin();
            formAddAdmin.ShowDialog();
        }

        private void SetFormDesign()
        {
            labelSessionFirm.Text += this.firm;
            labelUserSession.Text += UserSession.sqlUser;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Text = "Firma Çalışan Paneli";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
       
        }

        private void GetFirmInformations()
        {
            EmployeeDataBaseService databaseService = new EmployeeDataBaseService();
            DataTable dt = databaseService.GetEmployees(out string errMessage);

            if (!string.IsNullOrWhiteSpace(errMessage))
            {
                MessageBox.Show("Hata: " + errMessage, "Veri Çekme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dataGridViewEmployees.DataSource = dt;
        }

        

        
    }
}

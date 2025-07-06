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
    public partial class ControlPage : Form
    {

        private string firm;
        public ControlPage(string sqlUsername, string sqlUserpass, string firm)
        {
            InitializeComponent();
            this.firm = firm;
            UserSession.SetUserSession(sqlUsername, sqlUserpass); 
            GetFirmInformations(sqlUsername, sqlUserpass, firm); 
            SetDesign();
        }

        private void SetDesign()
        {
            labelSessionFirm.Text += this.firm;
            labelUserSession.Text += UserSession.sqlUser;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Text = "Firma Çalışan Paneli";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void GetFirmInformations(string sqlUsername, string sqlUserpass, string firm)
        {
            FirmDatabaseService databaseService = new FirmDatabaseService();
            DataTable dt = databaseService.GetEmployees(firm, out string errMessage);

            if (!string.IsNullOrWhiteSpace(errMessage))
            {
                MessageBox.Show("Hata: " + errMessage, "Veri Çekme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dataGridViewEmployees.DataSource = dt;
        }
     
    }
}

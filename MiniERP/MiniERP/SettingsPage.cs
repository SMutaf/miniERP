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
    public partial class SettingsPage : Form
    {
        public SettingsPage()
        {
            InitializeComponent();

            setDesign();
        }

        private void SettingsPage_Load(object sender, EventArgs e)
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
    }
}

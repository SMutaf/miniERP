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
        public ControlPage(string userName)
        {
            InitializeComponent();
            accountName.Text += userName;
        }

        private void ControlPage_Load(object sender, EventArgs e)
        {
             
        }
    }
}

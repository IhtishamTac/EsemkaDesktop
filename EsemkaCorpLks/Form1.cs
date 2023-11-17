using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaCorpLks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtPassword.Text))
            {
                lblError.Text = "Lengkapi semua data";
                return;
            }
            EsemkaCorporationEntities db = new EsemkaCorporationEntities();
            var user = db.employees.FirstOrDefault(x => x.email == txtEmail.Text && x.password == txtPassword.Text);
            if(user == null)
            {
                lblError.Text = "User tidak ditemukan";
                return;
            }
            LoginSession.employee = user;
            this.Hide();
            new MainForm().ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

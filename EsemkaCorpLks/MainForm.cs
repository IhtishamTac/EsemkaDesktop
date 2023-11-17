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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txtEmployeeName.Text = LoginSession.employee.name;
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            int id = LoginSession.employee.id; 
            new ProfileForm(id).ShowDialog();
        }

        private void BtnMutation_Click(object sender, EventArgs e)
        {
            new MutationForm().ShowDialog();
        }

        private void BtnPromotion_Click(object sender, EventArgs e)
        {
            new PromotionForm().ShowDialog();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
            this.Close();
        }
    }
}

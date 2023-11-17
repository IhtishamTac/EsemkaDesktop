using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaCorpLks
{
    public partial class MutationForm : Form
    {
        private int employeId = LoginSession.employee.id;
        private int? jobId = null;
        public MutationForm()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnProfileMain_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void MutationForm_Load(object sender, EventArgs e)
        {
            LoadProfileMutation();
            LoadJobMutation();
        }

        private void LoadProfileMutation()
        {
            EsemkaCorporationEntities db = new EsemkaCorporationEntities();
            var profile = (from a in db.employees
                           join b in db.positions
                           on a.id equals b.employee_id
                           join c in db.jobs
                           on b.job_id equals c.id
                           join d in db.departments
                           on c.department_id equals d.id
                           join e in db.job_level
                           on c.job_level_id equals e.id
                           where a.deleted_at == null && b.deleted_at == null && c.deleted_at == null &&
                           d.deleted_at == null && e.deleted_at == null && a.id == employeId
                           select new
                           {
                               Employee = a,
                               DepartmentName = d.name,
                               JobLevel = e,
                               Job = c
                           }
                          ).First();
            var ci = new CultureInfo("id-iD");
            txtName.Text = profile.Employee.name;
            txtCurrentPosition.Text = profile.Job.name;
            txtCurrentJobLevel.Text = profile.JobLevel.name;
            txtCurrentDepartment.Text = profile.DepartmentName;
            jobId = profile.Job.id;
        }

        private void LoadJobMutation()
        {
            EsemkaCorporationEntities db = new EsemkaCorporationEntities();
            var mutation = (from a in db.employees
                           join b in db.positions
                           on a.id equals b.employee_id
                           join c in db.jobs
                           on b.job_id equals c.id
                           join d in db.departments
                           on c.department_id equals d.id
                           join e in db.job_level
                           on c.job_level_id equals e.id
                           where a.deleted_at == null && b.deleted_at == null && c.deleted_at == null &&
                           d.deleted_at == null && e.deleted_at == null && e.id == jobId
                            select new
                           {
                                JobDgvId = c.id,
                                Department = d.name,
                               Position = c.name
                           }
                          );
            dgvJobMutation.Rows.Clear();
            foreach(var data in mutation){
                int rowIndex = dgvJobMutation.Rows.Add(new object[] {
                    data.Department,
                    data.Position,
                    db.mutations.FirstOrDefault(x => x.employee_id == employeId && x.job_id == data.JobDgvId) == null ? "Apply":"Applied"
                });
               
                dgvJobMutation.Rows[rowIndex].Tag = data.JobDgvId;
            }
        }

        private void DgvJobMutation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvJobMutation.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            dgvJobMutation.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
                try
                {
                    DataGridViewRow clickedRow = dgvJobMutation.Rows[e.RowIndex];
                    int jobDgvId = (int)clickedRow.Tag;
                    EsemkaCorporationEntities db = new EsemkaCorporationEntities();
                    var mutated = db.mutations.FirstOrDefault(x => x.employee_id == employeId && x.job_id == jobDgvId);
                    if (mutated != null)
                    {
                        MessageBox.Show("You already applied to this mutation!");
                        return;
                    }
                    db.mutations.Add(new mutation
                    {
                        job_id = jobDgvId,
                        employee_id = employeId,
                        status = "P",
                        created_at = DateTime.Now
                    }
                    );
                    db.SaveChanges();
                    MessageBox.Show("Mutation Pending");
                    LoadJobMutation();

                }
                catch (Exception ex){
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}

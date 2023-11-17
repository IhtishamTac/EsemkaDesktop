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
    public partial class PromotionForm : Form
    {
        private int employeId = LoginSession.employee.id;
        private int? jobId = null;
        public PromotionForm()
        {
            InitializeComponent();
        }

        private void BtnPromotionForm_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void PromotionForm_Load(object sender, EventArgs e)
        {
            LoadProfilePromotion();
            LoadJobPromotion();
        }

        private void LoadProfilePromotion()
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

        private void LoadJobPromotion()
        {
            EsemkaCorporationEntities db = new EsemkaCorporationEntities();
            var promotion = (from a in db.employees
                            join b in db.positions
                            on a.id equals b.employee_id
                            join c in db.jobs
                            on b.job_id equals c.id
                            join d in db.departments
                            on c.department_id equals d.id
                            join e in db.job_level
                            on c.job_level_id equals e.id
                            where a.deleted_at == null && b.deleted_at == null && c.deleted_at == null &&
                            d.deleted_at == null && e.deleted_at == null && e.id == jobId + 1
                            select new
                            {
                                JobDgvId = c.id,
                                Department = d.name,
                                Position = c.name
                            }
                          );
            dgvJobPromotion.Rows.Clear();
            foreach (var data in promotion)
            {
                int rowIndex = dgvJobPromotion.Rows.Add(new object[] {
                    data.Department,
                    data.Position,
                    db.promotions.FirstOrDefault(x => x.employee_id == employeId && x.job_id == data.JobDgvId) == null ? "Apply":"Applied"
                });

                dgvJobPromotion.Rows[rowIndex].Tag = data.JobDgvId;
            }

        }

        private void DgvJobPromotion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvJobPromotion.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            dgvJobPromotion.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
                try
                {
                    DataGridViewRow clickedRow = dgvJobPromotion.Rows[e.RowIndex];
                    int jobDgvId = (int)clickedRow.Tag;
                    EsemkaCorporationEntities db = new EsemkaCorporationEntities();
                    var promoted = db.promotions.FirstOrDefault(x => x.employee_id == employeId && x.job_id == jobDgvId);
                    if (promoted != null)
                    {
                        MessageBox.Show("You already applied to this promotion!");
                        return;

                    }
                    db.promotions.Add(new promotion
                    {
                        job_id = jobDgvId,
                        employee_id = employeId,
                        status = "P",
                        created_at = DateTime.Now
                    }
                    );
                    db.SaveChanges();
                    MessageBox.Show("Promotion Pending");
                    LoadJobPromotion();

                    //using (SqlConnection con = new SqlConnection("Data Source=./;Initial Catalog=EsemkaCorporation;Integrated Security=True"))
                    //{
                    //    con.Open();
                    //    string sql = "INSERT INTO promotion (job_id, employee_id, status, created_at) VALUES(@job_id, @employee_id, @status, @created_at)";
                    //    SqlCommand cmd = new SqlCommand(sql, con);
                    //    cmd.Parameters.AddWithValue("@job_id", jobDgvId);
                    //    cmd.Parameters.AddWithValue("@employee_id", employeId);
                    //    cmd.Parameters.AddWithValue("@status", "P");
                    //    cmd.Parameters.AddWithValue("@created_at", DateTime.Now);
                    //    cmd.ExecuteNonQuery();

                    //}
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}

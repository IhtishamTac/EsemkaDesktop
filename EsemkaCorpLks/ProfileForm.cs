using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaCorpLks
{
    public partial class ProfileForm : Form
    {
        private int employeId = LoginSession.employee.id;
        private int? jobId = null;
        private int? supervisorId = null;
        private int? id = null;
        public ProfileForm(int id)
        {
            InitializeComponent();
            employeId = id;
        }

        private void BtnProfileMain_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            LoadProfile();
            JobHistories();
            Subordinate();
            WorksWith();
        }

        private void LoadProfile()
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
            txtEmail.Text = profile.Employee.email;
            txtPhoneNumber.Text = profile.Employee.phone_number;
            txtHireDate.Text = profile.Employee.hire_date.ToString("dddd, dd MMMM yyyy", ci);
            txtPosition.Text = profile.Job.name;
            txtJobLevel.Text = profile.JobLevel.name;
            txtDepartment.Text = profile.DepartmentName;
            supervisorId = profile.Job.supervisor_job_id;
            id = supervisorId;
            jobId = profile.Job.id;
        }

        private void JobHistories()
        {
            EsemkaCorporationEntities db = new EsemkaCorporationEntities();
            var jobhistory = (from a in db.employees
                           join b in db.positions
                           on a.id equals b.employee_id
                           join c in db.jobs
                           on b.job_id equals c.id
                           join d in db.departments
                           on c.department_id equals d.id
                           join e in db.job_level
                           on c.job_level_id equals e.id
                           where a.id == employeId
                           select new
                           {
                               Department = d.name,
                               Position = c.name
                           }
                          );
            dgvJobHistory.DataSource = jobhistory.ToList();
        }

        private void Subordinate()
        {
            EsemkaCorporationEntities db = new EsemkaCorporationEntities();
            var subordidate = (from a in db.employees
                               join b in db.positions
                               on a.id equals b.employee_id
                               join c in db.jobs
                               on b.job_id equals c.id
                               join d in db.departments
                               on c.department_id equals d.id
                               join e in db.job_level
                               on c.job_level_id equals e.id
                               where a.deleted_at == null && b.deleted_at == null && c.deleted_at == null &&
                           d.deleted_at == null && e.deleted_at == null && e.id == jobId -1
                               select new
                               {
                                   Name = a.name,
                                   Position = c.name
                               }
                          );
            dgvSubordidate.DataSource = subordidate.ToList();
        }

        private void WorksWith()
        {
            EsemkaCorporationEntities db = new EsemkaCorporationEntities();
            var workswith = (from a in db.employees
                             join b in db.positions
                             on a.id equals b.employee_id
                             join c in db.jobs
                             on b.job_id equals c.id
                             join d in db.departments
                             on c.department_id equals d.id
                             join e in db.job_level
                             on c.job_level_id equals e.id
                             where c.supervisor_job_id == supervisorId
                             select new
                             {
                                 Name = a.name,
                                 Position = c.name,
                             }
                         );
            
            dgvWorksWith.DataSource = workswith.ToList();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LblSupervisorName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (id != null)
            {
                SuperVisorData(id.Value);
            }
        }
        private void SuperVisorData(int id)
        {
            ProfileForm profileForm = new ProfileForm(id);
            profileForm.ShowDialog();
        }
    }
}

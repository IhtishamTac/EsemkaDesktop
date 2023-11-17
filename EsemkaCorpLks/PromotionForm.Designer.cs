namespace EsemkaCorpLks
{
    partial class PromotionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvJobPromotion = new System.Windows.Forms.DataGridView();
            this.dgvDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.app = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtCurrentJobLevel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCurrentPosition = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCurrentDepartment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPromotionForm = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobPromotion)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvJobPromotion);
            this.groupBox2.Location = new System.Drawing.Point(12, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(439, 176);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Avvailable Job Promotion";
            // 
            // dgvJobPromotion
            // 
            this.dgvJobPromotion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJobPromotion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvDepartment,
            this.dgvPosition,
            this.app});
            this.dgvJobPromotion.Location = new System.Drawing.Point(19, 19);
            this.dgvJobPromotion.Name = "dgvJobPromotion";
            this.dgvJobPromotion.Size = new System.Drawing.Size(405, 114);
            this.dgvJobPromotion.TabIndex = 0;
            this.dgvJobPromotion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvJobPromotion_CellContentClick);
            // 
            // dgvDepartment
            // 
            this.dgvDepartment.HeaderText = "Department";
            this.dgvDepartment.Name = "dgvDepartment";
            this.dgvDepartment.ReadOnly = true;
            this.dgvDepartment.Width = 131;
            // 
            // dgvPosition
            // 
            this.dgvPosition.HeaderText = "Position";
            this.dgvPosition.Name = "dgvPosition";
            this.dgvPosition.ReadOnly = true;
            this.dgvPosition.Width = 131;
            // 
            // app
            // 
            this.app.HeaderText = "Action";
            this.app.Name = "app";
            this.app.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.app.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txtCurrentJobLevel
            // 
            this.txtCurrentJobLevel.Location = new System.Drawing.Point(163, 211);
            this.txtCurrentJobLevel.Name = "txtCurrentJobLevel";
            this.txtCurrentJobLevel.ReadOnly = true;
            this.txtCurrentJobLevel.Size = new System.Drawing.Size(288, 20);
            this.txtCurrentJobLevel.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Current Job Level";
            // 
            // txtCurrentPosition
            // 
            this.txtCurrentPosition.Location = new System.Drawing.Point(163, 176);
            this.txtCurrentPosition.Name = "txtCurrentPosition";
            this.txtCurrentPosition.ReadOnly = true;
            this.txtCurrentPosition.Size = new System.Drawing.Size(288, 20);
            this.txtCurrentPosition.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Current Position";
            // 
            // txtCurrentDepartment
            // 
            this.txtCurrentDepartment.Location = new System.Drawing.Point(163, 140);
            this.txtCurrentDepartment.Name = "txtCurrentDepartment";
            this.txtCurrentDepartment.ReadOnly = true;
            this.txtCurrentDepartment.Size = new System.Drawing.Size(288, 20);
            this.txtCurrentDepartment.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Current Department";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(163, 102);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(288, 20);
            this.txtName.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Promotion";
            // 
            // btnPromotionForm
            // 
            this.btnPromotionForm.Location = new System.Drawing.Point(12, 12);
            this.btnPromotionForm.Name = "btnPromotionForm";
            this.btnPromotionForm.Size = new System.Drawing.Size(71, 28);
            this.btnPromotionForm.TabIndex = 8;
            this.btnPromotionForm.Text = "Main";
            this.btnPromotionForm.UseVisualStyleBackColor = true;
            this.btnPromotionForm.Click += new System.EventHandler(this.BtnPromotionForm_Click);
            // 
            // PromotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtCurrentJobLevel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCurrentPosition);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCurrentDepartment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPromotionForm);
            this.Name = "PromotionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PromotionForm";
            this.Load += new System.EventHandler(this.PromotionForm_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobPromotion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvJobPromotion;
        private System.Windows.Forms.TextBox txtCurrentJobLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCurrentPosition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCurrentDepartment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPromotionForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPosition;
        private System.Windows.Forms.DataGridViewButtonColumn app;
    }
}
namespace Shedule_04.ModalsForm
{
    partial class SheduleGroupForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_add = new System.Windows.Forms.Button();
            this.combo_classroom = new System.Windows.Forms.ComboBox();
            this.combo_lecturer = new System.Windows.Forms.ComboBox();
            this.combo_subject = new System.Windows.Forms.ComboBox();
            this.combo_time = new System.Windows.Forms.ComboBox();
            this.combo_day = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelUp = new System.Windows.Forms.Panel();
            this.deleteLink = new System.Windows.Forms.LinkLabel();
            this.reloadLink = new System.Windows.Forms.LinkLabel();
            this.nameForm = new System.Windows.Forms.Label();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.combo_classroom);
            this.panel1.Controls.Add(this.combo_lecturer);
            this.panel1.Controls.Add(this.combo_subject);
            this.panel1.Controls.Add(this.combo_time);
            this.panel1.Controls.Add(this.combo_day);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(593, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 546);
            this.panel1.TabIndex = 0;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(134, 320);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 17;
            this.btn_add.Text = "Добавить";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // combo_classroom
            // 
            this.combo_classroom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_classroom.FormattingEnabled = true;
            this.combo_classroom.Location = new System.Drawing.Point(134, 246);
            this.combo_classroom.Name = "combo_classroom";
            this.combo_classroom.Size = new System.Drawing.Size(162, 21);
            this.combo_classroom.TabIndex = 16;
            // 
            // combo_lecturer
            // 
            this.combo_lecturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_lecturer.FormattingEnabled = true;
            this.combo_lecturer.Location = new System.Drawing.Point(134, 206);
            this.combo_lecturer.Name = "combo_lecturer";
            this.combo_lecturer.Size = new System.Drawing.Size(162, 21);
            this.combo_lecturer.TabIndex = 15;
            // 
            // combo_subject
            // 
            this.combo_subject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_subject.FormattingEnabled = true;
            this.combo_subject.Location = new System.Drawing.Point(134, 166);
            this.combo_subject.Name = "combo_subject";
            this.combo_subject.Size = new System.Drawing.Size(162, 21);
            this.combo_subject.TabIndex = 14;
            // 
            // combo_time
            // 
            this.combo_time.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_time.FormattingEnabled = true;
            this.combo_time.Location = new System.Drawing.Point(134, 121);
            this.combo_time.Name = "combo_time";
            this.combo_time.Size = new System.Drawing.Size(162, 21);
            this.combo_time.TabIndex = 13;
            // 
            // combo_day
            // 
            this.combo_day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_day.FormattingEnabled = true;
            this.combo_day.Location = new System.Drawing.Point(134, 78);
            this.combo_day.Name = "combo_day";
            this.combo_day.Size = new System.Drawing.Size(162, 21);
            this.combo_day.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Аудитория";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Преподаватель";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Дисциплина";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Время";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "День недели";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Добавить занятие";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 45);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(593, 501);
            this.dataGridView1.TabIndex = 1;
            // 
            // panelUp
            // 
            this.panelUp.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelUp.Controls.Add(this.deleteLink);
            this.panelUp.Controls.Add(this.reloadLink);
            this.panelUp.Controls.Add(this.nameForm);
            this.panelUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUp.Location = new System.Drawing.Point(0, 0);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(593, 45);
            this.panelUp.TabIndex = 2;
            // 
            // deleteLink
            // 
            this.deleteLink.AutoSize = true;
            this.deleteLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.deleteLink.Location = new System.Drawing.Point(388, 16);
            this.deleteLink.Name = "deleteLink";
            this.deleteLink.Size = new System.Drawing.Size(63, 16);
            this.deleteLink.TabIndex = 3;
            this.deleteLink.TabStop = true;
            this.deleteLink.Text = "Удалить";
            this.deleteLink.VisitedLinkColor = System.Drawing.Color.Blue;
            this.deleteLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.deleteLink_LinkClicked);
            // 
            // reloadLink
            // 
            this.reloadLink.AutoSize = true;
            this.reloadLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reloadLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.reloadLink.Location = new System.Drawing.Point(310, 16);
            this.reloadLink.Name = "reloadLink";
            this.reloadLink.Size = new System.Drawing.Size(72, 16);
            this.reloadLink.TabIndex = 2;
            this.reloadLink.TabStop = true;
            this.reloadLink.Text = "Обновить";
            this.reloadLink.VisitedLinkColor = System.Drawing.Color.Blue;
            this.reloadLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.reloadLink_LinkClicked);
            // 
            // nameForm
            // 
            this.nameForm.AutoSize = true;
            this.nameForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameForm.Location = new System.Drawing.Point(13, 13);
            this.nameForm.Name = "nameForm";
            this.nameForm.Size = new System.Drawing.Size(108, 20);
            this.nameForm.TabIndex = 0;
            this.nameForm.Text = "Расписание";
            this.nameForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "id_row";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "День";
            this.Column1.MinimumWidth = 80;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 80;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "Время";
            this.Column3.MinimumWidth = 70;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Width = 70;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.FillWeight = 60F;
            this.Column4.HeaderText = "Занятие";
            this.Column4.MinimumWidth = 100;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.FillWeight = 25F;
            this.Column5.HeaderText = "Преподаватель";
            this.Column5.MinimumWidth = 70;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.Width = 110;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6.FillWeight = 15F;
            this.Column6.HeaderText = "Аудитория";
            this.Column6.MinimumWidth = 30;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column6.Width = 66;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "day";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // SheduleGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 546);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelUp);
            this.Controls.Add(this.panel1);
            this.Name = "SheduleGroupForm";
            this.Text = "SheduleGroupForm";
            this.Load += new System.EventHandler(this.SheduleGroupForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelUp.ResumeLayout(false);
            this.panelUp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ComboBox combo_classroom;
        private System.Windows.Forms.ComboBox combo_lecturer;
        private System.Windows.Forms.ComboBox combo_subject;
        private System.Windows.Forms.ComboBox combo_time;
        private System.Windows.Forms.ComboBox combo_day;
        private System.Windows.Forms.Panel panelUp;
        private System.Windows.Forms.LinkLabel deleteLink;
        private System.Windows.Forms.LinkLabel reloadLink;
        private System.Windows.Forms.Label nameForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}
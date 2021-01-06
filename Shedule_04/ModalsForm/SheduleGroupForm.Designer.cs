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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.combo_day = new System.Windows.Forms.ComboBox();
            this.combo_time = new System.Windows.Forms.ComboBox();
            this.combo_subject = new System.Windows.Forms.ComboBox();
            this.combo_lecturer = new System.Windows.Forms.ComboBox();
            this.combo_classroom = new System.Windows.Forms.ComboBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_clear);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(593, 546);
            this.dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Добавить занятие";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Дисциплина";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Время";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "День недели";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 343);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Преподаватель";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 383);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Аудитория";
            // 
            // combo_day
            // 
            this.combo_day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_day.FormattingEnabled = true;
            this.combo_day.Items.AddRange(new object[] {
            "Понедельник",
            "Вторник",
            "Среда",
            "Четверг",
            "Пятница",
            "Суббота",
            "Воскресенье"});
            this.combo_day.Location = new System.Drawing.Point(133, 212);
            this.combo_day.Name = "combo_day";
            this.combo_day.Size = new System.Drawing.Size(162, 21);
            this.combo_day.TabIndex = 12;
            // 
            // combo_time
            // 
            this.combo_time.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_time.FormattingEnabled = true;
            this.combo_time.Items.AddRange(new object[] {
            "08:30-10:00",
            "10:10-11:40",
            "12:20-13:50",
            "14:00-15:30",
            "15:40-17:10",
            "17:30-19:00"});
            this.combo_time.Location = new System.Drawing.Point(133, 255);
            this.combo_time.Name = "combo_time";
            this.combo_time.Size = new System.Drawing.Size(162, 21);
            this.combo_time.TabIndex = 13;
            // 
            // combo_subject
            // 
            this.combo_subject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_subject.FormattingEnabled = true;
            this.combo_subject.Location = new System.Drawing.Point(133, 300);
            this.combo_subject.Name = "combo_subject";
            this.combo_subject.Size = new System.Drawing.Size(162, 21);
            this.combo_subject.TabIndex = 14;
            // 
            // combo_lecturer
            // 
            this.combo_lecturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_lecturer.FormattingEnabled = true;
            this.combo_lecturer.Location = new System.Drawing.Point(133, 340);
            this.combo_lecturer.Name = "combo_lecturer";
            this.combo_lecturer.Size = new System.Drawing.Size(162, 21);
            this.combo_lecturer.TabIndex = 15;
            // 
            // combo_classroom
            // 
            this.combo_classroom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_classroom.FormattingEnabled = true;
            this.combo_classroom.Location = new System.Drawing.Point(133, 380);
            this.combo_classroom.Name = "combo_classroom";
            this.combo_classroom.Size = new System.Drawing.Size(162, 21);
            this.combo_classroom.TabIndex = 16;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(77, 493);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 17;
            this.btn_add.Text = "Добавить";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(192, 493);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 18;
            this.btn_clear.Text = "Сбросить";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // SheduleGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 546);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "SheduleGroupForm";
            this.Text = "SheduleGroupForm";
            this.Load += new System.EventHandler(this.SheduleGroupForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ComboBox combo_classroom;
        private System.Windows.Forms.ComboBox combo_lecturer;
        private System.Windows.Forms.ComboBox combo_subject;
        private System.Windows.Forms.ComboBox combo_time;
        private System.Windows.Forms.ComboBox combo_day;
    }
}
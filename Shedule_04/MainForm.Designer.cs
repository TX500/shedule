﻿namespace Shedule_04
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuMainForm = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sheduleMenuMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.facultyMenuMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.groupsMenuMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.lecturerMenuMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectMenuMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.classroomsMenuMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.panelDown = new System.Windows.Forms.Panel();
            this.menuMainForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMainForm
            // 
            this.menuMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справочникиToolStripMenuItem});
            this.menuMainForm.Location = new System.Drawing.Point(0, 0);
            this.menuMainForm.Name = "menuMainForm";
            this.menuMainForm.Size = new System.Drawing.Size(784, 24);
            this.menuMainForm.TabIndex = 0;
            this.menuMainForm.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuMainForm});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // exitMenuMainForm
            // 
            this.exitMenuMainForm.Name = "exitMenuMainForm";
            this.exitMenuMainForm.Size = new System.Drawing.Size(180, 22);
            this.exitMenuMainForm.Text = "Выход";
            this.exitMenuMainForm.Click += new System.EventHandler(this.exitMenuMainForm_Click);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sheduleMenuMainForm,
            this.facultyMenuMainForm,
            this.groupsMenuMainForm,
            this.lecturerMenuMainForm,
            this.subjectMenuMainForm,
            this.classroomsMenuMainForm});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // sheduleMenuMainForm
            // 
            this.sheduleMenuMainForm.Name = "sheduleMenuMainForm";
            this.sheduleMenuMainForm.Size = new System.Drawing.Size(196, 22);
            this.sheduleMenuMainForm.Text = "Расписания";
            this.sheduleMenuMainForm.Click += new System.EventHandler(this.sheduleMenuMainForm_Click);
            // 
            // facultyMenuMainForm
            // 
            this.facultyMenuMainForm.Name = "facultyMenuMainForm";
            this.facultyMenuMainForm.Size = new System.Drawing.Size(196, 22);
            this.facultyMenuMainForm.Text = "Факультеты";
            this.facultyMenuMainForm.Click += new System.EventHandler(this.facultyMenuMainForm_Click);
            // 
            // groupsMenuMainForm
            // 
            this.groupsMenuMainForm.Name = "groupsMenuMainForm";
            this.groupsMenuMainForm.Size = new System.Drawing.Size(196, 22);
            this.groupsMenuMainForm.Text = "Групппы";
            this.groupsMenuMainForm.Click += new System.EventHandler(this.groupsMenuMainForm_Click);
            // 
            // lecturerMenuMainForm
            // 
            this.lecturerMenuMainForm.Name = "lecturerMenuMainForm";
            this.lecturerMenuMainForm.Size = new System.Drawing.Size(196, 22);
            this.lecturerMenuMainForm.Text = "Преподаватели";
            this.lecturerMenuMainForm.Click += new System.EventHandler(this.lecturerMenuMainForm_Click);
            // 
            // subjectMenuMainForm
            // 
            this.subjectMenuMainForm.Name = "subjectMenuMainForm";
            this.subjectMenuMainForm.Size = new System.Drawing.Size(196, 22);
            this.subjectMenuMainForm.Text = "Учебные дисциплины";
            this.subjectMenuMainForm.Click += new System.EventHandler(this.subjectMenuMainForm_Click);
            // 
            // classroomsMenuMainForm
            // 
            this.classroomsMenuMainForm.Name = "classroomsMenuMainForm";
            this.classroomsMenuMainForm.Size = new System.Drawing.Size(196, 22);
            this.classroomsMenuMainForm.Text = "Аудитории";
            this.classroomsMenuMainForm.Click += new System.EventHandler(this.classroomsMenuMainForm_Click);
            // 
            // panelDown
            // 
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDown.Location = new System.Drawing.Point(0, 525);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(784, 36);
            this.panelDown.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.menuMainForm);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMainForm;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Курсовой проект - Расписание в ВУЗе";
            this.menuMainForm.ResumeLayout(false);
            this.menuMainForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMainForm;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuMainForm;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facultyMenuMainForm;
        private System.Windows.Forms.ToolStripMenuItem groupsMenuMainForm;
        private System.Windows.Forms.ToolStripMenuItem lecturerMenuMainForm;
        private System.Windows.Forms.ToolStripMenuItem subjectMenuMainForm;
        private System.Windows.Forms.ToolStripMenuItem classroomsMenuMainForm;
        private System.Windows.Forms.ToolStripMenuItem sheduleMenuMainForm;
        private System.Windows.Forms.Panel panelDown;
    }
}


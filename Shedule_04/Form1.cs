﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shedule_04
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void facultyMenuMainForm_Click(object sender, EventArgs e)
        {
            Form facultiForm = new FacultyForm();
            facultiForm.ShowDialog();
        }
    }
}

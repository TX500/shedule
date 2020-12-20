using System;
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
        Form facultiForm;
        private void facultyMenuMainForm_Click(object sender, EventArgs e)
        {
            if(facultiForm == null)
            {
                facultiForm = new FacultyForm();
                facultiForm.MdiParent = this;
                facultiForm.FormClosed += new FormClosedEventHandler(FacultiForm_FormClosed);
                facultiForm.Dock = DockStyle.Fill;
                facultiForm.Show();
            }
            else
            {
                facultiForm.Activate();
            }
            
            
        }

        private void FacultiForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            facultiForm = null;
            
            //throw new NotImplementedException();
        }
    }
}

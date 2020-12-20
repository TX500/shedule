using System;
using System.Windows.Forms;

namespace Shedule_04
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Дочерние формы

        Form sheduleForm;
        Form facultiForm;
        Form groupForm;
        Form lecturerForm;
        Form subjectForm;
        Form classroomForm;

        #endregion

        #region Обработчики открытия окон

        private void sheduleMenuMainForm_Click(object sender, EventArgs e)
        {
            if (sheduleForm == null)
            {
                sheduleForm = new SheduleForm();
                sheduleForm.MdiParent = this;
                sheduleForm.FormClosed += SheduleForm_FormClosed;
                sheduleForm.Dock = DockStyle.Fill;
                sheduleForm.Show();
            }
            else
            {
                sheduleForm.Activate();
            }
        }

        private void facultyMenuMainForm_Click(object sender, EventArgs e)
        {
            if (facultiForm == null)
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

        private void groupsMenuMainForm_Click(object sender, EventArgs e)
        {
            if (groupForm == null)
            {
                groupForm = new GroupForm();
                groupForm.MdiParent = this;
                groupForm.FormClosed += GroupForm_FormClosed;
                groupForm.Dock = DockStyle.Fill;
                groupForm.Show();
            }
            else
            {
                groupForm.Activate();
            }
        }

        private void lecturerMenuMainForm_Click(object sender, EventArgs e)
        {
            if (lecturerForm == null)
            {
                lecturerForm = new GroupForm();
                lecturerForm.MdiParent = this;
                lecturerForm.FormClosed += LecturerForm_FormClosed;
                lecturerForm.Dock = DockStyle.Fill;
                lecturerForm.Show();
            }
            else
            {
                lecturerForm.Activate();
            }
        }

        private void subjectMenuMainForm_Click(object sender, EventArgs e)
        {
            if (subjectForm == null)
            {
                subjectForm = new GroupForm();
                subjectForm.MdiParent = this;
                subjectForm.FormClosed += SubjectForm_FormClosed;
                subjectForm.Dock = DockStyle.Fill;
                subjectForm.Show();
            }
            else
            {
                subjectForm.Activate();
            }
        }

        private void classroomsMenuMainForm_Click(object sender, EventArgs e)
        {
            if (classroomForm == null)
            {
                classroomForm = new GroupForm();
                classroomForm.MdiParent = this;
                classroomForm.FormClosed += ClassroomForm_FormClosed;
                classroomForm.Dock = DockStyle.Fill;
                classroomForm.Show();
            }
            else
            {
                classroomForm.Activate();
            }
        }

        #endregion

        #region Обработчики закрытия окон

        private void SheduleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sheduleForm = null;
        }

        private void FacultiForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            facultiForm = null;
        }

        private void GroupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            groupForm = null;
        }

        private void LecturerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            lecturerForm = null;
        }

        private void SubjectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            subjectForm = null;
        }

        private void ClassroomForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            classroomForm = null;
        }

        #endregion
    }
}

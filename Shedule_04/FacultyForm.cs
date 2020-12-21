using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Shedule_04
{
    public partial class FacultyForm : Form
    {

        Form modalFaculty = new ModalsForm.ModalFaculty();

        public FacultyForm()
        {
            InitializeComponent();
        }
        
        SqlConnection connect = new SqlConnection(DB.connectString);
        
        private void facultyLoad()
        {
            string querieAll = @"SELECT * FROM faculty;";


            SqlCommand table = new SqlCommand(querieAll, connect);

            connect.Open();

            SqlDataReader reader = table.ExecuteReader();

            int i = 0;
            int N = 1;
            dataGridView1.Rows.Clear();

            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = N;
                dataGridView1[1, i].Value = reader[1];
                i++;
                N++;
            }
            reader.Close();
            connect.Close();
        }

        private void reloadLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            facultyLoad();
        }

        private void addLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModalsForm.ModalFaculty.isNewItem = true;
            modalFaculty.ShowDialog();
        }
    }
}

using System.Data.SqlClient;
using System.Windows.Forms;

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
                dataGridView1[0, i].Value = reader[0];            // id_row
                dataGridView1[1, i].Value = N;                    // №
                dataGridView1[2, i].Value = reader[1];
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

        private void deleteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //string delete = dataGridView1.SelectedCells[1].Value.ToString();
            //MessageBox.Show(delete);
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                int row = dataGridView1.SelectedRows[i].Index;
                MessageBox.Show(dataGridView1[0,row].Value.ToString());
            }
        }
    }
}

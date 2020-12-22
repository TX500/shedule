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
            // Получаем ИД записей и записываем их в массив ids
            string[] ids = new string[dataGridView1.SelectedRows.Count];

            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                int row = dataGridView1.SelectedRows[i].Index;
                ids[i] = dataGridView1[0, row].Value.ToString();
            }
            massDelete(ids);

        }

        private void massDelete(string[] ids)
        {
            string id = "(";
            for (int i = 0; i < ids.Length; i++)
            {
                if (i != ids.Length - 1)
                {
                    id += "'" + ids[i] + "',";
                }
                else
                {
                    id += "'" + ids[i] + "');";
                }
            }
            string querieMassDelete = @"DELETE FROM faculty WHERE id_faculty in " + id;

            if (MessageBox.Show("Вы действительно хотите выбранные записи? Данная операция необратима.", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    SqlCommand table = new SqlCommand(querieMassDelete, connect);

                    connect.Open();
                    SqlDataReader reader = table.ExecuteReader();
                    reader.Close();
                    connect.Close();
                    facultyLoad();
                }
                catch (SqlException ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            ModalsForm.ModalFaculty.idItem = dataGridView1[0, row].Value.ToString();
            ModalsForm.ModalFaculty.isNewItem = false;
            modalFaculty.ShowDialog();
        }
    }
}

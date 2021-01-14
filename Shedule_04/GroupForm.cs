using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shedule_04
{
    public partial class GroupForm : Form
    {
        Form modalGroup = new ModalsForm.ModalGroup();

        public GroupForm()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection(DB.connectString);

        private void tableLoad()
        {
            try
            {
                string querieAll = @"SELECT id_group, group_name, course, faculty_name FROM groups, faculty
                                    where faculty = id_faculty;";

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
                    dataGridView1[2, i].Value = reader[2];            // Курс  
                    dataGridView1[3, i].Value = reader[1];            // Группа  
                    dataGridView1[4, i].Value = reader[3];            // Факультет
                    i++;
                    N++;
                }
                reader.Close();
                connect.Close();
            }
            catch (SqlException ex)
            {
                connect.Close();
                MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
            }
        }

        private void addLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModalsForm.ModalGroup.isNewItem = true;
            modalGroup.FormClosed += new FormClosedEventHandler(modalGroup_FormClosed);
            modalGroup.ShowDialog();
        }

        private void reloadLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tableLoad();
        }

        private void deleteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string ids;
            int row = dataGridView1.SelectedRows[0].Index;
            ids = dataGridView1[0, row].Value.ToString();

            try
            {
                string querieMassDelete = @"DELETE FROM groups WHERE id_group = " + ids + ";";

                if (MessageBox.Show("Вы действительно хотите удалить выбранные записи? Данная операция необратима.", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand table = new SqlCommand(querieMassDelete, connect);

                        connect.Open();
                        SqlDataReader reader = table.ExecuteReader();
                        reader.Close();
                        connect.Close();
                        tableLoad();
                    }
                    catch (SqlException ex)
                    {
                        connect.Close();
                        if (ex.Number == 547) // Каскадное удаление
                        {
                            MessageBox.Show("Удаление невозможно. Некоторые записи используются в других документах");
                        }
                        else
                        {
                            MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                connect.Close();
                MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            ModalsForm.ModalGroup.idItem = dataGridView1[0, row].Value.ToString();
            ModalsForm.ModalGroup.isNewItem = false;
            modalGroup.ShowDialog();
        }

        private void GroupForm_Load(object sender, EventArgs e)
        {
            tableLoad();
        }

        private void modalGroup_FormClosed(object sender, FormClosedEventArgs e)
        {
            tableLoad();
        }
    }
}

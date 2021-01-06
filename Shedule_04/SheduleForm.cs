using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shedule_04
{
    public partial class SheduleForm : Form
    {
        ModalsForm.SheduleGroupForm shg = new ModalsForm.SheduleGroupForm();
        public SheduleForm()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection(DB.connectString);

        private void SheduleForm_Load(object sender, EventArgs e)
        {
            tableLoad();
            comboLoad();
        }

        private void tableLoad()
        {
            string querieAll = @"SELECT g.group_name, sh.semester, sh.year
                              FROM shedule_table sh join  groups g on sh.fk_group=g.id_group
                              group by g.group_name, sh.semester, sh.year;";

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
                dataGridView1[1, i].Value = reader[0];    //group        
                dataGridView1[2, i].Value = reader[1];    // semester
                dataGridView1[3, i].Value = reader[2];    // year
                i++;
                N++;
            }
            reader.Close();
            connect.Close();
        }

        private void comboLoad()
        {
            // Заполняем список групп
            try
            {
                string getComboGroup = @"SELECT group_name FROM groups;";
                SqlCommand table = new SqlCommand(getComboGroup, connect);
                connect.Open();
                SqlDataReader reader = table.ExecuteReader();
                if (combo_group.Items.Count > 0)
                {
                    combo_group.Items.Clear();
                }

                while (reader.Read())
                {
                    combo_group.Items.Add(reader[0].ToString());
                }
                connect.Close();
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
            shg.group = dataGridView1[1, row].Value.ToString();
            shg.semester = dataGridView1[2, row].Value.ToString();
            shg.year = dataGridView1[3, row].Value.ToString();
            shg.ShowDialog();
        }

        private void addLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            shg.isNewItem = true;
            shg.FormClosed += new FormClosedEventHandler(SheduleGroupForm_FormClosed);
            shg.ShowDialog();
        }

        private void reloadLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tableLoad();
        }

        private void deleteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Удаление не работает");
        }

        private void SheduleGroupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            tableLoad();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (combo_group.SelectedIndex != -1 && combo_semester.SelectedIndex != -1 && combo_year.SelectedIndex != -1)
            {
                try
                {
                    // Получить ИД выбранной группы
                    string idGroup;
                    string queryIdGroup = @"Select id_group From groups Where group_name = '" + combo_group.SelectedItem.ToString() + "'";
                    SqlCommand table = new SqlCommand(queryIdGroup, connect);
                    connect.Open();
                    SqlDataReader reader = table.ExecuteReader();
                    reader.Read();
                    idGroup = reader[0].ToString();
                    connect.Close();

                    // Проверка на дубль при добавлении

                    string queryCheck = @"SELECT id_shTable FROM shedule_table WHERE fk_group = '" + idGroup + "' AND semester = '" + combo_semester.SelectedItem.ToString() + "' AND year = '" + combo_year.SelectedItem.ToString() + "';";
                    SqlCommand tableCheck = new SqlCommand(queryCheck, connect);
                    connect.Open();
                    SqlDataReader reader2 = tableCheck.ExecuteReader();
                    string sh = "";
                    while (reader2.Read())
                    {
                        sh = reader2[0].ToString();
                    }
                    connect.Close();


                    // Добавляем расписание
                    if (sh == "")
                    {
                        string querieAdd = @"INSERT INTO shedule_table (fk_group, semester, year) values('" + idGroup + "', '" + combo_semester.SelectedItem.ToString() + "', '" + combo_year.SelectedItem.ToString() + "');";
                        SqlCommand insert = new SqlCommand(querieAdd, connect);
                        connect.Open();
                        insert.ExecuteNonQuery();
                        connect.Close();
                    }
                    else
                    {
                        MessageBox.Show("Такое расписание уже создано.");
                    }

                    tableLoad();

                }
                catch (SqlException ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
                }
            }
            else
            {
                MessageBox.Show("Заполните обязательные поля");
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                if(combo_group.SelectedIndex != -1 && combo_semester.SelectedIndex != -1 && combo_year.SelectedIndex != -1)
                {
                    string querieAll = @"SELECT g.group_name, sh.semester, sh.year
                               FROM shedule_table sh join  groups g on sh.fk_group=g.id_group
                               Where group_name = '" + combo_group.SelectedItem.ToString() + "'" +
                               "AND semester = '" + combo_semester.SelectedItem.ToString() + "' " +
                               "AND year = '" + combo_year.SelectedItem.ToString() + "'";

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
                        dataGridView1[1, i].Value = reader[0];    //group        
                        dataGridView1[2, i].Value = reader[1];    // semester
                        dataGridView1[3, i].Value = reader[2];    // year
                        i++;
                        N++;
                    }
                    reader.Close();
                    connect.Close();
                }
                else
                {
                    MessageBox.Show("Заполните обязательные поля");
                }
            }
            catch(SqlException ex)
            {
                connect.Close();
                MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
            }
            
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            tableLoad();
            combo_group.SelectedIndex = -1;
            combo_semester.SelectedIndex = -1;
            combo_year.SelectedIndex = -1;
        }
    }
}

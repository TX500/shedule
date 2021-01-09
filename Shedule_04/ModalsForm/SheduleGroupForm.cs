using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shedule_04.ModalsForm
{
    public partial class SheduleGroupForm : Form
    {

        public string group;
        public string semester;
        public string year;
        public string idGroup;

        private string[] days = new string[]
        {
            "Понедельник",
            "Вторник",
            "Среда",
            "Четверг",
            "Пятница",
            "Суббота",
            "Воскресенье"
        };

        private string[] times = new string[]
        {
            "08:30-10:00",
            "10:10-11:40",
            "12:20-13:50",
            "14:00-15:30",
            "15:40-17:10",
            "17:30-19:00"
        };

        SqlConnection connect = new SqlConnection(DB.connectString);

        public SheduleGroupForm()
        {
            InitializeComponent();
        }

        private void SheduleGroupForm_Load(object sender, EventArgs e)
        {
            comboLoad();
            tableLoad();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //Проверяем
            try
            {

            }
            catch (SqlException ex)
            {
                connect.Close();
                MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
            }
            //Добавляем
            try
            {
                string getSubject = @"SELECT id_subject From subject WHERE subject_name = '" + combo_subject.SelectedItem.ToString() + "';";
                SqlCommand tableSubject = new SqlCommand(getSubject, connect);
                connect.Open();
                SqlDataReader reader1 = tableSubject.ExecuteReader();
                reader1.Read();
                string idSubject = reader1[0].ToString();
                reader1.Close();

                string getClassroom = @"SELECT id_classroom From classroom WHERE classroom_name = '" + combo_classroom.SelectedItem + "';";
                SqlCommand tableClassroom = new SqlCommand(getClassroom, connect);
                SqlDataReader reader2 = tableClassroom.ExecuteReader();
                reader2.Read();
                string idClassroom = reader2[0].ToString();
                reader2.Close();

                string getLecturer = @"SELECT id_lecturer From lecturer WHERE surname = '" + combo_lecturer.SelectedItem + "';";
                SqlCommand tableLecturer = new SqlCommand(getLecturer, connect);
                SqlDataReader reader3 = tableLecturer.ExecuteReader();
                reader3.Read();
                string idLecturer = reader3[0].ToString();
                reader3.Close();

                string addTime = @"Insert Into shedule_time (day, task_time, fk_subject, fk_classroom, fk_lecturer) VALUES
                ('" + combo_day.SelectedItem + "', '" + combo_time.SelectedItem + "', '" + idSubject + "', '" + idClassroom + "', '" + idLecturer + "')";
                SqlCommand insert = new SqlCommand(addTime, connect);
                insert.ExecuteNonQuery();

                string getIdSh_Time = @"Select TOP(1) id_shTime From shedule_time Order by id_shTime desc";
                SqlCommand tableTime = new SqlCommand(getIdSh_Time, connect);
                SqlDataReader reader4 = tableTime.ExecuteReader();
                reader4.Read();
                string idTime = reader4[0].ToString();
                reader4.Close();

                string addInTable = @"Insert Into shedule_table (fk_group, shed_time, semester, year) VALUES
                ('" + idGroup + "', '" + idTime + "', '" + semester + "', '" + year + "')";
                SqlCommand insert2 = new SqlCommand(addInTable, connect);
                insert2.ExecuteNonQuery();

                connect.Close();
                tableLoad();
            }
            catch (SqlException ex)
            {
                connect.Close();
                MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка555.");
            }

        }

        private void comboLoad()
        {
            combo_day.DataSource = days;
            combo_time.DataSource = times;

            try
            {
                string getSubject = @"SELECT subject_name FROM subject;";
                SqlCommand tableSubject = new SqlCommand(getSubject, connect);
                connect.Open();
                SqlDataReader reader1 = tableSubject.ExecuteReader();
                combo_subject.Items.Clear();

                while (reader1.Read())
                {
                    combo_subject.Items.Add(reader1[0].ToString());
                }
                connect.Close();

                string getLecturer = @"SELECT surname FROM lecturer;";
                SqlCommand tableLecturer = new SqlCommand(getLecturer, connect);
                connect.Open();
                SqlDataReader reader2 = tableLecturer.ExecuteReader();
                combo_lecturer.Items.Clear();

                while (reader2.Read())
                {
                    combo_lecturer.Items.Add(reader2[0].ToString());
                }
                connect.Close();

                string getClassroom = @"SELECT classroom_name FROM classroom;";
                SqlCommand tableClassroom = new SqlCommand(getClassroom, connect);
                connect.Open();
                SqlDataReader reader3 = tableClassroom.ExecuteReader();
                combo_classroom.Items.Clear();

                while (reader3.Read())
                {
                    combo_classroom.Items.Add(reader3[0].ToString());
                }
                connect.Close();
            }
            catch (SqlException ex)
            {
                connect.Close();
                MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
            }
        }

        private void tableLoad()
        {
            // Получаем все ИД квантов расписания
            List<string> ids = new List<string>();
            try
            {
                string gr = @"select id_group From groups where group_name = '" + group + "'";
                SqlCommand table1 = new SqlCommand(gr, connect);
                connect.Open();
                SqlDataReader reader1 = table1.ExecuteReader();
                reader1.Read();
                string idGroup = reader1[0].ToString();
                connect.Close();

                string getIds = @"SELECT shed_time, id_group
                                FROM shedule_table JOIN groups on fk_group = id_group
                                WHERE year = '" + year + "' AND semester = '" + semester + "' AND id_group = '" + idGroup + "'";
                SqlCommand table = new SqlCommand(getIds, connect);
                connect.Open();
                SqlDataReader reader = table.ExecuteReader();
                while (reader.Read())
                {
                    ids.Add(reader[0].ToString());
                }
                connect.Close();

            }
            catch (SqlException ex)
            {
                connect.Close();
                MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
            }

            //Заполняем таблицу с расписанием
            try
            {
                string[] queryIds = ids.ToArray();
                string id = "(";

                for (int j = 0; j < queryIds.Length; j++)
                {
                    if (j != queryIds.Length - 1)
                    {
                        id += "'" + ids[j] + "',";
                    }
                    else
                    {
                        id += "'" + ids[j] + "');";
                    }
                }
                if (ids.Count != 0)
                {
                    string querieAll = @"select id_shTime, day, task_time, subject_name, surname, classroom_name 
	                               from shedule_time JOIN subject on fk_subject = id_subject JOIN classroom on fk_classroom = id_classroom JOIN lecturer on fk_lecturer = id_lecturer
	                               where id_shTime in " + id + " ";

                    SqlCommand table = new SqlCommand(querieAll, connect);

                    connect.Open();

                    SqlDataReader reader = table.ExecuteReader();

                    int i = 0;
                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, i].Value = reader[0]; //id_row
                        dataGridView1[1, i].Value = reader[1];
                        dataGridView1[2, i].Value = reader[2];
                        dataGridView1[3, i].Value = reader[3];
                        dataGridView1[4, i].Value = reader[4];
                        dataGridView1[5, i].Value = reader[5];
                        i++;
                    }
                    reader.Close();
                    connect.Close();
                }
                else
                {
                    dataGridView1.Rows.Clear();
                }

            }
            catch (SqlException ex)
            {
                connect.Close();
                MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
            }
            lab_IdGroup.Text = idGroup;
            lab_group.Text = group;
            lab_sem.Text = semester;
            lab_year.Text = year;
        }

        private void reloadLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tableLoad();
        }

        private void deleteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int row = dataGridView1.SelectedRows[0].Index;
            string ids = dataGridView1[0, row].Value.ToString();

            string delete = @"DELETE FROM shedule_time 
                            WHERE id_shTime = '" + ids + "'";

            if (MessageBox.Show("Вы действительно хотите удалить выбранные записи? Данная операция необратима.", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    SqlCommand table = new SqlCommand(delete, connect);

                    connect.Open();
                    SqlDataReader reader2 = table.ExecuteReader();
                    reader2.Close();
                    connect.Close();
                    tableLoad();
                }
                catch (SqlException ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
                }
            }
        }
    }
}

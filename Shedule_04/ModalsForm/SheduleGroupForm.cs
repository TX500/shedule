using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


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
            //tableLoad();
            tableLoad2();
        }

        private void tableLoad2()
        {
            #region ADD Rows
            //add empty rows
            dataGridView1.Rows.Clear();
            for (int i = 0; i < 43; i++)
            {
                dataGridView1.Rows.Add();
            }
            dataGridView1.Columns[3].HeaderText = group;

            // add faculty, group, days, times
            dataGridView1[3, 0].Value = "" + semester + " семестр " + year + " года \n" +
                "Группа " + group + "";
            int k = 0;
            for (int i = 1; i < 43; i += 6)
            {
                dataGridView1[1, i].Value = days[k];
                k++;
            }
            for (int i = 1; i < 43; i++)
            {
                if (k < 6)
                {
                    dataGridView1[2, i].Value = times[k];
                    k++;
                }
                else
                {
                    k = 0;
                    dataGridView1[2, i].Value = times[k];
                    k++;
                }
            }
            int s = 0, t = 0;
            for (int i = 1; i < 43; i++)
            {
                //dataGridView1[3, i].Value = s.ToString();
                if (t > 5)
                {
                    t = 0;
                    s++;
                    dataGridView1[4, i].Value = s.ToString();
                    t++;
                }
                else
                {
                    dataGridView1[4, i].Value = s.ToString();
                    t++;
                }
            }
            #endregion

            #region ADD Items
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
            if(ids.Count != 0)
            {
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
                            id += "'" + ids[j] + "')";
                        }
                    }


                    string querieAll = @"select id_shTime, day, task_time, subject_name, surname, classroom_name 
	                               from shedule_time JOIN subject on fk_subject = id_subject JOIN classroom on fk_classroom = id_classroom JOIN lecturer on fk_lecturer = id_lecturer
	                               where id_shTime in " + id + " order by day, task_time ";

                    SqlCommand table = new SqlCommand(querieAll, connect);

                    connect.Open();

                    SqlDataReader reader = table.ExecuteReader();

                    while (reader.Read())
                    {
                        // Find row

                        for (int jj = 1; jj < 43; jj += 6)
                        {
                            if (reader[1].ToString() == dataGridView1[4, jj].Value.ToString())
                            {
                                for (int kk = jj; kk < (jj += 6); kk++)
                                {

                                    if (reader[2].ToString() == dataGridView1[2, kk].Value.ToString())
                                    {
                                        dataGridView1[0, kk].Value = reader[0];
                                        dataGridView1[3, kk].Value = reader[3] + ", " + reader[5] + ", " + reader[4]; ;
                                        //dataGridView1[4, kk].Value = reader[4];
                                        //dataGridView1[5, kk].Value = reader[5];
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    reader.Close();
                    connect.Close();
                }
                catch (SqlException ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка222.");
                }
            }
            
            #endregion
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
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


                // --------------------ПРОВЕРКИ------------------------------


                // Проверка на дубль занятия для группы в одно и то же время
                string checkTask = @"SELECT id_shTime
                                   FROM shedule_time 
                                   JOIN shedule_table ON shed_time = id_shTime 
                                   JOIN groups ON fk_group = id_group
                                   WHERE 
                                   year = '" + year + "' " +
                                   "AND semester = '" + semester + "' " +
                                   "AND id_group = '" + idGroup + "' " +
                                   "AND day = '" + combo_day.SelectedIndex.ToString() + "' " +
                                   "AND task_time = '" + combo_time.SelectedItem.ToString() + "'";

                SqlCommand tableCheckTask = new SqlCommand(checkTask, connect);
                SqlDataReader reader10 = tableCheckTask.ExecuteReader();
                string idTask = null;
                string idLect = null;
                string gr = null;
                string idClass = null;


                while (reader10.Read())
                {
                    idTask = reader10[0].ToString();
                }
                reader10.Close();
                if (idTask != null)
                {
                    connect.Close();
                    MessageBox.Show("Добавление невозможно. В этот временной отрезок уже назначено занятие. Пожалуйста, выберите другой день или время.");
                }
                else
                {
                    // Проверка на дубль для преподавателя
                    string checkLecturer = @"SELECT classroom_name, group_name
                                           FROM shedule_time 
                                           JOIN shedule_table on shed_time = id_shTime 
                                           JOIN lecturer on fk_lecturer = id_lecturer 
                                           JOIN classroom on fk_classroom = id_classroom
                                           JOIN groups on fk_group = id_group
                                           WHERE 
                                           year = '" + year + "' " +
                                           "AND semester = '" + semester + "' " +
                                           "AND day = '" + combo_day.SelectedIndex.ToString() + "' " +
                                           "AND task_time = '" + combo_time.SelectedItem.ToString() + "' " +
                                           "AND surname = '" + combo_lecturer.SelectedItem.ToString() + "'";

                    SqlCommand tableCheckLecturer = new SqlCommand(checkLecturer, connect);
                    SqlDataReader reader11 = tableCheckLecturer.ExecuteReader();
                    while (reader11.Read())
                    {
                        idLect = reader11[0].ToString();
                        gr = reader11[1].ToString();
                    }
                    reader11.Close();
                    if (idLect != null)
                    {
                        connect.Close();
                        MessageBox.Show("Добавление невозможно. У преподавателя уже назначено занятие в аудитории " + idLect + ", у группы " + gr);
                    }
                    else
                    {
                        // Проверка на дубль для аудитории
                        string checkClassroom = @"SELECT group_name
                                                FROM shedule_time 
                                                JOIN shedule_table on shed_time = id_shTime 
                                                JOIN classroom on fk_classroom = id_classroom 
                                                JOIN groups on fk_group = id_group
                                                WHERE 
                                                year = '" + year + "' " +
                                                "AND semester = '" + semester + "' " +
                                                "AND classroom_name = '" + combo_classroom.SelectedItem.ToString() + "' " +
                                                "AND day = '" + combo_day.SelectedIndex.ToString() + "' " +
                                                "AND task_time = '" + combo_time.SelectedItem.ToString() + "'";

                        SqlCommand tableCheckClassroom = new SqlCommand(checkClassroom, connect);
                        SqlDataReader reader12 = tableCheckClassroom.ExecuteReader();
                        while (reader12.Read())
                        {
                            idClass = reader12[0].ToString();
                        }
                        reader12.Close();
                        if (idClass != null)
                        {
                            connect.Close();
                            MessageBox.Show("Добавление невозможно. Аудитория назначена для группы " + idClass);
                        }
                    }
                }


                // Если все ок, то разрешаем добавить
                if (idTask == null && idLect == null && idClass == null)
                {


                    string addTime = @"Insert Into shedule_time (day, task_time, fk_subject, fk_classroom, fk_lecturer) VALUES
                                    ('" + combo_day.SelectedIndex + "', " +
                                    "'" + combo_time.SelectedItem + "', " +
                                    "'" + idSubject + "', '" + idClassroom + "', '" + idLecturer + "')";
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
                }
                connect.Close();
                //tableLoad();
                tableLoad2();
            }
            catch (SqlException ex)
            {
                connect.Close();
                MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
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
                        id += "'" + ids[j] + "')";
                    }
                }
                if (ids.Count != 0)
                {
                    string querieAll = @"select id_shTime, day, task_time, subject_name, surname, classroom_name 
	                               from shedule_time JOIN subject on fk_subject = id_subject JOIN classroom on fk_classroom = id_classroom JOIN lecturer on fk_lecturer = id_lecturer
	                               where id_shTime in " + id + " order by day, task_time ";

                    SqlCommand table = new SqlCommand(querieAll, connect);

                    connect.Open();

                    SqlDataReader reader = table.ExecuteReader();

                    int i = 0;
                    dataGridView1.Rows.Clear();


                    while (reader.Read())
                    {

                        dataGridView1.Rows.Add();
                        dataGridView1[0, i].Value = reader[0]; //id_row

                        // Сортировка дня недели и отображение
                        int nameOfDay = Int32.Parse(reader[1].ToString());
                        dataGridView1[1, i].Value = days[nameOfDay];

                        dataGridView1[2, i].Value = reader[2];
                        dataGridView1[3, i].Value = (reader[3] + ", " + reader[4] + ", " + reader[5]);
                       // dataGridView1[4, i].Value = reader[4];
                       // dataGridView1[5, i].Value = reader[5];
                        i++;
                    }
                    reader.Close();
                    connect.Close();

                    int j = dataGridView1.Rows.Count - 1;
                    while (j != 0)
                    {
                        if (j != 0 && dataGridView1[1, j].Value.ToString() == dataGridView1[1, j - 1].Value.ToString())
                        {
                            dataGridView1[1, j].Value = "";
                        }
                        j--;
                    }
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
        }

        private void reloadLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //tableLoad();
            tableLoad2();
        }

        private void deleteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int row = dataGridView1.SelectedRows[0].Index;
            if (dataGridView1[0, row].Value != null)
            {
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
                        //tableLoad();
                        tableLoad2();
                    }
                    catch (SqlException ex)
                    {
                        connect.Close();
                        MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
                    }
                }
            }
        }

        private void printLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Excel.Application excelapp = new Excel.Application();
           // Object missing = Type.Missing;
            Excel.Workbook workbook = excelapp.Workbooks.Add(Type.Missing);

            excelapp.Columns[1].ColumnWidth = 13;
            excelapp.Columns[2].ColumnWidth = 11;
            excelapp.Columns[3].ColumnWidth = 50;

            excelapp.Cells[1, 3].WrapText = true;
            excelapp.Cells[1, 3] = "Расписание "+year + " "+ semester+" семестр";
            excelapp.Cells[1, 3].Font.Bold = true;
            excelapp.Cells[1, 3].Font.Size = 18;

            excelapp.Cells[2, 3].WrapText = true;
            excelapp.Cells[2, 3] = group;
            excelapp.Cells[2, 3].Font.Bold = true;
            excelapp.Cells[2, 3].Font.Size = 16;
            excelapp.Cells[2, 3].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                excelapp.Cells[i, 3].WrapText = true;

                excelapp.Cells[i + 2, 1] = dataGridView1[1, i].Value;
                excelapp.Cells[i + 2, 2] = dataGridView1[2, i].Value;
                excelapp.Cells[i + 2, 3] = dataGridView1[3, i].Value;
            }
            excelapp.Visible = true;
            
        }
    }

}

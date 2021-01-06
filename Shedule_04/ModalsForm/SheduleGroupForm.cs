﻿using System;
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
        //public bool isNewItem;

        SqlConnection connect = new SqlConnection(DB.connectString);

        public SheduleGroupForm()
        {
            InitializeComponent();
        }

        private void SheduleGroupForm_Load(object sender, EventArgs e)
        {
            // Заполняем комбобоксы
            comboLoad();
            //Заполняем таблицу
            tableLoad();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //Проверяем

            //Добавляем


        }

        private void comboLoad()
        {
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
                string [] queryIds = ids.ToArray();
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


                string querieAll = @"select day, task_number, subject_name, classroom_name, surname
	                               from shedule_time JOIN subject on fk_subject = id_subject JOIN classroom on fk_classroom = id_classroom JOIN lecturer on fk_lecturer = id_lecturer
	                               where id_shTime in "+id+" ";

                SqlCommand table = new SqlCommand(querieAll, connect);

                connect.Open();

                SqlDataReader reader = table.ExecuteReader();

                int i = 0;
                int N = 1;
                dataGridView1.Rows.Clear();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, i].Value = reader[0];            
                    dataGridView1[1, i].Value = reader[1];                    
                    dataGridView1[3, i].Value = reader[2];              
                    dataGridView1[4, i].Value = reader[4];              
                    dataGridView1[5, i].Value = reader[3];            
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

        private void reloadLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tableLoad();
        }

        private void deleteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Удаление не работает");
        }
    }
}

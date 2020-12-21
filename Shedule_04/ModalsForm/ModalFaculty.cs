﻿using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shedule_04.ModalsForm
{
    public partial class ModalFaculty : Form
    {
        public static bool isNewItem;

        public ModalFaculty()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection(DB.connectString);

        private void cancelNewFaculty_Click(object sender, EventArgs e)
        {
            if (textBoxAddFaculty.Text.Length == 0 && isNewItem == true)
            {
                this.Close();
                isNewItem = false;
            }
            else
            {
                if (MessageBox.Show("Вы действительно хотите закрыть окно? Изменения не будут применены", "Отмена", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    textBoxAddFaculty.Text = "";
                    this.Close();
                    isNewItem = false;
                }
            }
        }

        private void addNewFaculty_Click(object sender, EventArgs e)
        {
            //Добавить новую запись

            if (textBoxAddFaculty.Text == "")
            {
                MessageBox.Show("Заполните обязательные поля");
            }
            else
            {
                try
                {
                    string querieAdd = @"INSERT INTO faculty (faculty_name) values('" + textBoxAddFaculty.Text + "');";
                    SqlCommand insert = new SqlCommand(querieAdd, connect);
                    connect.Open();
                    insert.ExecuteNonQuery();
                    connect.Close();
                    textBoxAddFaculty.Text = "";
                    this.Close();
                }
                catch (SqlException ex)
                {
                    connect.Close();
                    if (ex.Number == 2627) // Проверка уникального значения
                    {
                        MessageBox.Show("Данное имя уже используется.");
                    }
                    else
                    {
                        MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
                    }
                }
            }
        }

        private void textBoxAddFaculty_TextChanged(object sender, EventArgs e)
        {
            if(textBoxAddFaculty.Text.Length == 1 && textBoxAddFaculty.Text.Contains(" "))
            {
                textBoxAddFaculty.Text = "";
            }
        }
    }
}

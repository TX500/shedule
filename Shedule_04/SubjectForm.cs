﻿using System;
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
    public partial class SubjectForm : Form
    {

        Form modalSubject = new ModalsForm.ModalSubject();

        public SubjectForm()
        {
            InitializeComponent();
            modalSubject.FormClosed += new FormClosedEventHandler(modalSubject_FormClosed);

        }

        SqlConnection connect = new SqlConnection(DB.connectString);

        private void tableLoad()
        {
            try
            {
                string querieAll = @"SELECT * FROM subject;";

                SqlCommand table = new SqlCommand(querieAll, connect);

                connect.Open();

                SqlDataReader reader = table.ExecuteReader();

                int i = 0;
                int N = 1;
                dataGridView1.Rows.Clear();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, i].Value = reader[0];              // id_row
                    dataGridView1[1, i].Value = N;                      // №
                    dataGridView1[2, i].Value = reader[1];              // subject_name
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
            ModalsForm.ModalSubject.isNewItem = true;
            modalSubject.ShowDialog();
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
                string querieMassDelete = @"DELETE FROM subject WHERE id_subject = " + ids + ";";

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
            ModalsForm.ModalSubject.idItem = dataGridView1[0, row].Value.ToString();
            ModalsForm.ModalSubject.isNewItem = false;
            modalSubject.ShowDialog();
        }

        private void SubjectForm_Load(object sender, EventArgs e)
        {
            tableLoad();
        }

        private void modalSubject_FormClosed(object sender, FormClosedEventArgs e)
        {
            tableLoad();
        }
    }
}

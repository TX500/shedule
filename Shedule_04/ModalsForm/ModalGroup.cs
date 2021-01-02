using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shedule_04.ModalsForm
{
    public partial class ModalGroup : Form
    {
        public static bool isNewItem;

        public static string idItem;

        string oldName;

        public ModalGroup()
        {
            InitializeComponent();
            //comboBox1.SelectedIndex = -1;
        }
        SqlConnection connect = new SqlConnection(DB.connectString);

        private void ModalGroup_Load(object sender, EventArgs e)
        {
            // Заполняем список факультетов
            try
            {
                string getFaculty = @"SELECT faculty_name FROM faculty;";
                SqlCommand table = new SqlCommand(getFaculty, connect);
                connect.Open();
                SqlDataReader reader = table.ExecuteReader();
                if (comboBox2.Items.Count > 0)
                {
                    comboBox2.Items.Clear();
                }
                   
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader[0].ToString());
                }
                
                connect.Close();
            }
            catch (SqlException ex)
            {
                connect.Close();
                MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
            }

            if (isNewItem == false)
            {
                // Получаем значение для поля по ИД
                try
                {
                    string updateItemName = @"SELECT group_name, course, faculty_name FROM groups, faculty 
                    WHERE id_group = " + idItem + "AND faculty = id_faculty;";
                    SqlCommand table = new SqlCommand(updateItemName, connect);
                    connect.Open();
                    SqlDataReader reader = table.ExecuteReader();
                    reader.Read();
                    textBoxName.Text = reader[0].ToString();
                    comboBox1.SelectedItem = reader[1].ToString();
                    comboBox2.SelectedItem = reader[2];

                    oldName = textBoxName.Text;
                    connect.Close();
                }
                catch (SqlException ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
                }
            }
            else
            {
                textBoxName.Text = oldName = "";
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length == 1 && textBoxName.Text.Contains(" "))
            {
                textBoxName.Text = "";
            }
            if (textBoxName.Text.IndexOf(" ") == 0)
            {
                textBoxName.Text = textBoxName.Text.Substring(1);
                textBoxName.SelectionStart = textBoxName.Text.Length;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {

        }
    }
}

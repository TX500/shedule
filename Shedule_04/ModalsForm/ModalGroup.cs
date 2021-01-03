using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shedule_04.ModalsForm
{
    public partial class ModalGroup : Form
    {
        public static bool isNewItem;

        public static string idItem;

        string oldName, oldCourse, oldFaculty;

        public ModalGroup()
        {
            InitializeComponent();
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
                    oldCourse = comboBox1.SelectedItem.ToString();
                    oldFaculty = comboBox2.SelectedItem.ToString();
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
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
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
            if (textBoxName.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Заполните обязательные поля");
            }
            else
            {
                while (textBoxName.Text[textBoxName.Text.Length - 1] == ' ')
                {
                    textBoxName.Text = textBoxName.Text.Substring(0, textBoxName.Text.Length - 1);
                }
            }

            if (isNewItem == true && textBoxName.Text != "" && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {

                try
                {
                    string getIdFaculty = @"SELECT id_faculty FROM faculty WHERE faculty_name = '" + comboBox2.SelectedItem.ToString() + "';";
                    SqlCommand table = new SqlCommand(getIdFaculty, connect);
                    connect.Open();
                    SqlDataReader reader = table.ExecuteReader();
                    reader.Read();
                    string idFaculty = reader[0].ToString();
                    connect.Close();

                    string querieAdd = @"INSERT INTO groups (group_name, course, faculty) values('" + textBoxName.Text + "', '" + comboBox1.SelectedItem.ToString() + "', '" + idFaculty + "');";
                    SqlCommand insert = new SqlCommand(querieAdd, connect);
                    connect.Open();
                    insert.ExecuteNonQuery();
                    connect.Close();
                    textBoxName.Text = "";
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
            if (textBoxName.Text == "")
            {
            }
            else if (isNewItem == false && (oldName != textBoxName.Text || oldCourse != comboBox1.SelectedItem.ToString() || oldFaculty != comboBox2.SelectedItem.ToString()))
            {
                if (MessageBox.Show("Вы действительно хотите внести изменения? Данная операция необратима.", "Изменение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string getID = @"SELECT id_faculty FROM faculty WHERE faculty_name = '"+comboBox2.SelectedItem.ToString()+"'";
                        SqlCommand table = new SqlCommand(getID, connect);
                        connect.Open();
                        SqlDataReader reader = table.ExecuteReader();
                        reader.Read();
                        string idFaculty = reader[0].ToString();
                        connect.Close();

                        string queiryUpdate = @"UPDATE groups SET group_name = '" + textBoxName.Text + "', course = '" + comboBox1.SelectedItem.ToString() + "', faculty = '" + idFaculty +"' WHERE id_group ='" + idItem + "'";
                        SqlCommand update = new SqlCommand(queiryUpdate, connect);
                        connect.Open();
                        update.ExecuteNonQuery();
                        connect.Close();
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
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length == 0 && isNewItem == true && comboBox1.SelectedIndex == -1 && comboBox2.SelectedIndex == -1)
            {
                this.Close();
                isNewItem = false;
            }
            else
            {
                if (oldName != textBoxName.Text || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox1.SelectedItem.ToString() != oldCourse || comboBox2.SelectedItem.ToString() != oldFaculty)
                {
                    if (MessageBox.Show("Вы действительно хотите закрыть окно? Изменения не будут применены", "Отмена", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        textBoxName.Text = "";
                        this.Close();
                        isNewItem = false;
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}

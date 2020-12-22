using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shedule_04.ModalsForm
{
    public partial class ModalFaculty : Form
    {
        public static bool isNewItem;

        public static string idItem;

        string oldName;

        public ModalFaculty()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection(DB.connectString);

        private void cancel_Click(object sender, EventArgs e)
        {
            if (textBoxAddFaculty.Text.Length == 0 && isNewItem == true)
            {
                this.Close();
                isNewItem = false;
            }
            else
            {
                if (oldName != textBoxAddFaculty.Text)
                {
                    if (MessageBox.Show("Вы действительно хотите закрыть окно? Изменения не будут применены", "Отмена", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        textBoxAddFaculty.Text = "";
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

        private void save_Click(object sender, EventArgs e)
        {

            if (textBoxAddFaculty.Text == "")
            {
                MessageBox.Show("Заполните обязательные поля");
            }
            else 
            {
                while(textBoxAddFaculty.Text[textBoxAddFaculty.Text.Length - 1] == ' ')
                {
                    textBoxAddFaculty.Text = textBoxAddFaculty.Text.Substring(0, textBoxAddFaculty.Text.Length-1);
                }
            }
            
            if (isNewItem == true && textBoxAddFaculty.Text != "")
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
            
            if (isNewItem == false && oldName != textBoxAddFaculty.Text)
            {
                if (MessageBox.Show("Вы действительно хотите внести изменения? Данная операция необратима.", "Изменение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string queiryUpdate = @"UPDATE faculty SET faculty_name='" + textBoxAddFaculty.Text + "' WHERE id_faculty ='" + idItem + "'";
                        SqlCommand update = new SqlCommand(queiryUpdate, connect);
                        connect.Open();
                        update.ExecuteNonQuery();
                        connect.Close();
                        this.Close();
                    }
                    catch (SqlException ex)
                    {
                        connect.Close();
                        MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
                    }
                }
            }
            
            if(isNewItem == false && oldName == textBoxAddFaculty.Text)
            {
                this.Close();
            }
        }

        private void textBoxAddFaculty_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAddFaculty.Text.Length == 1 && textBoxAddFaculty.Text.Contains(" "))
            {
                textBoxAddFaculty.Text = "";
            }
            if (textBoxAddFaculty.Text.IndexOf(" ") == 0)
            {
                textBoxAddFaculty.Text = textBoxAddFaculty.Text.Substring(1);
                textBoxAddFaculty.SelectionStart = textBoxAddFaculty.Text.Length;
            }
        }

        private void ModalFaculty_Load(object sender, EventArgs e)
        {
            if (isNewItem == false)
            {
                // Получаем значение для поля по ИД
                try
                {
                    string updateItemName = @"SELECT faculty_name FROM faculty WHERE id_faculty = " + idItem + ";";
                    SqlCommand table = new SqlCommand(updateItemName, connect);
                    connect.Open();
                    SqlDataReader reader = table.ExecuteReader();
                    reader.Read();
                    textBoxAddFaculty.Text = reader[0].ToString();
                    oldName = textBoxAddFaculty.Text;
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
                textBoxAddFaculty.Text = oldName = "";
            }
        }
    }
}

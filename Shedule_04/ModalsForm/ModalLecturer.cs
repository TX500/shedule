using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shedule_04.ModalsForm
{
    public partial class ModalLecturer : Form
    {

        public static bool isNewItem;

        public static string idItem;

        string oldName;

        public ModalLecturer()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection(DB.connectString);

        private void ModalLecturer_Load(object sender, EventArgs e)
        {
            if (isNewItem == false)
            {
                // Получаем значение для поля по ИД
                try
                {
                    string updateItemName = @"SELECT surname, name, middle_name FROM lecturer WHERE id_lecturer = " + idItem + ";";
                    SqlCommand table = new SqlCommand(updateItemName, connect);
                    connect.Open();
                    SqlDataReader reader = table.ExecuteReader();
                    reader.Read();
                    textBoxSurname.Text = reader[0].ToString();
                    textBoxName.Text = reader[1].ToString();
                    textBoxMiddlename.Text = reader[2].ToString();
                    oldName = textBoxSurname.Text + textBoxName.Text + textBoxMiddlename.Text;
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
                textBoxSurname.Text = textBoxName.Text = textBoxMiddlename.Text = oldName = "";
            }
        }

        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSurname.Text.Length == 1 && textBoxSurname.Text.Contains(" "))
            {
                textBoxSurname.Text = "";
            }
            if (textBoxSurname.Text.IndexOf(" ") == 0)
            {
                textBoxSurname.Text = textBoxSurname.Text.Substring(1);
                textBoxSurname.SelectionStart = textBoxSurname.Text.Length;
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

        private void textBoxMiddlename_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMiddlename.Text.Length == 1 && textBoxMiddlename.Text.Contains(" "))
            {
                textBoxMiddlename.Text = "";
            }
            if (textBoxMiddlename.Text.IndexOf(" ") == 0)
            {
                textBoxMiddlename.Text = textBoxMiddlename.Text.Substring(1);
                textBoxMiddlename.SelectionStart = textBoxMiddlename.Text.Length;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "" || textBoxName.Text == "")
            {
                MessageBox.Show("Заполните обязательные поля");
            }
            else
            {
                while (textBoxSurname.Text[textBoxSurname.Text.Length - 1] == ' ')
                {
                    textBoxSurname.Text = textBoxSurname.Text.Substring(0, textBoxSurname.Text.Length - 1);
                }
                while (textBoxName.Text[textBoxName.Text.Length - 1] == ' ')
                {
                    textBoxName.Text = textBoxName.Text.Substring(0, textBoxName.Text.Length - 1);
                }
                if (textBoxMiddlename.Text != "")
                {
                    while (textBoxMiddlename.Text[textBoxMiddlename.Text.Length - 1] == ' ')
                    {
                        textBoxMiddlename.Text = textBoxMiddlename.Text.Substring(0, textBoxMiddlename.Text.Length - 1);
                    }
                }
            }

            if (isNewItem == true && textBoxSurname.Text != "" && textBoxName.Text != "")
            {
                try
                {
                    string querieAdd = @"INSERT INTO lecturer(surname, name, middle_name) VALUES('" + textBoxSurname.Text + "', '" + textBoxName.Text + "', '" + textBoxMiddlename.Text + "');";
                    SqlCommand insert = new SqlCommand(querieAdd, connect);
                    connect.Open();
                    insert.ExecuteNonQuery();
                    connect.Close();
                    textBoxSurname.Text = "";
                    textBoxName.Text = "";
                    textBoxMiddlename.Text = "";
                    this.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Number.ToString(), "Неизвестная ошибка.");
                }
            }

            if (textBoxSurname.Text == "" || textBoxName.Text == "")
            {
            }
            else if (isNewItem == false && oldName != (textBoxSurname.Text + textBoxName.Text + textBoxMiddlename.Text) && (textBoxSurname.Text != "" || textBoxName.Text != ""))
            {
                if (MessageBox.Show("Вы действительно хотите внести изменения? Данная операция необратима.", "Изменение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string queiryUpdate = @"UPDATE lecturer SET surname='" + textBoxSurname.Text + "', name='" + textBoxName.Text + "', middle_name='" + textBoxMiddlename.Text + "' WHERE id_lecturer ='" + idItem + "'";
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

            if (isNewItem == false && oldName == textBoxSurname.Text + textBoxName.Text + textBoxMiddlename.Text)
            {
                this.Close();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (textBoxSurname.Text.Length == 0 && textBoxName.Text.Length == 0 && isNewItem == true)
            {
                this.Close();
                isNewItem = false;
            }
            else
            {
                if (oldName != textBoxSurname.Text + textBoxName.Text + textBoxMiddlename.Text)
                {
                    if (MessageBox.Show("Вы действительно хотите закрыть окно? Изменения не будут применены", "Отмена", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        textBoxSurname.Text = textBoxName.Text = textBoxMiddlename.Text = "";
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

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
            // Проверить на совпадения.

            //Добавить новую запись

            string querieAdd = @"INSERT INTO faculty (faculty_name) values('" + textBoxAddFaculty.Text + "');";
            SqlCommand insert = new SqlCommand(querieAdd, connect);
            connect.Open();
            insert.ExecuteNonQuery();
            connect.Close();
            textBoxAddFaculty.Text = "";
            this.Close();

        }
    }
    
}

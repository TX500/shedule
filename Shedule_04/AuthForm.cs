using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shedule_04
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        DB db = new DB();

        private void btnOk_Click(object sender, EventArgs e)
        {
            DB.login = field_login.Text;
            DB.password = field_password.Text;
            DB.server = field_server.Text;
            DB.database = field_database.Text;

            this.Enabled = false;

            if (authorization() == true)
            {
                this.Close();
            }
            else
            {
                this.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool authorization()
        {
            string connectString = db.getConnectString();

            SqlConnection con = new SqlConnection(connectString);
            Exception error = null;
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                error = ex;
                MessageBox.Show("Ошибка соединения с сервером");
                return false;
            }
            finally
            {
                if (error == null)
                {
                    con.Close();
                }
            }
            return true;
        }
    }
}

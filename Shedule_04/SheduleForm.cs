using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Shedule_04
{
    public partial class SheduleForm : Form
    {

        public SheduleForm()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection(DB.connectString);
        private void SheduleForm_Load(object sender, EventArgs e)
        {
            tableLoad();
        }

        private void tableLoad()
        {
            string querieAll = @"SELECT g.group_name, sh.semester, sh.year

  FROM shedule_table sh join  groups g on sh.fk_group=g.id_group
  group by g.group_name, sh.semester, sh.year;";

            SqlCommand table = new SqlCommand(querieAll, connect);

            connect.Open();

            SqlDataReader reader = table.ExecuteReader();

            int i = 0;
            int N = 1;
            dataGridView1.Rows.Clear();

            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                //dataGridView1[0, i].Value = reader[0];    // id
                dataGridView1[0, i].Value = N;
                dataGridView1[1, i].Value = reader[0];    //group        
                dataGridView1[2, i].Value = reader[1];    // semester
                dataGridView1[3, i].Value = reader[2];    // year
                i++;
                N++;
            }
            reader.Close();
            connect.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            SheduleGroupForm shg = new SheduleGroupForm();

            shg.group = dataGridView1[1, row].Value.ToString();
            shg.semester = dataGridView1[2, row].Value.ToString();
            shg.year = dataGridView1[3, row].Value.ToString();

            shg.ShowDialog();
        }
    }
}

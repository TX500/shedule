using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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

    }
}

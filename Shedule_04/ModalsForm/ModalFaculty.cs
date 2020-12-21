using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
    
}

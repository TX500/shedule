using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shedule_04
{
    public partial class SheduleGroupForm : Form
    {
        public String group;
        public String semester;
        public String year;
        
        
        
        public SheduleGroupForm()
        {
            InitializeComponent();
        }

        // Получаем ИД группы
        // Отбиравем все ИД квантов и засовываем их в ЛИСТ
        // Заполняем таблицу их ИД в листе

    }
}

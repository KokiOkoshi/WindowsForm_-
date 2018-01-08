using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm_練習用.View.CustomControl
{
    class DataGridViewCustomComboBoxEditingControl : DataGridViewComboBoxEditingControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DataGridViewCustomComboBoxEditingControl()
        {
            this.TabStop = false;
        }
    }
}

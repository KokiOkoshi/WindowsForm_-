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
            this.Enter += DataGridViewCustomComboBoxEditingControl_Enter;
            this.DropDownClosed += DataGridViewCustomComboBoxEditingControl_DropDownClosed; 
        }

        private void DataGridViewCustomComboBoxEditingControl_DropDownClosed(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(()=> {
                this.EditingControlDataGridView.EndEdit();
            }));
        }

        private void DataGridViewCustomComboBoxEditingControl_Enter(object sender, EventArgs e)
        {
            this.DroppedDown = true;
        }
    }
}

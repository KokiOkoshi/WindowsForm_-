using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsForm_練習用.View.CustomControl.CustomTextBox
{
    class DataGridViewCustomTextBoxEditingControl : DataGridViewTextBoxEditingControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DataGridViewCustomTextBoxEditingControl()
        {
            this.TabStop = false;
        }
    }
}

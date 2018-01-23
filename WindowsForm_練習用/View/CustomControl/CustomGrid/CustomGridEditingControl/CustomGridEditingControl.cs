using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsForm_練習用.View.CustomControl.CustomGridCell
{
    class CustomGridEditingControl : DataGridViewTextBoxEditingControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CustomGridEditingControl()
        {
            this.TabStop = false;
        }
    }
}

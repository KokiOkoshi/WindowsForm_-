using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm_練習用.View.CustomControl
{
    class DataGridViewCustomComboBoxCell : DataGridViewComboBoxCell
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DataGridViewCustomComboBoxCell()
        {
        }

        /// <summary>
        /// 編集コントロールを初期化
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="initialFormattedValue"></param>
        /// <param name="dataGridViewCellStyle"></param>
        public override void InitializeEditingControl( int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            // 編集コントロールを取得
            var customComboBoxEditControl = this.DataGridView.EditingControl as DataGridViewCustomComboBoxEditingControl;
            if (customComboBoxEditControl != null)
            {
                // Textを設定
                string str = initialFormattedValue as string;
                customComboBoxEditControl.Text = str != null ? str : "";
            }
        }

        /// <summary>
        /// 編集コントロールの型
        /// </summary>
        public override Type EditType => typeof(DataGridViewCustomComboBoxEditingControl);

        /// <summary>
        /// セルの値のデータ型
        /// </summary>
        public override Type ValueType => typeof(object);

        /// <summary>
        /// セルの既定値
        /// </summary>
        public override object DefaultNewRowValue => base.DefaultNewRowValue;
    }
}

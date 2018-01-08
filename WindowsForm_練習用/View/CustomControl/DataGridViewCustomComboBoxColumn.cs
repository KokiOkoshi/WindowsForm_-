using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm_練習用.View.CustomControl
{
    class DataGridViewCustomComboBoxColumn : DataGridViewColumn
    {
        /// <summary>
        /// CellTemplateとするDataGridViewCustomComboBoxCellオブジェクトを指定して
        /// 基本クラスのコンストラクタを呼び出す
        /// </summary>
        public DataGridViewCustomComboBoxColumn() : base(new DataGridViewCustomComboBoxCell())
        {
        }

        /// <summary>
        /// 新しいプロパティを追加する場合は
        /// Cloneメソッドをオーバーライドする必要がある
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var col = base.Clone() as DataGridViewCustomComboBoxColumn;

            return col;
        }

        /// <summary>
        /// CellTemplateの取得と設定
        /// </summary>
        public override DataGridViewCell CellTemplate
        {
            get => base.CellTemplate;
            set
            {
                // DataGridViewCustomComboBoxCellしか
                // CellTemplateに設定できないようにする
                if (!(value is DataGridViewCustomComboBoxCell))
                {
                    throw new InvalidCastException();
                }
                base.CellTemplate = value;
            }
        }

    }
}

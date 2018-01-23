using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm_練習用.View.CustomControl.CustomGridCell
{
    class CustomGridColumn : DataGridViewColumn
    {
        //CellTemplateとするDataGridViewMaskedTextBoxCellオブジェクトを指定して
        //基本クラスのコンストラクタを呼び出す
        public CustomGridColumn()
            : base(new CustomGridTextBoxCell()) //あとでスペースセルに置き換える
        {
        }

        //CellTemplateの取得と設定
        public override DataGridViewCell CellTemplate
        {
            get => base.CellTemplate;
            set
            {
                //DataGridViewMaskedTextBoxCellしか
                // CellTemplateに設定できないようにする
                if (!(value is CustomGridCellBase))
                {
                    throw new InvalidCastException("CustomGridCellオブジェクトを指定してください。");
                }
                base.CellTemplate = value;
            }
        }
    }
}

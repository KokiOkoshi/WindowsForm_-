using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm_練習用.View.CustomControl.CustomGridCell
{
    class CustomGridSelectorCell : CustomGridCellBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CustomGridSelectorCell()
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
            if (this.DataGridView.EditingControl is CustomGridSelectorEditingControl customLabelEditControl)
            {
                // Textを設定
                string str = initialFormattedValue as string;
                customLabelEditControl.Text = str ?? "";
            }
        }

        /// <summary>
        /// 編集コントロールの型
        /// </summary>
        public override Type EditType => typeof(CustomGridSelectorEditingControl);

        /// <summary>
        /// セルの値のデータ型
        /// </summary>
        public override Type ValueType => typeof(object);

        /// <summary>
        /// セルの既定値
        /// </summary>
        public override object DefaultNewRowValue => base.DefaultNewRowValue;

        /// <summary>
        /// スペースセルか
        /// </summary>
        protected override bool IsSpase => false;

        /// <summary>
        /// このメソッドで、内部のコントロールの表示位置を調節することが出来る
        /// </summary>
        /// <param name="setLocation"></param>
        /// <param name="setSize"></param>
        /// <param name="cellBounds"></param>
        /// <param name="cellClip"></param>
        /// <param name="cellStyle"></param>
        /// <param name="singleVerticalBorderAdded"></param>
        /// <param name="singleHorizontalBorderAdded"></param>
        /// <param name="isFirstDisplayedColumn"></param>
        /// <param name="isFirstDisplayedRow"></param>
        public override void PositionEditingControl(bool setLocation, bool setSize, Rectangle cellBounds, Rectangle cellClip, DataGridViewCellStyle cellStyle, bool singleVerticalBorderAdded, bool singleHorizontalBorderAdded, bool isFirstDisplayedColumn, bool isFirstDisplayedRow)
        {/*
            setLocation = false;
            setSize = false;
            cellBounds.Height += 20;
            cellClip.Height += 20;
            cellClip.Y += 20;
          */
            base.PositionEditingControl(setLocation, setSize, cellBounds, cellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow);
        }
    }
}

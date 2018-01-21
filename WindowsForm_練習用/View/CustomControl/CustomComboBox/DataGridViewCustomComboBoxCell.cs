using System;
using System.Collections.Generic;
using System.Drawing;
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

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="clipBounds"></param>
        /// <param name="cellBounds"></param>
        /// <param name="rowIndex"></param>
        /// <param name="elementState"></param>
        /// <param name="value"></param>
        /// <param name="formattedValue"></param>
        /// <param name="errorText"></param>
        /// <param name="cellStyle"></param>
        /// <param name="advancedBorderStyle"></param>
        /// <param name="paintParts"></param>
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            //このメソッドで描画処理を変更できる
            if (this.ColumnIndex==1 && rowIndex == 0)           //試しに一番上のセルを結合
            {
                var leftCell = DataGridView[0, 0];

                cellBounds.X -= leftCell.Size.Width;
                cellBounds.Width += leftCell.Size.Width;
                clipBounds.X -= leftCell.Size.Width;
                clipBounds.Width += leftCell.Size.Width;

                elementState = leftCell.State;
                value = leftCell.Value;
                formattedValue = leftCell.FormattedValue;
                errorText = leftCell.ErrorText;
                // cellStyle = leftCell.Style; コピーできない？ 
                // advancedBorderStyle コピーできない？ 

                base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            }
            else if (this.ColumnIndex == 0 && rowIndex == 0)
            {
                var rightCell = DataGridView[1, 0];


                cellBounds.Width += rightCell.Size.Width;
                clipBounds.Width += rightCell.Size.Width;

                base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            }
            else
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            }
        }

        public override void PositionEditingControl(bool setLocation, bool setSize, Rectangle cellBounds, Rectangle cellClip, DataGridViewCellStyle cellStyle, bool singleVerticalBorderAdded, bool singleHorizontalBorderAdded, bool isFirstDisplayedColumn, bool isFirstDisplayedRow)
        {
            //このメソッドで、内部のコントロールの表示位置を調節することが出来る
            setLocation = false;
            setSize = false;
            cellBounds.Height += 20;
            cellClip.Height += 20;
            cellClip.Y += 20;
            base.PositionEditingControl(setLocation, setSize, cellBounds, cellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow);
        }
    }
}

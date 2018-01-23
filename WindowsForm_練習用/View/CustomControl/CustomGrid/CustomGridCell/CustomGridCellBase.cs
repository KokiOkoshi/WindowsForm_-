using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm_練習用.View.CustomControl.CustomGridCell
{
    abstract public class CustomGridCellBase : DataGridViewTextBoxCell
    {
        public bool RightCellMerge { get; set; } = false;

        abstract protected bool IsSpase { get; }

        public override object Clone()
        {
            var clone = base.Clone() as CustomGridCellBase;
            clone.RightCellMerge = this.RightCellMerge;
            return clone;
        }

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
            //結合されたセルのサイズを計算
            if(this.RightCellMerge)
            {
                int startColumn = this.ColumnIndex;
                int endColumn = this.ColumnIndex+1;
                int row = this.RowIndex;
                var dataGrid = this.DataGridView;

                //結合された一番左のセル番号を取得
                for (; 0<(startColumn-1); startColumn--)
                {
                    var leftCell = dataGrid[startColumn - 1, row] as CustomGridCellBase;
                    if (!leftCell.RightCellMerge) break;
                    else
                    {
                        cellBounds.X -= leftCell.Size.Width;
                        cellBounds.Width += leftCell.Size.Width;
                        clipBounds.X -= leftCell.Size.Width;
                        clipBounds.Width += leftCell.Size.Width;
                    }
                }

                //結合された一番右のセル番号を取得
                for (;endColumn<dataGrid.ColumnCount;endColumn++)
                {
                    var rightCell = dataGrid[endColumn, row] as CustomGridCellBase;
                    cellBounds.Width += rightCell.Size.Width;
                    clipBounds.Width += rightCell.Size.Width;

                    if (!rightCell.RightCellMerge) break;
                }

                //セルの描画情報をコピー
                var mostLeftCell = dataGrid[startColumn, row] as CustomGridCellBase;
                elementState = mostLeftCell.State;
                value = mostLeftCell.Value;
                formattedValue = mostLeftCell.FormattedValue;
                errorText = mostLeftCell.ErrorText;
                if (!mostLeftCell.Style.BackColor.IsEmpty)
                {
                    cellStyle.BackColor = mostLeftCell.Style.BackColor;
                }
                // advancedBorderStyle コピーできない？ 
            }

            //スペースの場合も結合して一つのセル扱いにする
            if (this.IsSpase)
            {
                int startColumn = this.ColumnIndex;
                int endColumn = this.ColumnIndex + 1;
                int row = this.RowIndex;
                var dataGrid = this.DataGridView;

                //結合された一番左のセル番号を取得
                for (; 0 < (startColumn - 1); startColumn--)
                {
                    var leftCell = dataGrid[startColumn - 1, row] as CustomGridCellBase;
                    if (!leftCell.IsSpase) break;
                    else
                    {
                        cellBounds.X -= leftCell.Size.Width;
                        cellBounds.Width += leftCell.Size.Width;
                        clipBounds.X -= leftCell.Size.Width;
                        clipBounds.Width += leftCell.Size.Width;
                    }
                }

                //結合された一番右のセル番号を取得
                for (; endColumn < (dataGrid.ColumnCount - 1); endColumn++)
                {
                    var rightCell = dataGrid[endColumn, row] as CustomGridCellBase;
                    if (!rightCell.IsSpase) break;
                    else
                    {
                        cellBounds.X += rightCell.Size.Width;
                        cellBounds.Width += rightCell.Size.Width;
                        clipBounds.X += rightCell.Size.Width;
                        clipBounds.Width += rightCell.Size.Width;
                    }
                }

                //セルの描画情報をコピー
                var mostLeftCell = dataGrid[startColumn, row] as CustomGridCellBase;
                elementState = mostLeftCell.State;
                value = mostLeftCell.Value;
                formattedValue = mostLeftCell.FormattedValue;
                errorText = mostLeftCell.ErrorText;
                // cellStyle = mostLeftCell.Style; コピーできない？ 
                // advancedBorderStyle コピーできない？ 
            }

            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForm_練習用.View;
using WindowsForm_練習用.View.CustomControl;
using WindowsForm_練習用.View.CustomControl.CustomComboBox;
using WindowsForm_練習用.View.CustomControl.CustomGrid;
using WindowsForm_練習用.View.CustomControl.CustomGridCell;


namespace WindowsForm_練習用.View.CustomControl.CustomGrid
{
    public class CustomGrid : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CustomGrid()
        {
            InitializeComponent();
        }

        public void AddCell( int columnIndex, int rowIndex, CellData cellData)
        {
            //列を追加
            for (int i = (this.customDataGridView.ColumnCount-1); i < columnIndex; i++)
            {
                var column = new CustomGridColumn();
                this.customDataGridView.Columns.Add(column);
            }


            //行を追加
            for (int i = (this.customDataGridView.RowCount-1); i < rowIndex; i++)
            {
                var row = new DataGridViewRow();
                this.customDataGridView.Rows.Add(row);
            }

            //セルをデフォルトから差し替え
            this.customDataGridView[columnIndex,rowIndex] = cellData.Cell;
        }

        private void InitializeComponent()
        {
            this.customDataGridView = new CustomDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.customDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // customDataGridView1
            // 
            this.customDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.customDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.customDataGridView.Dock = DockStyle.Fill;
            this.customDataGridView.BackgroundColor = SystemColors.Window;
            this.customDataGridView.RowHeadersVisible = false;
            this.customDataGridView.ColumnHeadersVisible = false;
            this.customDataGridView.AllowUserToResizeRows = false;
            this.customDataGridView.AutoGenerateColumns = false;
            this.customDataGridView.AllowUserToAddRows = false;

            // 
            // CustomGrid
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.customDataGridView);
            ((System.ComponentModel.ISupportInitialize)(this.customDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private CustomDataGridView customDataGridView;
    }

    public class CellData
    {
        public string PropertyName { get; set; } = String.Empty;
        public CustomGridCellBase Cell { get; set; } = null;
    }

    public struct CellIndex
    {
        public int columnIndex;
        public int rowIndex;
    }

}

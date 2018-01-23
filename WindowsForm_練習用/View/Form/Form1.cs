using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForm_練習用.Resource;
using WindowsForm_練習用.Model;
using WindowsForm_練習用.View;
using WindowsForm_練習用.View.CustomControl;
using WindowsForm_練習用.View.CustomControl.CustomComboBox;
using WindowsForm_練習用.View.CustomControl.CustomGrid;
using WindowsForm_練習用.View.CustomControl.CustomGridCell;

namespace WindowsForm_練習用
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MakeGridLayout();
        }

        private void MakeGridLayout()
        {
            this.customGrid1.AddCell(0, 0, new CellData { Cell = new CustomGridTextBoxCell { } });
            this.customGrid1.AddCell(1, 0, new CellData { Cell = new CustomGridTextBoxCell { RightCellMerge = true, Value = "aaaa" , Style = new DataGridViewCellStyle { BackColor = Color.Green} } });
            this.customGrid1.AddCell(2, 0, new CellData { Cell = new CustomGridTextBoxCell { RightCellMerge = true } });
            this.customGrid1.AddCell(0, 1, new CellData { Cell = new CustomGridTextBoxCell { RightCellMerge = true, Value = "aaaa" } });
            this.customGrid1.AddCell(1, 1, new CellData { Cell = new CustomGridTextBoxCell { } });
            this.customGrid1.AddCell(2, 1, new CellData { Cell = new CustomGridTextBoxCell {  } });
        }
    }
}

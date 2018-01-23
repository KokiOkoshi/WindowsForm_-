using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm_練習用.View.CustomControl
{
    public partial class CustomDataGridView : DataGridView
    {
        public CustomDataGridView()
        {
            DoubleBuffered = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            DoubleBuffered = false;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            DoubleBuffered = true;
            base.OnMouseUp(e);
        }

        protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
        {
            //候補(ここでセルの選択をキャンセルできる)
            base.OnCellMouseDown(e);
        }
    }
}

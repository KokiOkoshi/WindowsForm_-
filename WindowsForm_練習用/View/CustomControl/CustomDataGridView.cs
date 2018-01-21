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
            InitializeComponent();
        }

        protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
        {
            //候補(ここでセルの選択をキャンセルできる)
            base.OnCellMouseDown(e);
        }
    }
}

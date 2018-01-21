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
using WindowsForm_練習用.View.CustomControl.CustomComboBox;

namespace WindowsForm_練習用
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataSet();
            customDataGridView1.MouseDown += CustomDataGridView1_MouseDown;
            customDataGridView1.RowHeadersVisible = false;
            customDataGridView1.ColumnHeadersVisible = false;
            customDataGridView1.AllowUserToResizeRows = false;
        }

        private void CustomDataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if( customDataGridView1.IsCurrentCellInEditMode)
            {
                throw new NotImplementedException();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataGridViewにデータを設定
        /// </summary>
        private void DataSet()
        {
            //=== DataGridView初期設定 ===
            customDataGridView1.AutoGenerateColumns = false;


            //=== データを設定 ===
            var data = new Data();
            var bindingSource = new BindingSource();

            bindingSource.DataSource = data.comboBoxDataList;

            customDataGridView1.DataSource = bindingSource;

            //=== DataGridView列追加設定 ===
            //コンボボックスの表示と内部値のテーブル
            var dataTable = new DataTable();
            dataTable.Columns.Add("Display",typeof(string));
            dataTable.Columns.Add("Value", typeof(ComboBoxChoices));
            dataTable.Rows.Add(StringResource.Data1, ComboBoxChoices.data1);
            dataTable.Rows.Add(StringResource.Data2, ComboBoxChoices.data2);

            //DataGridViewComboBoxColumsを作成
            var dataGridViewComboBoxColumn1 = new DataGridViewComboBoxColumn();
            dataGridViewComboBoxColumn1.CellTemplate = new DataGridViewCustomComboBoxCell();
            dataGridViewComboBoxColumn1.DataPropertyName = nameof(ComboBoxData.ComboBoxChoices1);
            dataGridViewComboBoxColumn1.HeaderText = "データ";
            dataGridViewComboBoxColumn1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dataGridViewComboBoxColumn1.DataSource = dataTable;
            dataGridViewComboBoxColumn1.DisplayMember = "Display";
            dataGridViewComboBoxColumn1.ValueMember = "Value";

            //DataGridViewに列を追加
            customDataGridView1.Columns.Add(dataGridViewComboBoxColumn1);

            //DataGridViewComboBoxColumsを作成
            var dataGridViewComboBoxColumn2 = new DataGridViewComboBoxColumn();
            dataGridViewComboBoxColumn2.CellTemplate = new DataGridViewCustomComboBoxCell();
            dataGridViewComboBoxColumn2.DataPropertyName = nameof(ComboBoxData.ComboBoxChoices2);
            dataGridViewComboBoxColumn2.HeaderText = "データ";
            dataGridViewComboBoxColumn2.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dataGridViewComboBoxColumn2.DataSource = dataTable;
            dataGridViewComboBoxColumn2.DisplayMember = "Display";
            dataGridViewComboBoxColumn2.ValueMember = "Value";

            //DataGridViewに列を追加
            customDataGridView1.Columns.Add(dataGridViewComboBoxColumn2);
        }
    }
}

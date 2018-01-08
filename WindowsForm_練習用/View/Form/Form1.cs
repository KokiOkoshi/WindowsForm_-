using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForm_練習用.Model;

namespace WindowsForm_練習用
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataSet();
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
            dataTable.Rows.Add("データ1", ComboBoxChoices.data1);
            dataTable.Rows.Add("データ2", ComboBoxChoices.data2);

            //DataGridViewComboBoxColumsを作成
            var dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn();
            dataGridViewComboBoxColumn.DataPropertyName = nameof(ComboBoxChoices);
            dataGridViewComboBoxColumn.HeaderText = "データ";
            dataGridViewComboBoxColumn.DataSource = dataTable;
            dataGridViewComboBoxColumn.DisplayMember = "Display";
            dataGridViewComboBoxColumn.ValueMember = "Value";

            //DataGridViewに列を追加
            customDataGridView1.Columns.Add(dataGridViewComboBoxColumn);
        }
    }
}

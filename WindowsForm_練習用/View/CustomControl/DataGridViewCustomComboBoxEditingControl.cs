using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm_練習用.View.CustomControl
{
    class DataGridViewCustomComboBoxEditingControl : CustomComboBox, IDataGridViewEditingControl
    {
        /// <summary>
        /// IDataGridViewEditingControl のメンバ
        /// </summary>
        #region

        /// <summary>
        /// 
        /// </summary>
        public DataGridView EditingControlDataGridView { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object EditingControlFormattedValue
        {
            get => this.GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
            set => this.Text = value as string;
        }

        /// <summary>
        /// 
        /// </summary>
        public int EditingControlRowIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool EditingControlValueChanged { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// 
        public Cursor EditingPanelCursor => base.Cursor;

        /// <summary>
        /// 
        /// </summary>
        public bool RepositionEditingControlOnValueChange => false;

        /// <summary>
        /// cellStyleを編集コントロールに適用
        /// </summary>
        /// <param name="dataGridViewCellStyle"></param>
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
        }

        /// <summary>
        /// キーをDataGridViewが処理するか、編集コントロールが処理するかを判定
        /// </summary>
        /// <param name="keyData"></param>
        /// <param name="dataGridViewWantsInputKey"></param>
        /// <returns></returns>
        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Right:
                case Keys.End:
                case Keys.Left:
                case Keys.Home:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        /// <summary>
        /// 編集コントロールで変更されたセルの値を取得
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return this.Text;
        }

        /// <summary>
        /// 編集前の準備
        /// </summary>
        /// <param name="selectAll"></param>
        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DataGridViewCustomComboBoxEditingControl()
        {
            this.TabStop = false;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            // 値の変更をDataGridViewに通知
            this.EditingControlValueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        }
    }
}

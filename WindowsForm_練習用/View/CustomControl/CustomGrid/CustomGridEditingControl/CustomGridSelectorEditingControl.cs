using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsForm_練習用.View.CustomControl.CustomGridCell
{
    class CustomGridSelectorEditingControl : Label, IDataGridViewEditingControl
    {
        private Form selectorForm;

        public DataGridView EditingControlDataGridView { get; set; }
        public object EditingControlFormattedValue
        {
            get => this.GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
            set => this.Text = value as string;
        }
        public int EditingControlRowIndex { get; set; }
        public bool EditingControlValueChanged { get; set; }

        public Cursor EditingPanelCursor => base.Cursor;

        public bool RepositionEditingControlOnValueChange => false;

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;

            this.TextAlign = (ContentAlignment)dataGridViewCellStyle.Alignment;
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return this.Text;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            this.selectorForm = new Form();
            this.selectorForm.TopMost = false;

            this.FindForm().AddOwnedForm(this.selectorForm);
            this.selectorForm.Controls.Add(new Label() { Text = "てすと", Dock = DockStyle.Fill});
            this.selectorForm.LostFocus += SelectorForm_Deactivate;
            this.EditingControlDataGridView.CellEndEdit += EditingControlDataGridView_EditModeChanged;

            this.selectorForm.Show();
        }

        private void SelectorForm_Deactivate(object sender, EventArgs e)
        {
            this.EditingControlDataGridView.EndEdit();
        }

        private void EditingControlDataGridView_EditModeChanged(object sender, EventArgs e)
        {
            this.selectorForm.Close();
            this.EditingControlDataGridView.CellEndEdit -= EditingControlDataGridView_EditModeChanged;
        }

        private void SelectorForm_Click(object sender, EventArgs e)
        {
            this.EditingControlDataGridView.EndEdit();
            this.selectorForm.Close();
        }
    }
}

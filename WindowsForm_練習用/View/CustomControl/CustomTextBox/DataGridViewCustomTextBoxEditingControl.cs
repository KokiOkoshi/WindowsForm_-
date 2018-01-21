using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsForm_練習用.View.CustomControl.CustomTextBox
{
    class DataGridViewCustomComboBoxEditingControl : DataGridViewComboBoxEditingControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DataGridViewCustomComboBoxEditingControl()
        {
            this.TabStop = false;
            this.Enter += DataGridViewCustomComboBoxEditingControl_Enter;
            this.DropDownClosed += DataGridViewCustomComboBoxEditingControl_DropDownClosed;
        }

        private void DataGridViewCustomComboBoxEditingControl_MouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DataGridViewCustomComboBoxEditingControl_DropDownClosed(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(()=> {
                //編集を終了
                this.EditingControlDataGridView.EndEdit();

                //マウスイベントを発生
                IntPtr hWnd = this.EditingControlDataGridView.Handle;
                Point point = this.EditingControlDataGridView.PointToClient(System.Windows.Forms.Cursor.Position);

                UInt16 x = (UInt16)point.X;
                UInt16 y = (UInt16)point.Y;

                uint pos = (uint)(y << 16 | x);

                Win32APIWrapper.SendMessage(
                    hWnd,
                    Win32APIWrapper.WM_LBUTTONDOWN,
                    Win32APIWrapper.MK_LBUTTON,
                    pos
                    );
                Win32APIWrapper.SendMessage(
                    hWnd,
                    Win32APIWrapper.WM_LBUTTONUP,
                    Win32APIWrapper.MK_LBUTTON,
                    pos
                    );

            }));
        }

        private void DataGridViewCustomComboBoxEditingControl_Enter(object sender, EventArgs e)
        {
            this.DroppedDown = true;
        }

    }


    //Win32API Wrapper
    public static class Win32APIWrapper
    {
        public const int HWND_BROADCAST = 0xFFFF;

        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_LBUTTONUP = 0x202;
        public const int MK_LBUTTON = 0x0001;


        [DllImport("user32.dll")]
        public extern static long SendMessage(
            IntPtr hWnd,
            uint Msg,
            uint wParam,
            uint lParam
            );

    }
}

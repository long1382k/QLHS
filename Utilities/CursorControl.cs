using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLHS.Utilities
{
    public partial class CursorControl : UserControl
    {
        public CursorControl()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern IntPtr LoadCursorFromFile(String str);

        #region Tạo con trỏ chuột
        public static Cursor Create(string filename)
        {
            IntPtr hCursor = LoadCursorFromFile(filename);

            if (!IntPtr.Zero.Equals(hCursor))
            {
                return new Cursor(hCursor);
            }
            else
            {
                MessageBoxEx.Show("Không tìm thấy file Pointer.cur.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return Cursors.Default;
            }
        }
        #endregion
    }
}

using DevComponents.DotNetBar;
using QLHS.Subform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace QLHS.QLNhanSu
{
    public partial class frToanBoChuyenGia : Office2007Form
    {
        public SuperTabControl spTabCtrl;
        LINQDataContext linq = new LINQDataContext();
        private ToolStripItem itemXoaHS;
        private ToolStripItem itemSuaHS;
        private ContextMenuStrip conMenu;
        private int idNhanSu;
        public frToanBoChuyenGia(SuperTabControl spTab)
        {
            InitializeComponent();
            this.spTabCtrl = spTab;

            conMenu = new System.Windows.Forms.ContextMenuStrip(); // khởi tạo menu context
            //add menu con
            itemSuaHS = conMenu.Items.Add("Sửa thông tin đối tác");
            itemXoaHS = conMenu.Items.Add("Xóa thông tin đối tác");
            conMenu.Items.Add(new ToolStripSeparator());


            //Thêm sự kiện
            itemSuaHS.Click += new EventHandler(btnSuaHoSo_Click);
            itemXoaHS.Click += new EventHandler(btnXoaHoSo_Click);


            //Thêm icon
            itemSuaHS.Image = Image.FromFile(Application.StartupPath + @"/icon/edit.png");
            itemXoaHS.Image = Image.FromFile(Application.StartupPath + @"/icon/delete.gif");
            LoadData();
           
        }

        private void LoadData()
        {
            dgv_nhansu.AutoGenerateColumns = false;
            var dt = linq.laybangchuyengia();
            dgv_nhansu.DataSource = dt;
        }
        private void bar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void frToanBoNhanSu_Load(object sender, EventArgs e)
        {
            this.dgv_nhansu.RowsDefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240);
            this.dgv_nhansu.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            this.dgv_nhansu.AutoGenerateColumns = false;

            // chữ to cho tiêu đề
            this.dgv_nhansu.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15F, FontStyle.Bold);
        }

        private void dgv_nhansu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == this.dgv_nhansu.Columns["STT"].Index)
            {
                e.Value = e.RowIndex + 1;
            }
        }

        private void btnSuaHoSo_Click(object sender, EventArgs e)
        {
            try
            {
                idNhanSu = Convert.ToInt32(this.dgv_nhansu.CurrentRow.Cells["MaNhanVien"].Value);
                A_ThemNhanSu them = new A_ThemNhanSu(Option.sua, idNhanSu,1);
                them.ShowDialog();
                LoadData();
                foreach (DataGridViewRow data in dgv_nhansu.Rows)
                {
                    if (Convert.ToInt32(data.Cells["MaNhanVien"].Value) == idNhanSu) dgv_nhansu.CurrentCell = data.Cells[0];
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi hiển thị form thêm nhân sự");
            }
        }

        private void btnXoaHoSo_Click(object sender, EventArgs e)
        {
            try
            {
                idNhanSu = Convert.ToInt32(this.dgv_nhansu.CurrentRow.Cells["MaNhanVien"].Value);
                if (MessageBox.Show("Bạn có chắc chắc muốn xóa thông tin đối tác?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    linq.xoanhanvien(idNhanSu);
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }

            }
            catch
            {
                MessageBox.Show("Lỗi khi xóa thông tin đối tác");
            }
        }

        private void btnThemHoSo_Click(object sender, EventArgs e)
        {
            try
            {
                A_ThemNhanSu them = new A_ThemNhanSu(Option.them, 0,1);
                them.ShowDialog();
                LoadData();
                dgv_nhansu.CurrentCell = dgv_nhansu.Rows[dgv_nhansu.RowCount - 1].Cells[0];

            }
            catch
            {
                MessageBox.Show("Lỗi khi hiển thị form thêm nhân sự");
            }
        }
        private int rowIndex = 0;
        private void dgv_nhansu_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    this.dgv_nhansu.Rows[e.RowIndex].Selected = true;
                    this.rowIndex = e.RowIndex;
                    this.dgv_nhansu.CurrentCell = this.dgv_nhansu.Rows[e.RowIndex].Cells[0];
                    this.conMenu.Show(this.dgv_nhansu, e.Location);
                    conMenu.Show(Cursor.Position);
                }
                catch { }
            }
        }

        private void btnCloseHoSo_Click(object sender, EventArgs e)
        {
            SuperTabItem tab = spTabCtrl.SelectedTab;
            tab.Close();
        }

        private void btnF5HoSo_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}

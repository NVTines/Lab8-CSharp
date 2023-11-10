using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class frmNhanVien : System.Windows.Forms.Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        public bool themmoi = false;
        NhanVien nv = new NhanVien();

        void HienThiNhanVien()
        {
            lsvNhanVien.FullRowSelect = true;
            lsvNhanVien.View = View.Details;
            DataTable dt = nv.LayDSNhanVien();

            lsvNhanVien.Columns.Add(new ColumnHeader());
            lsvNhanVien.Columns[0].Text = "Mã NV";
            lsvNhanVien.Columns[0].Width = 50;

            lsvNhanVien.Columns.Add(new ColumnHeader());
            lsvNhanVien.Columns[1].Text = "Họ tên";
            lsvNhanVien.Columns[1].Width = 150;

            lsvNhanVien.Columns.Add(new ColumnHeader());
            lsvNhanVien.Columns[2].Text = "Ngày sinh";
            lsvNhanVien.Columns[2].Width = 150;


            lsvNhanVien.Columns.Add(new ColumnHeader());
            lsvNhanVien.Columns[3].Text = "Địa chỉ";
            lsvNhanVien.Columns[3].Width = 150;


            lsvNhanVien.Columns.Add(new ColumnHeader());
            lsvNhanVien.Columns[4].Text = "Điện thoại";
            lsvNhanVien.Columns[4].Width = 150;

            lsvNhanVien.Columns.Add(new ColumnHeader());
            lsvNhanVien.Columns[5].Text = "Bằng cấp";
            lsvNhanVien.Columns[5].Width = 150;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvNhanVien.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
            }
        }

        void setNull()
        {
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
        }

        void setButton(bool val)
        {
            btnThem.Enabled = val;
            btnXoa.Enabled = val;
            btnSua.Enabled = val;
            btnThoat.Enabled = val;
            btnLuu.Enabled = !val;
            btnHuy.Enabled = !val;
        }

        void HienThiBangCap()
        {
            DataTable dt = nv.LayBangCap();
            cboBangCap.DataSource = dt;
            cboBangCap.DisplayMember = "TenBangCap";
            cboBangCap.ValueMember = "MaBangCap";
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            setNull();
            setButton(true);
            HienThiNhanVien();
            HienThiBangCap();
        }   

        public bool CheckData()
        {
            int check_num;
            
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Bạn chưa nhập điện thoại nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dateTimePicker.Text))
            {
                MessageBox.Show("Bạn chưa chọn ngày sinh nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePicker.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return false;
            }
            if (!int.TryParse(txtDienThoai.Text, out check_num))
            {
                MessageBox.Show("Số điện thoại không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cboBangCap.Text))
            {
                MessageBox.Show("Bạn chưa chọn bằng cấp nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboBangCap.Focus();
                return false;
            }
            return true;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            setButton(false);
            txtHoTen.Focus();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            bool flag = (lsvNhanVien.SelectedItems.Count > 0)?true:false;
            if(flag)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn cập nhật dòng này?", "Thông báo báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    themmoi = false;
                    setButton(false);
                }
            }
            else
                MessageBox.Show("Bạn phải lựa chọn mẩu tin cần cập nhật!", "Lưu ý!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            setNull();
            setButton(true);
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đóng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Dispose();
        }
        string maNV;
        private void lsvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedItems.Count > 0)
            {
                maNV = lsvNhanVien.SelectedItems[0].SubItems[0].Text;
                txtHoTen.Text = lsvNhanVien.SelectedItems[0].SubItems[1].Text;
                dateTimePicker.Text = lsvNhanVien.SelectedItems[0].SubItems[2].Text;
                txtDiaChi.Text = lsvNhanVien.SelectedItems[0].SubItems[3].Text;
                txtDienThoai.Text = lsvNhanVien.SelectedItems[0].SubItems[4].Text;
                cboBangCap.Text = lsvNhanVien.SelectedItems[0].SubItems[5].Text;
            }            
        }


        private void BtnXoa_Click(object sender, EventArgs e)
        {
            int flag = lsvNhanVien.SelectedItems.Count;
            if (flag > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa dòng này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    nv.XoaNhanVien(lsvNhanVien.SelectedItems[0].SubItems[0].Text);
                    lsvNhanVien.SelectedItems[0].Remove();
                    setNull();
                }
            }
            else
                MessageBox.Show("Bạn phải chọn dòng cần xóa?", "Thông báo", MessageBoxButtons.OK);
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                if (themmoi)
                {
                    nv.ThemNhanVien(txtHoTen.Text, dateTimePicker.Value, txtDiaChi.Text, txtDienThoai.Text, cboBangCap.SelectedIndex + 1);
                    MessageBox.Show("Thêm mới thành công!");
                }
                else
                {
                    nv.CapNhatNhanVien(maNV, txtHoTen.Text, dateTimePicker.Value, txtDiaChi.Text, txtDienThoai.Text, cboBangCap.SelectedIndex + 1);
                    MessageBox.Show("Cập nhật thành công!");
                }
                lsvNhanVien.Clear();
                HienThiNhanVien();
                setNull();
                setButton(true);
            }           
        }
    }
}

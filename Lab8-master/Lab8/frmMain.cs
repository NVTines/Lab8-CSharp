using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frmNhanVien = new frmNhanVien();
            frmNhanVien.Show();
        }

        private void btnDocGia_Click(object sender, EventArgs e)
        {
            frmDocGia frmDocGia = new frmDocGia(); 
            frmDocGia.Show();
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            frmSach frmSach = new frmSach();
            frmSach.Show();
        }

        private void btnPhieuThu_Click(object sender, EventArgs e)
        {
            frmPhieuThuTien frmPhieuThuTien = new frmPhieuThuTien();
            frmPhieuThuTien.Show();
        }
    }
}

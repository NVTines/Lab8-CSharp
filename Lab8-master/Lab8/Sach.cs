using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Sach
    {
        Database db;
        public Sach()
        {
            db = new Database();
        }
        public DataTable LayDSSach()
        {
            string sqlStr = "SELECT * FROM SACH";
            DataTable dt = db.Execute(sqlStr);
            return dt;
        }

        public void XoaSach(string masach)
        {
            string sqlStr = "DELETE FROM SACH WHERE MaSach = " + int.Parse(masach);
            db.ExecuteNonQuery(sqlStr);
        }

        public void ThemSach(string ten, string tacgia, int namxb, string nxb, float trigia, DateTime ngay)
        {
            string sqlStr = string.Format("INSERT INTO SACH (TenSach, TacGia, NamXuatBan, NhaXuatBan, TriGia, NgayNhap) VALUES (N'{0}', N'{1}', {2}, N'{3}', {4}, @Ngay)",ten, tacgia, namxb, nxb, trigia);
            db.ExecuteNonQuery_CU(sqlStr,ngay);
        }

        public void CapNhatSach(string ma, string tensach, string tacgia, int namxb, string nxb, float trigia, DateTime ngay)
        {
            string sqlStr = string.Format("UPDATE SACH SET TenSach = N'{0}', TacGia = N'{1}', NamXuatBan = {2}, NhaXuatBan = N'{3}', TriGia = {4} , NgayNhap = @Ngay WHERE MaSach = '{5}'", tensach, tacgia, namxb, nxb, trigia, ma);
            db.ExecuteNonQuery_CU(sqlStr,ngay);
        }
    }
}

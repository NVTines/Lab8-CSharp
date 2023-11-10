using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class NhanVien
    {
        Database db;
        public NhanVien()
        {
            db = new Database();
        }

        public DataTable LayDSNhanVien()
        {
            string sqlStr = "SELECT MaNhanVien, HoTenNhanVien, NgaySinh, DiaChi, DienThoai, TenBangCap FROM NHANVIEN N, BANGCAP B WHERE N.MaBangCap = B.MaBangCap"; ;
            DataTable dt = db.Execute(sqlStr);
            return dt;
        }

        public DataTable LayBangCap()
        {
            string sqlStr = "SELECT * FROM BANGCAP";
            DataTable dt = db.Execute(sqlStr);
            return dt;
        }

        public void XoaNhanVien(string index_nv)
        {
            string sqlStr = "DELETE FROM NHANVIEN WHERE MaNhanVien = " + int.Parse(index_nv);
            db.ExecuteNonQuery(sqlStr);
        }

        public void ThemNhanVien(string ten, DateTime ngaysinh, string diachi, string dienthoai, int index_bc)
        {
            string sqlStr = string.Format("INSERT INTO NHANVIEN (HoTenNhanVien, NgaySinh, DiaChi, DienThoai, MaBangCap) VALUES (N'{0}', @Ngay, N'{1}', N'{2}', {3});", ten, diachi, dienthoai, index_bc);
            db.ExecuteNonQuery_CU(sqlStr, ngaysinh);
        }

        public void CapNhatNhanVien(string index_nv, string hoten, DateTime ngaysinh, string diachi, string dienthoai, int index_bc)
        {
            string sqlStr = string.Format("UPDATE NHANVIEN SET HoTenNhanVien = N'{0}', NgaySinh = @Ngay, DiaChi = N'{1}', DienThoai = {2}, MaBangCap = {3} WHERE MaNhanVien = {4}", hoten, diachi, dienthoai, index_bc, int.Parse(index_nv));
            db.ExecuteNonQuery_CU(sqlStr, ngaysinh);
        }
    }
}

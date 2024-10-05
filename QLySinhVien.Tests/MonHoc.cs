using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QLy_SinhVien
{
    public class MonHoc
    {
        // Các thuộc tính của môn học
        public string MaMH { get; set; }    // Mã môn học
        public string TenMH { get; set; }   // Tên môn học
        public int SoTinChi { get; set; }   // Số tín chỉ
        public string MoTa { get; set; }    // Mô tả môn học

        // Constructor để khởi tạo đối tượng MonHoc
        public MonHoc(string maMH, string tenMH, int soTinChi, string moTa)
        {
            MaMH = maMH;
            TenMH = tenMH;
            SoTinChi = soTinChi;
            MoTa = moTa;
        }

        // Phương thức kiểm tra số tín chỉ có hợp lệ hay không
        public bool KiemTraSoTinChi()
        {
            // Giả sử số tín chỉ hợp lệ là từ 1 đến 10
            return SoTinChi > 0 && SoTinChi <= 10;
        }
    }
}

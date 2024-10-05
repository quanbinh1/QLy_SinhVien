using NUnit.Framework;
using QLy_SinhVien;
namespace QLySinhVien.Tests
    {
        [TestFixture]
        public class MonHocTests
        {
        [Test]
        public void testMonHoc() { }
            public void TaoMonHoc_VoiTenVaSoTinChi_HopLe()
            {
                // Arrange
                var MH = new MonHoc("MH001", "Lập Trình C#", 3, "Môn học lập trình với C#");

            // Act & Assert
                NUnit.Framework.Assert.Equals("MH001", MH.MaMH);
                NUnit.Framework.Assert.Equals("Lập Trình C#", MH.TenMH);
                NUnit.Framework.Assert.Equals(3, MH.SoTinChi);
                NUnit.Framework.Assert.Equals("Môn học lập trình với C#", MH.MoTa);
            }

            [Test]
        public void KiemTraSoTinChi_HopLeTraVeTrue()
        {
            // Arrange
            var MH = new MonHoc("MH001", "Lập Trình C#", 3, "Môn học lập trình với C#");

            // Act
            bool ketQua = MH.KiemTraSoTinChi();

            // Assert
            NUnit.Framework.Assert.That(ketQua, Is.True);
        }

        [Test]
            public void KiemTraSoTinChi_VoiSoTinChiKhongHopLe_TraVeFalse()
            {
                // Arrange
                var MH = new MonHoc("MH003", "Cơ Sở Dữ Liệu", 12, "Môn học cơ sở dữ liệu");

                // Act
                var result = MH.KiemTraSoTinChi();

            // Assert
            NUnit.Framework.Assert.That(result, Is.False);  // 12 tín chỉ là không hợp lệ, kiểm tra trả về false
            }
        }
    }


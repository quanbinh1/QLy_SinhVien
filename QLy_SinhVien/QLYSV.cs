using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLy_SinhVien
{
    public partial class frm_SinhVien : Form
    {
        public frm_SinhVien()
        {
            InitializeComponent();
        }


        private void btn_Them_Click(object sender, EventArgs e)
        {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\source\repos\QLy_SinhVien\QLy_SinhVien\database_SinhVien.mdf;Integrated Security=True"; // Thay chuỗi kết nối phù hợp

                string query = "INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, ThongtinLienLac, CTHoc, NamNhaphoc) VALUES (@MaSV, @HoTen, @NgaySinh, @ThongtinLienLac, @CTHoc, @NamNhaphoc)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", Convert.ToInt32(txt_MaSV.Text));
                        cmd.Parameters.AddWithValue("@HoTen", txt_HoTen.Text);
                        cmd.Parameters.AddWithValue("@NgaySinh", dtp_NgaySinh.Value);
                        cmd.Parameters.AddWithValue("@ThongtinLienLac", txt_ThongTinLienLac.Text);
                        cmd.Parameters.AddWithValue("@CTHoc", txt_CTHoc.Text);
                        cmd.Parameters.AddWithValue("@NamNhaphoc", Convert.ToInt32(txt_NamNhapHoc.Text));

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm sinh viên thành công!");
            LoadSinhVien();
            }
        private void LoadSinhVien()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\source\repos\QLy_SinhVien\QLy_SinhVien\database_SinhVien.mdf;Integrated Security=True"; // Thay chuỗi kết nối phù hợp

            string query = "SELECT * FROM SINHVIEN";
            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dataTable);
                    }
                }
            }

            dgvSinhVien.DataSource = dataTable;
        }

        private void dgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvSinhVien.Rows[e.RowIndex];

                txt_MaSV.Text = row.Cells["MaSV"].Value.ToString();
                txt_HoTen.Text = row.Cells["HoTen"].Value.ToString();
                dtp_NgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txt_ThongTinLienLac.Text = row.Cells["ThongtinLienLac"].Value.ToString();
                txt_CTHoc.Text = row.Cells["CTHoc"].Value.ToString();
                txt_NamNhapHoc.Text = row.Cells["NamNhaphoc"].Value.ToString();
            }
        }

        private void frm_SinhVien_Load(object sender, EventArgs e)
        {
            LoadSinhVien();
            cmb_TimKiem.Items.Add("MaSV");
            cmb_TimKiem.Items.Add("HoTen");
            cmb_TimKiem.Items.Add("NgaySinh");
            cmb_TimKiem.Items.Add("CTHoc");

            cmb_TimKiem.SelectedIndex = 0; 
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\source\repos\QLy_SinhVien\QLy_SinhVien\database_SinhVien.mdf;Integrated Security=True"; // Thay chuỗi kết nối phù hợp

            if (string.IsNullOrWhiteSpace(txt_MaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên để sửa.");
                return;
            }

            string query = "UPDATE SINHVIEN SET HoTen=@HoTen, NgaySinh=@NgaySinh, ThongtinLienLac=@ThongtinLienLac, CTHoc=@CTHoc, NamNhaphoc=@NamNhaphoc WHERE MaSV=@MaSV";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", txt_MaSV.Text);
                    cmd.Parameters.AddWithValue("@HoTen", txt_HoTen.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtp_NgaySinh.Value);
                    cmd.Parameters.AddWithValue("@ThongtinLienLac", txt_ThongTinLienLac.Text);
                    cmd.Parameters.AddWithValue("@CTHoc", txt_CTHoc.Text);
                    cmd.Parameters.AddWithValue("@NamNhaphoc", txt_NamNhapHoc.Text);

                    int rowsAffected = cmd.ExecuteNonQuery(); 

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin sinh viên thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên để cập nhật.");
                    }
                }
            }

            LoadSinhVien(); 
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\source\repos\QLy_SinhVien\QLy_SinhVien\database_SinhVien.mdf;Integrated Security=True"; // Thay chuỗi kết nối phù hợp
            if (string.IsNullOrWhiteSpace(txt_MaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên để xóa.");
                return;
            }

            string query = "DELETE FROM SINHVIEN WHERE MaSV=@MaSV";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", txt_MaSV.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa sinh viên thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên để xóa.");
                    }
                }
            }

            LoadSinhVien(); 
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\source\repos\QLy_SinhVien\QLy_SinhVien\database_SinhVien.mdf;Integrated Security=True"; // Thay chuỗi kết nối phù hợp

            if (string.IsNullOrWhiteSpace(txt_TimKiem.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm.");
                return;
            }

            string searchBy = cmb_TimKiem.SelectedItem.ToString(); // 
            string searchValue = txt_TimKiem.Text;

            string query = "";

            switch (searchBy)
            {
                case "MaSV":
                    query = "SELECT * FROM SINHVIEN WHERE MaSV LIKE @searchValue";
                    break;
                case "HoTen":
                    query = "SELECT * FROM SINHVIEN WHERE HoTen LIKE @searchValue";
                    break;
                case "NgaySinh":
                    query = "SELECT * FROM SINHVIEN WHERE NgaySinh = @searchValue"; // Ngày sinh cần định dạng đúng khi nhập
                    break;
                case "CTHoc":
                    query = "SELECT * FROM SINHVIEN WHERE CTHoc LIKE @searchValue";
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm.");
                    return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvSinhVien.DataSource = dt; 
                }
            }
        }
    }
}

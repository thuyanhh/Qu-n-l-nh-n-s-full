﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Thuctapnhomnew
{
 
    public partial class from2 : Form
    {
       QLNhanSuEntities db = new QLNhanSuEntities();
        public from2()
        {
            InitializeComponent();
        }
        DataGridView dt;
        public from2(DataGridView dgv_dsnv)
        {
            InitializeComponent();
            dgv_dsnv = dt;
        }

        public static class ketnoi
        {

            public static string chuoiketnoi = @"Data Source=DESKTOP-MON8K1N\SQLEXPRESS;Initial Catalog=QLNhanSu;Integrated Security=True";
            //  public static string chuoiketnoi = @"Data Source=HONG_NGOC\SQLEXPRESS;Initial Catalog=QLNhanSu;Integrated Security=True";
            public static SqlConnection con;
            public static SqlCommand cmd;
            public static SqlDataAdapter da;
            public static DataTable dt;


            public static void openketnoi()
            {
                con = new SqlConnection(chuoiketnoi);
                con.Open();
            }
            public static void dongketnoi()
            {
                con.Close();
            }
            // phuong thuc get
            public static DataTable gettable(string sql)
            {
                cmd = new SqlCommand(sql, con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public static void executeQuery(string sql)
            {
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            frm_them fr = new frm_them();
            fr.Show();
            Hide();
        }

        private void from2_Load(object sender, EventArgs e)
        {

            load();
        }
        public void load()
        {
            QLNhanSuEntities db = new QLNhanSuEntities();
            ketnoi.openketnoi();
            //load comboBox
            cmb_gioitinh.Items.Clear();
            cmb_gioitinh.Items.Add("Nam");
            cmb_gioitinh.Items.Add("Nữ");

            //
            cmb_tinhtranghonnhan.Items.Clear();
            cmb_tinhtranghonnhan.Items.Add("Đã kết hôn");
            cmb_tinhtranghonnhan.Items.Add("Chưa kết hôn");
            // cmb_tinhtranghonnhan.SelectedItem = "True";

            this.dgv_dsnv.DataSource = db.nhanviens.Where(s => s.status == null).Select( s => new
            {
                ID = s.ma,
                Name = s.ten,
                Birthday = s.ngaysinh,
                Gender = s.gioitinh == true ? "Nam" : "Nữ",
                Add = s.diachilienlac,
                Anh = s.anh,
             
          
            }).ToList();
            dgv_dsnv.Columns[0].HeaderText = "Mã nhân viên";
            dgv_dsnv.Columns[1].HeaderText = "Tên nhân viên";
            dgv_dsnv.Columns[2].HeaderText = "Ngày Sinh";
            dgv_dsnv.Columns[3].HeaderText = "Giới Tính";
            dgv_dsnv.Columns[4].HeaderText = "Địa chỉ";
            dgv_dsnv.Columns[5].HeaderText = "Ảnh";
            //Load DataGridView
            //dgv_dsnv.DataSource = ketnoi.gettable("select ma as N'Mã',ten as N'Họ tên',ngaysinh as N'Ngày sinh', case gioitinh when 1 then 'Nam' when 0 then N'Nữ' end as N'Gioi tinh',soCMT as N'CMTND',anh as N'Ảnh nhân viên',dienthoai as N'SĐT',email,quoctich,tongiao,dantoc,ngaycap,noicap,case tinhtranghonnhan when 1 then N'Đã kết hôn' when 0 then N'Chưa kết hôn 'end as N'Trình trạng hôn nhân',noisinh,quequan,hokhauthuongtru,noiohiennay   from nhanvien");

            //// btn_chapnhan.Enabled = false;
            ////  btn_huy.Enabled = false;
            //ketnoi.dongketnoi();

            var list = (from s in db.luongcobans select s.ma ).ToList();
            dgv_luong.DataSource = list;

        }

        private void dgv_dsnv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string path = dgv_dsnv.CurrentRow.Cells[5].Value.ToString();


            if (!string.IsNullOrWhiteSpace(path))
            {
                MemoryStream ms = new MemoryStream((byte[])dgv_dsnv.CurrentRow.Cells[5].Value);
                ptb_anh.Image = Image.FromStream(ms);

            }
            else
                ptb_anh.Image = null;
            string id = dgv_dsnv.CurrentRow.Cells[0].Value.ToString();
            QLNhanSuEntities nv = new QLNhanSuEntities();
            nhanvien newnv = nv.nhanviens.Single(s => s.ma == id);
            txt_manv.Text = newnv.ma;
            txt_hoten.Text = newnv.ten;
            dtk_ngaysinh.Text = newnv.ngaysinh.ToString();

            if (newnv.gioitinh.Value == false)
            {
                cmb_gioitinh.Text = "Nữ";
            }
            else
            {
                cmb_gioitinh.Text = "Nam";
            }
            txt_sdt.Text = newnv.dienthoai;
            txt_email.Text = newnv.email;
            txt_quoctich.Text = newnv.quoctich;
            txt_dantoc.Text = newnv.dantoc;
            txt_tongiao.Text = newnv.tongiao;
            if (newnv.tinhtranghonnhan == false)
            {
                cmb_tinhtranghonnhan.Text = "Chưa kết hôn";
            }
            else
            { cmb_tinhtranghonnhan.Text = "Đã kết hôn"; }
            txt_cmtnd.Text = newnv.soCMT;
            dtp_ngaycap.Text = newnv.ngaycap.ToString();
            txt_noicap.Text = newnv.noicap;
            txt_noisinh.Text = newnv.noisinh;
            txt_quequan.Text = newnv.quequan;
            txt_tamtru.Text = newnv.noiohiennay;
            txt_thuongtru.Text = newnv.hokhauthuongtru;
            txt_hocvan.Text = newnv.hocvanma;
            txt_chucvu.Text = newnv.chucvuma;
            txt_ngoaingu.Text = newnv.trinhdongoaingu;
            txt_maphongban.Text = newnv.phongbanma;
            txt_mahd.Text = newnv.hopdonglaodongnhanvienma;
            var tenhd = from s in nv.hopdonglaodongnhanviens where s.ma == newnv.hopdonglaodongnhanvienma select s.ten;
            var luongcoban = from s in nv.hopdonglaodongnhanviens where s.ma == newnv.hopdonglaodongnhanvienma select s.luongthuviec;
            var ngaybd = from s in nv.hopdonglaodongnhanviens where s.ma == newnv.hopdonglaodongnhanvienma select s.ngaybatdau;
            var ngaykt = from s in nv.hopdonglaodongnhanviens where s.ma == newnv.hopdonglaodongnhanvienma select s.ngayketthuc;
            txt_tenhd.Text = tenhd.FirstOrDefault();
            txt_luongcb.Text = luongcoban.FirstOrDefault().ToString();
            txt_ngaykt.Text = ngaykt.FirstOrDefault().ToString();
            var thongtingiadinh = from s in nv.thongtinkhacvenhanviens where s.nhanvienma == newnv.ma select s.giadinh;
            txt_giadinh.Text = thongtingiadinh.FirstOrDefault();
            var solaodong = from s in nv.thongtinkhacvenhanviens where s.nhanvienma == newnv.ma select s ;

        }

        private byte[] convertFilToBytes(string spath)
        {

            byte[] data = null;
            FileInfo finfo = new FileInfo(spath);
            long numBytes = finfo.Length;
            FileStream fs = new FileStream(spath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            data = br.ReadBytes((int)numBytes);
            return data;

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string id =dgv_dsnv.CurrentRow.Cells[0].Value.ToString();
            Sua fr = new Sua(id);
            fr.Show(this);
            Hide();
        
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_dsnv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Cần chọn dữ liệu để xóa!", "Thông báo");
                return;
            }
            DialogResult = MessageBox.Show("Bạn có chắc muốn xóa!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                string id =dgv_dsnv.CurrentRow.Cells[0].Value.ToString();

                nhanvien nv = db.nhanviens.Single(s => s.ma == id);
                nv.status = 0;
                db.SaveChanges();
                load();
            }
        }

        private void txt_timkiem_KeyUp(object sender, KeyEventArgs e)
        {
            QLNhanSuEntities db = new QLNhanSuEntities();
            var Lst = (from s in db.nhanviens where s.ma.Contains(txt_timkiem.Text) select s).ToList();
            dgv_dsnv.DataSource = Lst;
            txt_manv.DataBindings.Clear();
            txt_hoten.DataBindings.Clear();
            txt_cmtnd.DataBindings.Clear();
            txt_manv.DataBindings.Add("text", Lst, "ma");
            txt_hoten.DataBindings.Add("text", Lst, "ten");
            txt_cmtnd.DataBindings.Add("text", Lst, "soCMT");
        }

        private void dgv_luong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgv_luong.CurrentRow.Cells[0].Value.ToString();
            QLNhanSuEntities db = new QLNhanSuEntities();
            luongcoban sa = db.luongcobans.Single(s => s.ma ==id);
          
            dgv_luong.Rows.Clear();
            //var list = from s in db.luongcobans
            //           where s.ma == s.ma//Chọn toàn bộ bảng
            //           select s;
        

        }

        private void dgv_phucap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgv_dsnv.CurrentRow.Cells[0].Value.ToString();
            QLNhanSuEntities nv = new QLNhanSuEntities();
            nhanvien newnv = nv.nhanviens.Single(s => s.ma == id);


        }

        private void btn_brown_Click(object sender, EventArgs e)
        {

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            frm_trangchu fr = new frm_trangchu();
            fr.Show();
            Hide();
        }
    }
}
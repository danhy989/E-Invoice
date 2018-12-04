using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoCloneTax
{
    public partial class NhapChuKySo : Form
    {

        String SDT, Email, MST, ToChucTVan, ToChucCungCap, CTS, CKS;
        public NhapChuKySo(String SDT,String Email,String MST,String ToChucTVan,String ToChucCungCap,String CTS)
        {
            this.SDT = SDT;
            this.Email = Email;
            this.MST = MST;
            this.ToChucTVan = ToChucTVan;
            this.ToChucCungCap = ToChucCungCap;
            this.CTS = CTS;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            this.CKS = textBox1.Text.ToString();
            string query = "insert into ToKhaiDangKy(MaSoThue,DienThoai,Email,ToChucTVan,ToChucCungCap,CTS,CKS) values('"+MST+"','"+ SDT+"','"+ Email+"','"+ ToChucTVan+"','"+ ToChucCungCap+"','"+ CTS+"','"+ CKS+"')";
            DataProvide.Instance.ExecuteNonQuery(query);
            string querygetUser  = "select TenTaiKhoan from TaiKhoan where MaSoThue='"+MST+"'";
            string querygetPass = "select MatKhau from TaiKhoan where MaSoThue='" + MST + "'";
            string User = DataProvide.Instance.ExecuteReader(querygetUser);
            string PassWord = DataProvide.Instance.ExecuteReader(querygetPass);
            MessageBox.Show("UserName : " + User + "\n Password : "+PassWord);
            DangNhap form = new DangNhap();
            this.Close();
            form.Show();
        }
    }
}

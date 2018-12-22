using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoCloneTax
{
    public partial class ChiTietToKhaiDangKy : Form
    {
        public ChiTietToKhaiDangKy(String MST,String DT,String Email)
        {
            
            InitializeComponent();
            labelSDT.Text = DT;
            labelEmail.Text = Email;
            labelMST.Text = MST;
            labelToChucTVan.Text = "Dịch vụ khai thuế - Tổng cục thuế";
            labelToChucCungCap.Text = "TEST";
            labelCTS.Text = "NO123USBTOKENTEST123";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(this.Width,this.Height);
            DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            bitmap.Save("toKhaiThue.jpeg", ImageFormat.Jpeg);
            NhapChuKySo form = new NhapChuKySo(labelSDT.Text, labelEmail.Text, labelMST.Text, labelToChucTVan.Text, labelToChucCungCap.Text, labelCTS.Text);
            this.Hide();
            form.ShowDialog();
        
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

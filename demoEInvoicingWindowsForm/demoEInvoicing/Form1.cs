
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SautinSoft.Document;
using System.IO;

namespace demoEInvoicing
{
    public partial class Form1 : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "zUJbDLpuj5JOwDGJrXH9D0atvemeMpyH6wissyIc",
            BasePath = "https://demoeinvoicing.firebaseio.com/"
        };
        IFirebaseClient client;
        string EName = null, ComName = null, CusName = null;
        List<EInvoicing> einvoiceArray = new List<EInvoicing>(); // Tạo list EInvoice
        List<string> listKey = new List<string>();
        List<string> listKeyTempt = new List<string>();
        List<EInvoicing> einvoiceArray1 = new List<EInvoicing>(); // Tạo list EInvoice
        List<string> listKey1 = new List<string>();
        List<string> listKeyTempt1 = new List<string>();
        int CheckCountKey = 0;
        DataTable data = new DataTable();
        public Form1()
        {
            InitializeComponent();
           client = new FireSharp.FirebaseClient(config);
            if (client != null) MessageBox.Show("Kết nối tới firebase thành công");
            data.Columns.Add("Ngày lập hóa đơn");
            data.Columns.Add("Tên hóa đơn");
            data.Columns.Add("Mã số hóa đơn");
            data.Columns.Add("Kí hiệu hóa đơn");
            data.Columns.Add("Tên công ty");
            data.Columns.Add("Tên khách hàng");
            data.Columns.Add("Hình thức thanh toán");
            data.Columns.Add("Tổng tiền");
            dataGridView1.DataSource = data;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private async void button1_Click(object sender, EventArgs e)//refesh
        {
            getAndSetData();
        }

        

        private async void getAndSetData()
        {

            FirebaseResponse response = client.Get("hoadon");
            dynamic EInvoices = JsonConvert.DeserializeObject(response.Body); // Trả về object hóa đơn dưới dạng JSON 
            foreach (var EInvoice in EInvoices) // Duyệt từng hóa đơn
            {
                string a = EInvoice.Name; //Lấy key of Hóa đơn dưới dạng JSON
                if (listKeyTempt.Contains(a)==false)
                {
                   // listKeyTempt.Add(a);
                    listKey.Add(a);
                }
                listKeyTempt.Add(a);
            }
            
            

            foreach (var key in listKey) // Duyệt từng hóa đơn
            { 
                    FirebaseResponse responseInfor = await client.GetTaskAsync("hoadon/" + key); //Lấy value của hóa đơn
                    EInvoicing temp = new EInvoicing();//Tạo một Class Einvoice tạm
                    temp = responseInfor.ResultAs<EInvoicing>();//Kéo dữ liệu hóa đơn từ server đổ về class tạm này

                if(einvoiceArray.Count==0)
                {
                    einvoiceArray.Add(temp);//Thêm dữ liệu vào List Einvoice
                }else
                {
                    if(einvoiceArray.Count < listKey.Count)
                    {
                        einvoiceArray.Add(temp);//Thêm dữ liệu vào List Einvoice
                    }else
                    {
                        if (einvoiceArray.Contains(temp) == true)
                        {
                            einvoiceArray.Add(temp);//Thêm dữ liệu vào List Einvoice
                        }
                    }
                }
            }
            foreach (var einvoice in einvoiceArray)
            {
                
                DataRow row = data.NewRow();
                row["Ngày lập hóa đơn"] = einvoice.InvoiceArisingDate;
                row["Tên hóa đơn"] = einvoice.InvoiceName;
                row["Mã số hóa đơn"] = einvoice.InvoiceNo;
                row["Kí hiệu hóa đơn"] = einvoice.InvoiceSerialNo;
                row["Tên công ty"] = einvoice.ComName;
                row["Tên khách hàng"] = einvoice.CusName;
                row["Hình thức thanh toán"] = einvoice.Payment;
                row["Tổng tiền"] = einvoice.TotalPrice;
                data.Rows.Add(row);

                string query = "EXEC dbo.AddtoDataBase @ComName , @ComAddress , @ComPhone , @CusName , @CusEmail , @CusAddress , @CusBankName , @Cusphone , @CusBankNo , @InvoiceArisingDate , @InvoiceName , @InvoiceNo , @InvoiceSerialNo , @Payment , @TotalPrice  ";
                int check = DataProvide.Instance.ExecuteNonQuery(query, new object[] { einvoice.ComName, einvoice.ComAddress, einvoice.ComPhone, einvoice.CusName, einvoice.CusEmail, einvoice.CusAddress, einvoice.CusBankName, einvoice.CusPhone, einvoice.CusBankNo, einvoice.InvoiceArisingDate, einvoice.InvoiceName, einvoice.InvoiceNo, einvoice.InvoiceSerialNo, einvoice.Payment, einvoice.TotalPrice });
                foreach (var item in einvoice.itemsData)
                {
                    string queryItem = "EXEC dbo.AddInvoicetoDataBase @ItemsName , @ItemsPrice , @ItemsNum , @InvoiceSerialNo ";
                    DataProvide.Instance.ExecuteNonQuery(queryItem, new object[] { item.ItemsName, item.ItemsPrice, item.ItemsNum, einvoice.InvoiceSerialNo });
                }
            }
            
            listKey.Clear();
            einvoiceArray.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Get("hoadon");
            dynamic EInvoices1 = JsonConvert.DeserializeObject(response.Body); // Trả về object hóa đơn dưới dạng JSON 
            foreach (var EInvoice in EInvoices1) // Duyệt từng hóa đơn
            {
                string a = EInvoice.Name; //Lấy key of Hóa đơn dưới dạng JSON
                if (listKeyTempt1.Contains(a) == false)
                {
                    // listKeyTempt.Add(a);
                    listKey1.Add(a);
                }
                listKeyTempt1.Add(a);
            }



            foreach (var key in listKey1) // Duyệt từng hóa đơn
            {
                FirebaseResponse responseInfor = await client.GetTaskAsync("hoadon/" + key); //Lấy value của hóa đơn
                EInvoicing temp = new EInvoicing();//Tạo một Class Einvoice tạm
                temp = responseInfor.ResultAs<EInvoicing>();//Kéo dữ liệu hóa đơn từ server đổ về class tạm này

                if (einvoiceArray1.Count == 0)
                {
                    einvoiceArray1.Add(temp);//Thêm dữ liệu vào List Einvoice
                }
                else
                {
                    if (einvoiceArray1.Count < listKey1.Count)
                    {
                        einvoiceArray1.Add(temp);//Thêm dữ liệu vào List Einvoice
                    }
                    else
                    {
                        if (einvoiceArray1.Contains(temp) == true)
                        {
                            einvoiceArray1.Add(temp);//Thêm dữ liệu vào List Einvoice
                        }
                    }
                }
            }
            foreach (var einvoice in einvoiceArray1)
            {
                if(einvoice.ComName==ComName && einvoice.CusName==CusName && einvoice.InvoiceSerialNo == EName)
                {
                    string pdfPath = "Result.pdf";
                    CharacterFormat textFormat = new CharacterFormat() { Size = 15, FontColor = SautinSoft.Document.Color.Black };
                    DocumentCore dc = new DocumentCore();
                    Section section = new Section(dc);
                    dc.Sections.Add(section);
                    section.PageSetup.PaperType = PaperType.A4;
                    section.PageSetup.Orientation = SautinSoft.Document.Orientation.Landscape;
                    Paragraph par1 = new Paragraph(dc);
                     
                    par1.ParagraphFormat.Alignment = SautinSoft.Document.HorizontalAlignment.Center;
                    section.Blocks.Add(par1);
                    CharacterFormat cf = new CharacterFormat() { FontName = "Verdana", Size = 20, FontColor = SautinSoft.Document.Color.Red ,Bold = true };
                    Run text1 = new Run(dc,einvoice.InvoiceName);
                    text1.CharacterFormat = cf;
                    par1.Inlines.Add(text1);
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    dc.Content.End.Insert("Ngày lập hóa đơn : " + einvoice.InvoiceArisingDate, textFormat);
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    dc.Content.End.Insert("Số hóa đơn : " + einvoice.InvoiceNo, textFormat);
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    dc.Content.End.Insert("Số hiệu hóa đơn : " + einvoice.InvoiceSerialNo, textFormat);
                    // Let's add a line break into our paragraph.
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));

                    // Way 2 (easy): Add 2nd paragraph using ContentRange.
                    dc.Content.End.Insert("Tên khách hàng : "+einvoice.CusName , textFormat);
                    SpecialCharacter lBr = new SpecialCharacter(dc, SpecialCharacterType.LineBreak);
                    dc.Content.End.Insert(lBr.Content);
                    dc.Content.End.Insert("Địa chỉ khách hàng : " + einvoice.CusAddress, textFormat);
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    dc.Content.End.Insert("Email khách hàng : " + einvoice.CusEmail, textFormat);
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    dc.Content.End.Insert("Số điện thoại khách hàng : " + einvoice.CusPhone, textFormat);
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    dc.Content.End.Insert("Số tài khoản  : " + einvoice.CusBankNo, textFormat);
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    dc.Content.End.Insert("Tên ngân hàng  : " + einvoice.CusBankName, textFormat);
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    dc.Content.End.Insert("Tên công ty : " + einvoice.ComName, textFormat);
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    dc.Content.End.Insert("Địa chỉ công ty : " + einvoice.ComAddress, textFormat);
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    dc.Content.End.Insert("Số điện thoại công ty  : " + einvoice.ComPhone, textFormat);
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    foreach(var items in einvoice.itemsData)
                    {
                        dc.Content.End.Insert("Món hàng : " + items.ItemsName, textFormat);
                        dc.Content.End.Insert("\t\t", textFormat);
                        dc.Content.End.Insert("Số lượng : " + items.ItemsNum, textFormat);
                        dc.Content.End.Insert("\t\t", textFormat);
                        dc.Content.End.Insert("Đơn giá  : " + items.ItemsPrice+" đồng", textFormat);
                        dc.Content.End.Insert("\t\t", textFormat);
                       // dc.Content.End.Insert("------------------------------------", textFormat);
                        par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    }
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    dc.Content.End.Insert("Hình thức thanh toán : " + einvoice.Payment, textFormat);
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    par1.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    dc.Content.End.Insert("Tổng tiền : " + einvoice.TotalPrice+" đồng", new CharacterFormat() { Size =30, FontColor = SautinSoft.Document.Color.Red });
                    Paragraph par2 = new Paragraph(dc);
                    par2.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    par2.ParagraphFormat.Alignment = SautinSoft.Document.HorizontalAlignment.Justify;
                    section.Blocks.Add(par2);
                    par2.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
                    dc.Content.End.Insert("Chữ ký của khách hàng \t\t\t\t\t  Chữ ký của nhà bán hàng ", new CharacterFormat() { Size = 20, FontColor = SautinSoft.Document.Color.Red });
                    // Save PDF to a file
                    dc.Save(pdfPath, new PdfSaveOptions());

                    // Open the result for demonstation purposes.
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true });
                    break;
                }
            }

            listKey1.Clear();
            einvoiceArray1.Clear();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EName = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            ComName = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            CusName = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
    }
}

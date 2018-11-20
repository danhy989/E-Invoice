
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoEInvoicing
{
    public class EInvoicing
    {
        public EInvoicing() {
            
        }

        public List<ClassItem> itemsData { get; set; }
        public string CusAddress { get; set; }
        public string CusBankName { get; set; }
        public string CusEmail { get; set; }
        public string CusName { get; set; }
        public float Cusphone { get; set; }
        public float CusBankNo { get; set; }
        public string InvoiceArisingDate { get; set; }
        public string InvoiceName { get; set; }
        public float InvoiceNo { get; set; }
        public string InvoiceSerialNo { get; set; }
        public string ComAddress { get; set; }
        public string ComName { get; set; }
        public float ComPhone { get; set; }
        public string Payment { get; set; }
        public float TotalPrice { get; set; }
       
    }
    public class ClassItem
    {
        public string ItemsName { get; set; }
        public float ItemsNum { get; set; }
        public float ItemsPrice { get; set; }
    }
}

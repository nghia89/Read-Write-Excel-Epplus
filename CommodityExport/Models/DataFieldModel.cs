using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommodityExport.Models
{
    public class DataFieldModel
    {
        public string Orderid { get; set; }
        public string OrderDate { get; set; }
        public string BarCode { get; set; }
        public string ProductName { get; set; }
        public string QuanTity { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }
        public long ShipToStoreId { get; set; }
        public string ShipToStoreName { get; set; }
        public string ShipToStoreAddress { get; set; }
        public string ShipFromDate { get; set; }
        public string ShipToDate { get; set; }
    }
}

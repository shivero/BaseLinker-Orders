﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLinker_Orders.Models
{
    public class Product
    {
        public string storage { get; set; }
        public int storage_id { get; set; }
        public string order_product_id { get; set; }
        public string product_id { get; set; }
        public int variant_id { get; set; }
        public string name { get; set; }
        public string attributes { get; set; }
        public string sku { get; set; }
        public string ean { get; set; }
        public string auction_id { get; set; }
        public float price_brutto { get; set; }
        public int tax_rate { get; set; }
        public int quantity { get; set; }
        public int weight { get; set; }
    }
}

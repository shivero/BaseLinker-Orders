﻿using System.Collections.Generic;

namespace BaseLinker_Orders
{
    public class Order : OrderBase
    {
        public OrderList[] orders { get; set; }

        public class OrderList
        {
            internal string invoice_county_code;
            internal string paid;

            public int order_id { get; set; }
            public string shop_order_id { get; set; }
            public string external_order_id { get; set; }
            public string order_source { get; set; }
            public string order_source_id { get; set; }
            public string order_source_info { get; set; }
            public int order_status_id { get; set; }
            public long date_add { get; set; }
            public string date_confirmed { get; set; }
            public string date_in_status { get; set; }
            public string user_login { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
            public string user_comments { get; set; }
            public string admin_comments { get; set; }
            public string currency { get; set; }
            public string payment_method { get; set; }
            public string payment_method_cod { get; set; }
            public string payment_done { get; set; }
            public string delivery_method { get; set; }
            public string delivery_price { get; set; }
            public string delivery_package_module { get; set; }
            public string delivery_package_nr { get; set; }
            public string delivery_fullname { get; set; }
            public string delivery_company { get; set; }
            public string delivery_address { get; set; }
            public string delivery_city { get; set; }
            public string delivery_postcode { get; set; }
            public string delivery_country { get; set; }
            public string delivery_point_id { get; set; }
            public string delivery_point_name { get; set; }
            public string delivery_point_address { get; set; }
            public string delivery_point_postcode { get; set; }
            public string delivery_point_city { get; set; }
            public string invoice_fullname { get; set; }
            public string invoice_company { get; set; }
            public string invoice_nip { get; set; }
            public string invoice_address { get; set; }
            public string invoice_city { get; set; }
            public string invoice_postcode { get; set; }
            public string invoice_country { get; set; }
            public string want_invoice { get; set; }
            public string extra_field_1 { get; set; }
            public string extra_field_2 { get; set; }
            public string order_page { get; set; }
            public string pick_status { get; set; }
            public string pack_status { get; set; }
            public Models.Product[] products { get; set; }
        }
        public class AddOrder
        {
            public int order_status_id { get; set; }
            public float date_add { get; set; }
            public string user_comments { get; set; }
            public string admin_comments { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
            public string user_login { get; set; }
            public string currency { get; set; }
            public string payment_method { get; set; }
            public string payment_method_cod { get; set; }
            public string paid { get; set; }
            public string delivery_method { get; set; }
            public string delivery_price { get; set; }
            public string delivery_fullname { get; set; }
            public string delivery_company { get; set; }
            public string delivery_address { get; set; }
            public string delivery_city { get; set; }
            public string delivery_postcode { get; set; }
            public string delivery_country_code { get; set; }
            public string delivery_point_id { get; set; }
            public string delivery_point_name { get; set; }
            public string delivery_point_address { get; set; }
            public string delivery_point_postcode { get; set; }
            public string delivery_point_city { get; set; }
            public string invoice_fullname { get; set; }
            public string invoice_company { get; set; }
            public string invoice_nip { get; set; }
            public string invoice_address { get; set; }
            public string invoice_city { get; set; }
            public string invoice_postcode { get; set; }
            public string invoice_country_code { get; set; }
            public string want_invoice { get; set; }
            public string extra_field_1 { get; set; }
            public string extra_field_2 { get; set; }
            public Models.Product[] products { get; set; }
        }
    }
}

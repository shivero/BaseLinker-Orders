using System.Collections.Generic;

namespace BaseLinker_Orders
{
    public class Order : OrderBase
    {
        public OrderDetails[] orders { get; set; }

        public class OrderDetails
        {
            

            public int Order_id { get; set; }
            public string Shop_order_id { get; set; }
            public string External_order_id { get; set; }
            public string Order_source { get; set; }
            public string Order_source_id { get; set; }
            public string Order_source_info { get; set; }
            public int Order_status_id { get; set; }
            public long Date_add { get; set; }
            public string Date_confirmed { get; set; }
            public string Date_in_status { get; set; }
            public string User_login { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string User_comments { get; set; }
            public string Admin_comments { get; set; }
            public string Currency { get; set; }
            public string Payment_method { get; set; }
            public string Payment_method_cod { get; set; }
            public string Payment_done { get; set; }
            public string Delivery_method { get; set; }
            public string Delivery_price { get; set; }
            public string Delivery_package_module { get; set; }
            public string Delivery_package_nr { get; set; }
            public string Delivery_fullname { get; set; }
            public string Delivery_company { get; set; }
            public string Delivery_address { get; set; }
            public string Delivery_city { get; set; }
            public string Delivery_postcode { get; set; }
            public string Delivery_country { get; set; }
            public string Delivery_point_id { get; set; }
            public string Delivery_point_name { get; set; }
            public string Delivery_point_address { get; set; }
            public string Delivery_point_postcode { get; set; }
            public string Delivery_point_city { get; set; }
            public string Invoice_fullname { get; set; }
            public string Invoice_company { get; set; }
            public string Invoice_nip { get; set; }
            public string Invoice_address { get; set; }
            public string Invoice_city { get; set; }
            public string Invoice_postcode { get; set; }
            public string Invoice_country { get; set; }
            public string Want_invoice { get; set; }
            public string Extra_field_1 { get; set; }
            public string Extra_field_2 { get; set; }
            public string Order_page { get; set; }
            public string Pick_status { get; set; }
            public string Pack_status { get; set; }
            public string Invoice_county_code { get; set; }
            public string Paid { get; set; }
            public Models.Product[] Products { get; set; }
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

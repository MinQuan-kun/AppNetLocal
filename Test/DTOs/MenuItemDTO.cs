using System;

namespace Test.DTOs
{
    public class MenuItemDTO
    {
        public int item_id { get; set; }
        public string food_name { get; set; }
        public int price { get; set; }
        public bool stock { get; set; }
        public string image_url { get; set; }
    }
}
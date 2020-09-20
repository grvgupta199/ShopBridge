using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Web;

namespace ShopBridge.Model
{
    public class Item
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<double> Price { get; set; }
        [DisplayName("Image")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase Image { get; set; } = null;
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime CreatedOn { get; set; }
    }
}

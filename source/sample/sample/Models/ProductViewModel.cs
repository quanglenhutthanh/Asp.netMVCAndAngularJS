using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using core.Entities;
namespace sample.Models
{
    [Serializable]
    public class ProductViewModel
    {
        public int Count { get; set; }
        public List<Product> Result { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMDesktopUI.Library.Models
{
    public class ProductList
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Desc { get; set; }
        public decimal RetialPrice { get; set; }
        public int QunatityInStock { get; set; }
    }
}

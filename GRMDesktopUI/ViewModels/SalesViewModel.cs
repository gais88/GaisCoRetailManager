using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;
        private BindingList<string> _cart;
        private string _itemQuantity;

        public string ItemQuantity
        {
            get { return _itemQuantity; }
            set {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }


        public BindingList<string> Products
        {
            get { return _products; }
            set {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public BindingList<string> Cart
        {
            get { return _cart; }
            set {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        public string SubTotal {
            get
            {
                return "0.00$";
            } }
        public string Total
        {
            get
            {
                return "0.00$";
            }
        }
        public string Tax
        {
            get
            {
                return "0.00$";
            }
        }

        // buttons
        public void AddItem()
        {

        }
        bool CanAddItem
        {
            get
            {
                bool output = false;
                // check if quntity greater 0
                // check if item is selectes
                return output;
            }
        }

        public void RemoveItem()
        {

        }
        bool CanRemoveItem
        {
            get
            {
                bool output = false;
                
                // check if item is selectes
                return output;
            }
        }

        public void CheckOut()
        {

        }
        bool CanCheckOut
        {
            get
            {
                bool output = false;
                // 
                // check if cart not emtpty
                return output;
            }
        }


    }
}

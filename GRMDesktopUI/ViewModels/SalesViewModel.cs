using Caliburn.Micro;
using GRMDesktopUI.Library.Helper;
using GRMDesktopUI.Library.Models;
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
        private IProductEndPoint _productEndPoint;
        public SalesViewModel(IProductEndPoint productEndPoint)
        {
            _productEndPoint = productEndPoint;
        }
        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            loadProducts();
        }
        private async void loadProducts()
        {
            var data = await _productEndPoint.GetAll();
            Products = new BindingList<ProductList>(data);
            
            

        }
        private BindingList<ProductList> _products;
        private BindingList<ProductList> _cart;
        private int _itemQuantity;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }


        public BindingList<ProductList> Products
        {
            get { return _products; }
            set {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public BindingList<ProductList> Cart
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

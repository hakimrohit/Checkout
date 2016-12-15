using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingRules
{
    public class Product
    {
        string _productID;
        string _productDescription;
        double _productPrice;

        public Product() { }

        public Product(string id, string description, double prodValue)
        {
            _productID = id;
            _productDescription = description;
            _productPrice = prodValue;
        }
        
        public string ProductID
        {

            get
            {
                return _productID;
            }


            set
            {
                _productID = value;
            }
        }
        public string ProductDescription
        {

            get
            {
                return _productDescription;
            }


            set
            {
                _productDescription = value;
            }
        }

        public double ProductPrice {
            get
            {
                return _productPrice;
            }


            set
            {
                _productPrice = value;
            }
        }
    }
}

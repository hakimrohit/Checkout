using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingRules
{
    public class FreeProduct
    {
        int _id;
        string _baseProductID;
        int _baseProductQuantity;
        int _quantityToPay;

        public FreeProduct(int id, string baseProductID, int baseProductQuantity, int quantityToPay)
        {
            _id = id;
            _baseProductID = baseProductID;
            _baseProductQuantity = baseProductQuantity;
            _quantityToPay = quantityToPay;
        }

        public int ID
        {
            get { return _id; }

            set { _id = value; }
        }
        public string BaseProductID
        {
            get { return _baseProductID; }

            set { _baseProductID = value; }
        }
        public int BaseProductQuantity
        {
            get { return _baseProductQuantity; }

            set { _baseProductQuantity = value; }
        }
        public int QuantityToPay
        {
            get { return _quantityToPay; }

            set { _quantityToPay = value; }
        }
    }
}

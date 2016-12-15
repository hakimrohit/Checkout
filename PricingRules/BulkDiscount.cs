using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingRules
{
    public class BulkDiscount
    {
        int _id;
        string _baseProductID;
        double _discountPrice;
        int _baseProductQuantity;

        public BulkDiscount(int id,string baseProductID,double discountPrice,int baseProductQuantity)
        {
            _id = id;
            _baseProductID = baseProductID;
            _discountPrice = discountPrice;
            _baseProductQuantity = baseProductQuantity;
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

        public double DiscountPrice
        {
            get { return _discountPrice; }

            set { _discountPrice = value; }
        }

        public int BaseProductQuantity
        {
            get { return _baseProductQuantity; }

            set { _baseProductQuantity = value; }
        }
    }
}

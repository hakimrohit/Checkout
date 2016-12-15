using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingRules
{
    public class FreeBundle
    {
        int _id;
        string _baseProductID;
        string _bundledProductID;
        int _baseQuantity;
        int _bundledQuantity;

        public FreeBundle(int id,string baseProductID, string bundledProductID, int baseQuantity, int bundledQuantity)
        {
            _id = id;
            _baseProductID = baseProductID;
            _bundledProductID = bundledProductID;
            _baseQuantity = baseQuantity;
            _bundledQuantity = bundledQuantity;
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
        public string BundledProductID
        {
            get { return _bundledProductID; }

            set { _bundledProductID = value; }
        }
        public int BaseQuantity
        {
            get { return _baseQuantity; }

            set { _baseQuantity = value; }
        }
        public int BundledQuantity
        {
            get { return _bundledQuantity; }

            set { _bundledQuantity = value; }
        }
    }
}

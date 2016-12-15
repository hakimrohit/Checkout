using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PricingRules;

namespace CheckoutEngine
{
    public class Checkout
    {
        static List<PricingRule> _rules;
        List<Product> _products = new List<Product>();
        List<KeyValuePair<Product, double>> bill = new List<KeyValuePair<Product, double>>();

        public Checkout(List<PricingRule> rules)
        {
            _rules = rules;
            if (_products.Count == 0)
                SetupDemoProductData();
        }
        public void SetupDemoProductData()
        {
            Product Atv = new Product("atv", "Apple TV", 109.50);
            Product Mbp = new Product("mbp", "Macbook Pro", 1399);
            Product Nexus9 = new Product("nx9", "Nexus 9", 549);
            Product HDMI = new Product("hdm", "HDMI Adapter", 30);

            _products.Add(Atv);
            _products.Add(Mbp);
            _products.Add(Nexus9);
            _products.Add(HDMI);
        }
        public void scan(string itemID)
        {
            Product item = _products.Find(x => x.ProductID == itemID);

            List<PricingRule> ProductRules = getRulesForProduct(item);

            foreach (PricingRule rule in ProductRules)
            {
                switch (rule.RuleType)
                {
                    case "FreeBundle": {
                            bill.Add(new KeyValuePair<Product, double>(item, item.ProductPrice));
                            string productBundledID = rule.FreeBundleRuleID.BundledProductID;
                            Product productBundled = _products.Find(x => x.ProductID == productBundledID);
                            bill.Add(new KeyValuePair<Product, double>(productBundled, 0));
                            break;
                        }
                    case "FreeProduct": { 
                            int itemcount1 = bill.Count(x => x.Key.ProductID == item.ProductID);
                            bool itemcheck = ((itemcount1 + 1) % rule.FreeProductRuleID.BaseProductQuantity == 0);
                            if (itemcheck)
                            { 
                                bill.Add(new KeyValuePair<Product, double>(item, 0));
                            }
                            else
                                bill.Add(new KeyValuePair<Product, double>(item, item.ProductPrice));

                            break; }
                    case "BulkDiscount": {
                            bill.Add(new KeyValuePair<Product, double>(item, item.ProductPrice));
                            int itemcount1 = bill.Count(x => x.Key.ProductID == item.ProductID);                            
                            List<KeyValuePair<Product, double>> filteredList1 = new List<KeyValuePair<Product, double>>();

                            if (rule.BulkDiscountRuleID.BaseProductQuantity < itemcount1)
                            {
                                List<KeyValuePair<Product, double>> copyList = new List<KeyValuePair<Product, double>>();
                                foreach (KeyValuePair<Product,double> value in bill)
                                {
                                    copyList.Add(value);
                                }
                                  
                                foreach (KeyValuePair<Product, double> billItems in copyList)
                                {
                                    if (billItems.Key.ProductID == item.ProductID && billItems.Value != rule.BulkDiscountRuleID.DiscountPrice)
                                    {
                                        bill.Remove(billItems);

                                        bill.Add(new KeyValuePair<Product, double>(billItems.Key, rule.BulkDiscountRuleID.DiscountPrice));
                                    }
                                }
                             }
                            break;
                        }
                    default:
                        bill.Add(new KeyValuePair<Product, double>(item, item.ProductPrice));
                        break;
                }
            }
            if(ProductRules.Count == 0)
                bill.Add(new KeyValuePair<Product, double>(item, item.ProductPrice));
        }

        public double Total()
        {
            double finalAmount = 0;
            foreach(KeyValuePair<Product,double> item in bill)
            {
                finalAmount = finalAmount + item.Value;
            }
            return finalAmount;
        }

        public List<PricingRule> getRulesForProduct(Product item)
        {
            List<PricingRule> productrules = new List<PricingRule>();
            foreach (PricingRule rule in _rules)
            {
                if(rule.IsValid && rule.RuleForProduct == item.ProductID)
                {
                    productrules.Add(rule);
                }
            }
            return productrules;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PricingRules;
using CheckoutEngine;

namespace CheckoutConsole
{
    class Program
    {
        static List<PricingRule> pricingRules = new List<PricingRule>();
        

        static void Main(string[] args)
        {
           List<Product> products = new List<Product>();

            Product Atv = new Product("atv", "Apple TV", 109.50);
            Product Mbp = new Product("mbp", "Macbook Pro", 1399);
            Product Nexus9 = new Product("nx9", "Nexus 9", 549);
            Product HDMI = new Product("hdm", "HDMI Adapter", 30);

            products.Add(Atv);
            products.Add(Mbp);
            products.Add(Nexus9);
            products.Add(HDMI);

            setupPricingRulesData();

            var co = new Checkout(pricingRules);

            co.scan("atv");
            co.scan("atv");
            co.scan("atv");
            co.scan("atv");
            co.scan("atv");
            co.scan("atv");

            co.scan("mbp");
            co.scan("nx9");
            co.scan("nx9");
            co.scan("nx9");
            co.scan("nx9");
            co.scan("nx9");
            co.scan("hdm");

            double finalamt = co.Total();
            Console.WriteLine(finalamt.ToString());
            Console.ReadKey();
        }

        public static void setupPricingRulesData()
        {

            PricingRule Rule;

            FreeBundle bundle1 = new FreeBundle(1, "mbp", "hdm", 1, 1);
            Rule = new PricingRule();
            Rule.RuleID = 1;
            Rule.RuleForProduct = "mbp";
            Rule.RuleType = "FreeBundle";
            Rule.FreeBundleRuleID = bundle1;
            Rule.IsValid = true;

            pricingRules.Add(Rule);


            FreeProduct freeprod1 = new FreeProduct(1, "atv", 3, 2);
            Rule = new PricingRule();
            Rule.RuleID = 2;
            Rule.RuleForProduct = "atv";
            Rule.RuleType = "FreeProduct";
            Rule.FreeProductRuleID = freeprod1;
            Rule.IsValid = true;

            pricingRules.Add(Rule);

            BulkDiscount bulkRUle = new BulkDiscount(1, "nx9", 499, 4);
            Rule = new PricingRule();
            Rule.RuleID = 2;
            Rule.RuleForProduct = "nx9";
            Rule.RuleType = "BulkDiscount";
            Rule.BulkDiscountRuleID = bulkRUle;
            Rule.IsValid = true;
            pricingRules.Add(Rule);
        }
    }
}

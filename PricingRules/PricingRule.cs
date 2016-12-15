using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingRules
{
    public class PricingRule
    {
        public int RuleID { get; set; }

        public string RuleForProduct { get; set; }
        public string RuleType { get; set; }
        public FreeBundle FreeBundleRuleID { get; set; }

        public BulkDiscount BulkDiscountRuleID { get; set; }

        public FreeProduct FreeProductRuleID { get; set; }

        public bool IsValid { get; set; }
    }
}

using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems
{
    public class BusinessPriorityTotals : ValueObject
    {
        public BusinessPriorityTotals(int totalBenefit, int totalPenalty, int totalValue, int totalCost, int totalRisk)
        {
            TotalBenefit = totalBenefit;
            TotalPenalty = totalPenalty;
            TotalValue = totalValue;
            TotalCost = totalCost;
            TotalRisk = totalRisk;
        }

        public int TotalBenefit { get; private set; }
        public int TotalPenalty { get; private set; }
        public int TotalValue { get; private set; }
        public int TotalCost { get; private set; }
        public int TotalRisk { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return TotalBenefit;
            yield return TotalPenalty;            
            yield return TotalValue;
            yield return TotalCost;
            yield return TotalRisk;
        }
    }
}

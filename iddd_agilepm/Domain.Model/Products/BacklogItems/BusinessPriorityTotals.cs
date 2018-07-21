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

        public int TotalBenefit { get; }
        public int TotalPenalty { get; }
        public int TotalValue { get; }
        public int TotalCost { get; }
        public int TotalRisk { get; }

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

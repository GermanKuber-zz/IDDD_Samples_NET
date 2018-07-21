using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems
{
    public class BusinessPriority : ValueObject
    {
        public BusinessPriority(BusinessPriorityRatings ratings)
        {
            AssertionConcern.AssertArgumentNotNull(ratings, "The ratings must be provided.");
            Ratings = ratings;
        }

        public BusinessPriorityRatings Ratings { get; }

        public float CostPercentage(BusinessPriorityTotals totals)
        {
            return (float)100 * Ratings.Cost / totals.TotalCost;
        }

        public float Priority(BusinessPriorityTotals totals)
        {
            var costAndRisk = CostPercentage(totals) + RiskPercentage(totals);
            return ValuePercentage(totals) / costAndRisk;
        }

        public float RiskPercentage(BusinessPriorityTotals totals)
        {
            return (float)100 * Ratings.Risk / totals.TotalRisk;
        }

        public float ValuePercentage(BusinessPriorityTotals totals)
        {
            return (float)100 * TotalValue / totals.TotalValue;
        }

        public float TotalValue
        {
            get
            {
                return Ratings.Benefit + Ratings.Penalty;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Ratings;
        }
    }
}

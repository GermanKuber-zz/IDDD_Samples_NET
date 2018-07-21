using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems
{
    public class BusinessPriorityRatings : ValueObject
    {
        public BusinessPriorityRatings(int benefit, int penalty, int cost, int risk)
        {
            AssertionConcern.AssertArgumentRange(benefit, 1, 9, "Relative benefit must be between 1 and 9.");
            AssertionConcern.AssertArgumentRange(penalty, 1, 9, "Relative penalty must be between 1 and 9.");
            AssertionConcern.AssertArgumentRange(cost, 1, 9, "Relative cost must be between 1 and 9.");
            AssertionConcern.AssertArgumentRange(risk, 1, 9, "Relative risk must be between 1 and 9.");

            Benefit = benefit;
            Penalty = penalty;
            Cost = cost;
            Risk = risk;
        }

        public int Benefit { get; }
        public int Penalty { get; }
        public int Cost { get; }
        public int Risk { get; }

        public BusinessPriorityRatings WithAdjustedBenefit(int benefit)
        {
            return new BusinessPriorityRatings(benefit, Penalty, Cost, Risk);
        }

        public BusinessPriorityRatings WithAdjustedCost(int cost)
        {
            return new BusinessPriorityRatings(Benefit, Penalty, cost, Risk);
        }

        public BusinessPriorityRatings WithAdjustedPentality(int penalty)
        {
            return new BusinessPriorityRatings(Benefit, penalty, Cost, Risk);
        }

        public BusinessPriorityRatings WithAdjustedRisk(int risk)
        {
            return new BusinessPriorityRatings(Benefit, Penalty, Cost, risk);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Benefit;
            yield return Penalty;
            yield return Cost;
            yield return Risk;
        }
    }
}

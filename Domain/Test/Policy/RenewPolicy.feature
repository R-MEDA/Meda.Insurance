Feature: Renew Policy
  Scenario Outline: Successful policy renewal
    Given a policy is "<PolicyStatus>" with "<ConsecutiveClaimFreeYears>" claim-free years and a current premium of "<CurrentPremium>"
    When I renew the policy
    Then the new start date is "<NewPolicyStartDate>"
    And the new end date is "<NewPolicyEndDate>"
    And the updated claim-free years are "<UpdatedClaimFreeYears>"
    And the premium change is "<PremiumChange>"
    And the new premium is "<NewPremium>"

    Examples:
      | PolicyStatus | ConsecutiveClaimFreeYears | CurrentPremium | NewPolicyStartDate | NewPolicyEndDate | UpdatedClaimFreeYears | PremiumChange | NewPremium |
      | active       | 1                         | 1200.00        | 2025-03-15         | 2026-03-15       | 2                     | -500.00       | 700.00    |
      | active       | 3                         | 1500.00        | 2024-03-15         | 2025-03-15       | 4                     | -500.00       | 1000.00   |
      | inactive     | 2                         | 1100.00        | N/A                | N/A              | N/A                   | 0.00          | N/A       |

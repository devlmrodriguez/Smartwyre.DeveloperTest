namespace Smartwyre.DeveloperTest.Domain.Specifications;

public class CalculateRebateResult
{
    public bool Success { get; set; }
    public decimal Amount { get; set; }

    public static CalculateRebateResult Succeed(decimal amount) => new CalculateRebateResult { Success = true, Amount = amount };
    public static CalculateRebateResult Fail() => new CalculateRebateResult { Success = false };
}

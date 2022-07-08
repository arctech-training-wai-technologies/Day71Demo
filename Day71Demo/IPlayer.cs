namespace Day71Demo;

public interface IPlayer
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }

    public string FullName { get; }

    public DateTime? DateOfBirth { get; set; }

    public decimal AnnualContractAmount { get; set; }

    public int ContractDurationInYears { get; set; }
}
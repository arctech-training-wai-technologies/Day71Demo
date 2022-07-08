namespace Day71Demo;

public class Player : IPlayer
{
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }

    public string FullName
    {
        get
        {
            if (LastName != null && MiddleName != null)
                return $"{FirstName} {MiddleName} {LastName}";

            if (LastName != null)
                return $"{FirstName} {LastName}";

            if (MiddleName != null)
                return $"{FirstName} {MiddleName}";

            return FirstName;
        }
    }

    public DateTime? DateOfBirth { get; set; }
    public decimal AnnualContractAmount { get; set; }
    public int ContractDurationInYears { get; set; }
}
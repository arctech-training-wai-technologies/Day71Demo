// See https://aka.ms/new-console-template for more information

using Day71Demo;

var players = new List<Player>();

AddDummyData();

do
{
    Console.WriteLine("Main Menu!");
    Console.WriteLine("1. Add Player");
    Console.WriteLine("2. View Players");
    var keyInfo = Console.ReadKey();
    Console.WriteLine();

    switch (keyInfo.KeyChar)
    {
        case '1':
            AddPlayer();
            break;

        case '2':
            ViewPlayers();
            break;
    }

    if (keyInfo.Key == ConsoleKey.Escape)
        break;
} while (true);

void AddPlayer()
{
    var player = new Player();
    Console.Write("Enter First Name: ");
    player.FirstName = Console.ReadLine();

    Console.Write("Enter Last Name: ");
    player.LastName = Console.ReadLine();

    Console.Write("Enter Date Of Birth: ");
    var dateOfBirthText = Console.ReadLine();
    player.DateOfBirth = DateTime.Parse(dateOfBirthText);

    Console.Write("Enter Annual Contract Amount: ");
    var annualContractAmountText = Console.ReadLine();
    player.AnnualContractAmount = decimal.Parse(annualContractAmountText);

    Console.Write("Enter Contract Duration in Years: ");
    var annualContractDuration = Console.ReadLine();
    player.ContractDurationInYears = int.Parse(annualContractDuration);

    players.Add(player);
}

void ViewPlayers()
{
    Console.WriteLine("FullName                    DateOfBirth           Contract          Years");
    Console.WriteLine("-------------------------------------------------------------------------");
    foreach (var player in players)
    {
        Console.WriteLine(
            $"{player.FullName,-28}{player.DateOfBirth,-15:dd-MMM-yyyy}{player.AnnualContractAmount,15:N0}{player.ContractDurationInYears,15}");
    }

    Console.WriteLine("-------------------------------------------------------------------------");
}

void AddDummyData()
{
    players.Add(new Player
    {
        FirstName = @"Mahendra",
        LastName = @"Dhoni",
        DateOfBirth = new DateTime(1975, 10, 15),
        AnnualContractAmount = 5123456,
        ContractDurationInYears = 5
    });

    players.Add(new Player
    {
        FirstName = @"Virat",
        LastName = @"Kohli",
        DateOfBirth = new DateTime(1985, 1, 23),
        AnnualContractAmount = 66553336,
        ContractDurationInYears = 3
    });

    players.Add(new Player
    {
        FirstName = @"Dinesh",
        DateOfBirth = new DateTime(1990, 2, 21),
        AnnualContractAmount = 123456,
        ContractDurationInYears = 1
    });
}
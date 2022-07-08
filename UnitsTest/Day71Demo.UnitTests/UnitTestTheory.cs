namespace Day71Demo.UnitTests;

public class UnitTestTheory
{
    [Theory]
    [InlineData(@"Rohit", null, @"Sharma", @"Rohit Sharma")]
    [InlineData(@"Dinesh", null, null, @"Dinesh")]
    [InlineData(@"Dinesh", @"M", null, @"Dinesh M")]
    [InlineData(@"Dinesh", @"Suraj", @"Shetty", @"Dinesh Suraj Shetty")]
    public void TestFullNameLogic(string firstName, string middleName, string lastName, string expectedFullNameValue)
    {
        //Arrange
        var player = new Player
        {
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName
        };

        //Act
        var actualFullNameValue = player.FullName;

        //Assert
        Assert.Equal(expectedFullNameValue, actualFullNameValue);
    }
}
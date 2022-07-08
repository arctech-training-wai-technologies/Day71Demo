namespace Day71Demo.UnitTests;

public class UnitTestFacts
{
    [Fact]
    public void TestFullNameLogic()
    {
        //Arrange
        var player = new Player
        {
            FirstName = "Rohit",
            LastName = "Sharma"
        };

        const string expectedFullNameValue = "Rohit Sharma";

        //Act
        var actualFullNameValue = player.FullName;

        //Assert
        Assert.Equal(expectedFullNameValue, actualFullNameValue);
    }

    [Fact]
    public void TestFullNameWithNoLastName()
    {
        //Arrange
        var player = new Player
        {
            FirstName = "Dinesh"
        };

        const string expectedFullNameValue = "Dinesh";

        //Act
        var actualFullNameValue = player.FullName;

        //Assert
        Assert.Equal(expectedFullNameValue, actualFullNameValue);
    }

    [Fact]
    public void TestMiddleName1()
    {
        //Arrange
        var player = new Player
        {
            FirstName = "Dinesh",
            MiddleName = "M"
        };

        const string expectedFullNameValue = "Dinesh M";

        //Act
        var actualFullNameValue = player.FullName;

        //Assert
        Assert.Equal(expectedFullNameValue, actualFullNameValue);
    }

    [Fact]
    public void TestMiddleName2()
    {
        //Arrange
        var player = new Player
        {
            FirstName = "Dinesh",
            MiddleName = "Suraj",
            LastName = "Shetty"
        };

        const string expectedFullNameValue = "Dinesh Suraj Shetty";

        //Act
        var actualFullNameValue = player.FullName;

        //Assert
        Assert.Equal(expectedFullNameValue, actualFullNameValue);
    }
}
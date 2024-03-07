namespace LanguageExt_Test;

public class UnitTest1
{
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(10)]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [Theory]
    [DisplayName("Option_Normal")]
    public void Option_Normal(int inputData)
    {
        // Arrange

        // Act

        // Assert
    }

    [Fact]
    [DisplayName("Option_Null")]
    public void Option_Null()
    {
    }

    [InlineData(null)]
    [Theory]
    [DisplayName("Option_None")]
    public void Option_None(string? inputData)
    {
    }
}
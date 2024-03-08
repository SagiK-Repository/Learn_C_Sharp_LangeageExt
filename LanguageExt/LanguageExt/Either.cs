namespace LanguageExt_TEst;

public class Either
{
    public static Either<string, int> ValidateNumber(string input)
    {
        if (int.TryParse(input, out int number))
            return number;
        else
            return $"Invalid number";
    }

    [Fact]
    public void ValidateNumber_ValidInput_ReturnsRight()
    {
        // Arrange
        string input = "123";

        // Act
        Either<string, int> result = ValidateNumber(input);

        result.Match(
            Right: r => r.Should().Be(123),
            Left: s => s.Should().Be("Invalid number")
        );

        // Assert
        result.IsRight.Should().BeTrue();
    }
}

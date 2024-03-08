namespace LanguageExt_TEst;

public class Either
{
    public Either<string, int> ValidateNumber(string input)
    {
        if (int.TryParse(input, out int number))
            return number;
        else
            return "Invalid number";
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
    public Either<Exception, string> GetHtml(string url)
    {
        var httpClient = new HttpClient(new HttpClientHandler());
        try
        {
            var httpResponseMessage = httpClient.GetAsync(url).Result;
            return httpResponseMessage.Content.ReadAsStringAsync().Result;
        }
        catch (Exception ex) { return ex; }
    }

    [Fact]
    public void either_example()
    {

        var leftResult = GetHtml("unknown url"); 
        leftResult.Match(
            Left: ex => ex.Should().BeOfType<InvalidOperationException>(),
            Right: r => Assert.True(true)
        );

        var result = GetHtml("https://www.google.com");

        result.Match(
                Left: ex => ex.Should().BeOfType<InvalidOperationException>(),
                Right: r => Assert.True(true)
            );
    }

    //public async Task<Either<string, int>> ValidateNumberAsync(string input)
    //{
    //    await Task.Delay(100); // 비동기 작업 시뮬레이션

    //    if (int.TryParse(input, out int number))
    //        return number;
    //    else
    //        return "Invalid number";
    //}

    //[Fact]
    //public async Task ValidateNumberAsync_ValidInput_ReturnsRightAsync()
    //{
    //    // Arrange
    //    string input = "123";

    //    // Act
    //    EitherAsync<string, int> result = new EitherAsync<string, int>(await ValidateNumberAsync(input));

    //    // Assert
    //    await result.MatchAsync(
    //        Right: r => r.Should().Be(123),
    //        LeftAsync: async s => 
    //        {
    //                await Task.Delay(100);
    //                s.Should().Be("Invalid number");
    //        });

    //    result.IsRight.Should().Be(true);
    //}
}

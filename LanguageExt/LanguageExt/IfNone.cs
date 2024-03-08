namespace LanguageExt_Test;

public class IfNone
{
    public int GetValue(int? value) => value.IfNone(0);

    public Option<string> GetString(string name)
    {
        Option<string> optionName = name;
        return optionName;
    }

    public string GetStringOrDefault(Option<string> value) => value.IfNone(string.Empty);

    [Fact]
    public void IfNoneOriginal()
    {
        int? number = null;
        number.IfNone(0).Should().Be(0);
    }

    [Fact]
    public void IfNoneMethod_MustReturnSameType()
    {
        int? number = null;
        number.IfNone(() => GetValue(10)).Should().Be(10);
        number.IfNone(() =>
        {
            int num = GetValue(10);
            return num;
        }).Should().Be(10);
    }

    [Fact]
    public void IfNoneMethod()
    {
        string nullString = null;
        Option<string> nullOption = nullString;

        nullOption.IfNone("Is Null").Should().Be("Is Null");

        GetString(null).IfNone("Is Null").Should().Be("Is Null");

        try
        {
            nullOption = Option<string>.Some(null);
        }
        catch (ValueIsNullException e)
        {
            Assert.True(true, e.ToString());
        }

        GetStringOrDefault(null).Should().Be(string.Empty);
        GetStringOrDefault("Test").Should().Be("Test");
    }

    [Fact]
    public void OptionalTest()
    {
        double? nullTemp = null;

        Optional(nullTemp).IfNone(0).Should().Be(0);
    }

    [Fact]
    public async Task IfNoneAsyncTest()
    {
        async Task<int?> asyncReturnTen()
        {
            await Task.Delay(1000);
            return 10;
        }

        async Task<int?> asyncReturnZero()
        {
            await Task.Delay(500);
            return 0;
        }

        var someOption = SomeAsync(asyncReturnTen);
        var noneOption = Option<int?>.None;

        var someResult = await someOption.IfNoneAsync(asyncReturnZero);
        var noneResult = await noneOption.IfNoneAsync(asyncReturnZero);

        someResult.Should().Be(10);
        noneResult.Should().Be(0);
    }
}

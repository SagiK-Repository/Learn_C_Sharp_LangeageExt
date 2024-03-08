namespace LanguageExt_Test;

public class Match
{
    private void FakeMethod1() => Assert.True(true);
    private void FakeMethod2() => Assert.True(true);
    private void FakeMethod3() => Assert.True(true);

    [Fact]
    public void TypeChangeResultData_IntToString()
    {
        int? valuse = null;

        string result = valuse.Match(
          Some: x => (x + 3).ToString(),
          None: () => "Is Null"
        );

        result.Should().Be("Is Null");
    }

    [Fact]
    public void Match_Method()
    {
        Option<string> optionString = null;

        optionString.Match(
            Some: x =>
            {
                FakeMethod1();
                FakeMethod2();
            },
            None: FakeMethod3);
    }

    [Fact]
    public void OptionalTest()
    {
        double? nullTemp = null;

        Optional(nullTemp).Match(
            Some: x => "ss",
            None: () => "").Should().Be("");
    }
}

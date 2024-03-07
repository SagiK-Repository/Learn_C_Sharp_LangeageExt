namespace LanguageExt_Test;
public class TryParse
{
    [Fact]
    public void TryParseTest()
    {
        int normalValue = parseInt("123").IfNone(0);
        normalValue.Should().Be(123);

        int nullValue = ifNone(parseInt(null), 0);
        nullValue.Should().Be(0);
        
        parseInt("123").Match(
          Some: x => x * 2,
          None: () => 0
        ).Should().Be(246);
        
        match(parseInt("123"),
            Some: x => x * 2,
            None: () => 0
        ).Should().Be(246);
    }
}

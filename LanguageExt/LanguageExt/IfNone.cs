namespace LanguageExt;

public class IfNone
{
    public int GetValue(int? value)
    {
        return value.IfNone(0);
    }

    [Fact]
    public void IfNoneTest()
    {
        int? number = null;
        number.IfNone(0).Should().Be(0);
    }
}

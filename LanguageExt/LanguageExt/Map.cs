namespace LanguageExt_Test;

public class Map
{
    public int Squar(int x) => x * x;

    [Fact]
    public void MapTest()
    {
        Option<int> value = 10;
        value.Map(x => x * 1.5f).IfNone(0.0f).Should().Be(15f);

        var values = new List<int>() { 1, 2, 3 };
        var resultList = values.Map(x => x * 2);
        resultList.Should().Equal(new List<int>() { 2, 4, 6 });


        var languageExtList = List(1, 2, 3);
        languageExtList.Map(Squar);
        resultList.Should().Equal(List(2, 4, 6));
    }
}

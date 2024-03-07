namespace LanguageExt_Test;

public record OriginalRecord(int value, string name);

public class LanguageExtRecord : Record<LanguageExtRecord>
{
    public readonly int Value;
    public readonly string Name;

    public LanguageExtRecord(int id, string name)
    {
        Value = id;
        Name = name;
    }
}

public class Record
{
    [Fact]
    public void RecordTest()
    {
        var originalRecord1 = new OriginalRecord(40, "Spongebob");
        var originalRecord2 = new OriginalRecord(40, "Spongebob");

        originalRecord1.Equals(originalRecord2).Should().BeTrue();
        (originalRecord1 == originalRecord2).Should().BeTrue();
        bool a = originalRecord1.name == "s";


        var languageExtRecord1 = new LanguageExtRecord(40, "Spongebob");
        var languageExtRecord2 = new LanguageExtRecord(40, "Spongebob");

        languageExtRecord1.Equals(languageExtRecord2).Should().BeTrue();
        (languageExtRecord1 == languageExtRecord2).Should().BeTrue();
    }
}

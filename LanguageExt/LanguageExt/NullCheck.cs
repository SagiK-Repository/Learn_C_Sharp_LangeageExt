namespace LanguageExt_Test;

public class NullCheck
{
    public string CheckNullMethodToString(Option<object> input) => input.Match(
            Some: o => "is Some",
            None: "is None");

    [Fact(DisplayName = nameof(CheckNullMethod))]
    public void CheckNullMethod()
    {
        List<string> nullList = null;
        List<string> emptyList = new List<string>();
        CheckNullMethodToString(nullList).Should().Be("is None");
        CheckNullMethodToString(emptyList).Should().Be("is Some");
    }

    public class ExampleClass;

    public Option<ExampleClass?> SomeMethod()
    {
        ExampleClass exampleClass = null;
        return Some(exampleClass);
    }

    [Fact(DisplayName = nameof(MethodResultNullCheck))]
    public void MethodResultNullCheck()
    {
        string result = SomeMethod().Match(
            Some: o => "is Some",
            None: "is None"
        );
        result.Should().Be("is None");
    }



    public record ExampleRecord(int value, string name);

    public Option<ExampleRecord> SomeRecordMethod()
    {
        ExampleRecord exampleRecord = new ExampleRecord(10, null);
        return Some(exampleRecord);
    }

    [Fact(DisplayName = nameof(RecordResultNullCheck))]
    public void RecordResultNullCheck()
    {
        string result = SomeRecordMethod().Match(
            Some: o => "is Some",
            None: "is None"
        );
        result.Should().Be("is Some");
    }
}

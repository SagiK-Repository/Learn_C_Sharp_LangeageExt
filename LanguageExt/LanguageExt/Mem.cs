using LanguageExt.Common;

namespace LanguageExt_Test;

public class Mem
{
    static Func<string, string> GenerateGuidForUser = user => user + ":" + Guid.NewGuid();
    static Func<string, string> GenerateGuidForUserMemoized = memo(GenerateGuidForUser);

    static public string GenerateGuidForUserMethod(string user) => user + ":" + Guid.NewGuid();
    public Func<string, string> GenerateGuidForUserMemoizedMethod = memo<string, string>(GenerateGuidForUserMethod);


    [Fact]
    public void Memorization_Test()
    {
        string result = GenerateGuidForUserMemoized("spongebob");
        GenerateGuidForUserMemoized("spongebob").Should().Be(result);

        string resultString = GenerateGuidForUserMemoizedMethod("spongebob");
        GenerateGuidForUserMemoizedMethod("spongebob").Should().Be(resultString);

        string notMatchString = GenerateGuidForUser("Hello");
        GenerateGuidForUser("Hello").Should().NotBe(notMatchString);
    }

    [Fact]
    public void Memorization_LiveTest()
    {
        string result = string.Empty;
        {
            Func<string, string> MemoizedMethod = memo(GenerateGuidForUser);
            result = MemoizedMethod("spongebob");
        }

        Func<string, string> AfterMemoizedMethod = memo(GenerateGuidForUser);
        AfterMemoizedMethod("spongebob").Should().NotBe(result);
    }

    static Func<string, Task<string>> GenerateGuidForUserAsync = async user =>
    {
        await Task.Delay(100);  // 비동기 작업을 시뮬레이션합니다.
        return user + ":" + Guid.NewGuid();
    };

    [Fact]
    public async Task Memorization_AsyncTest()
    {
        Func<string, Task<string>> MemoizedMethod = memo(GenerateGuidForUserAsync);
        string result = await MemoizedMethod("spongebob");
        string afterResult = await MemoizedMethod("spongebob");
        result.Should().Be(afterResult);
    }
}

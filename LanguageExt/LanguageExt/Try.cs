namespace LanguageExt_Test;

public class Try
{
    private void FakeMethod1() => Assert.True(false);
    private void FakeMethod2() => Assert.True(true);
    private void FakeMethod3() => Assert.True(true);

    [Fact]
    public void OriginalTryCatch()
    {
        try
        {
            int a = 10;
            int b = 0;
            int result = a / b;
            FakeMethod1();
        }
        catch (DivideByZeroException ex)
        {
            FakeMethod2();
        }
        catch (Exception ex)
        {
            FakeMethod2();
        }
        finally
        {
            FakeMethod3();
        }
    }

    [Fact]
    public void Divide_ByZero_ReturnsError()
    {
        Try<int> result = Try(() =>
        {
            int a = 10;
            int b = 0;
            int res = a / b; // 0으로 나누기 예외 발생
            return res;
        });

        result.Match(
            Succ: value =>
            {
                FakeMethod1();
            },
            Fail: ex =>
            {
                if (ex is DivideByZeroException divideByZeroException)
                {
                    FakeMethod2();
                }
                else
                {
                    FakeMethod2();
                }
            });

        FakeMethod3();
    }
}

﻿namespace LanguageExt_Test;

public class OptionUsage
{
    private void FakeMethod1() => Assert.True(true);
    private void FakeMethod2() => Assert.True(true);
    private void FakeMethod3() => Assert.True(false);

    private bool IsEmail_Original(string email)
    {
        if (string.IsNullOrEmpty(email))
            return false;

        if (email.Contains(" "))
            return false;

        string[] parts = email.Split('@');
        if (parts.Length != 2)
            return false;

        string[] domainParts = parts[1].Split('.');
        if (domainParts.Length < 2)
            return false;

        return true;
    }

    [Fact]
    [DisplayName("Original C#")]
    public void Original_CheckNullMethod()
    {
        if (IsEmail_Original("Park@mirero.com"))
            FakeMethod1();
        else
            Assert.True(false);
    }



    private bool IsEmail(string email)
    {
        return Option<string>.Some(email)
            .Bind(IsEmailHaveAt)
            .Bind(IsHaveDomailDot)
            .Match(
                Some: x => true,
                None: false
            ); // true와 false의 의미를 명확히 합니다.
    }

    private Option<string> IsEmailHaveAt(string email)
    {
        string[] parts = email.Split('@');
        if (parts.Length != 2)
            return Option<string>.None;

        return Option<string>.Some(email);
    }
    private Option<string> IsHaveDomailDot(string email)
    {
        string[] domainParts = email.Split('@')[1].Split('.');
        if (domainParts.Length < 2)
            return Option<string>.None;

        return Option<string>.Some(email);
    }

    [Fact]
    [DisplayName("None인 경우와 Some인 경우 처리를 묶어서 처리하는 경우")]
    public void CheckNullMethod()
    {
        if (IsEmail("Park@mirero.com"))
            FakeMethod1();
        else
            Assert.True(false);
    }


    private Option<string> IsEmailOut(string email)
    {
        Option<string> emailOption = email;

        if (emailOption.IsNone)
            return None;

        if (email.Contains(" "))
            return None;

        string[] parts = email.Split('@');
        if (parts.Length != 2)
            return None;

        string[] domainParts = parts[1].Split('.');
        if (domainParts.Length < 2)
            return None;

        return emailOption;
    }

    [Fact]
    [DisplayName("이후 Null 제어관련 로직이 필요한 경우")]
    public void Method_And_CheckNull()
    {
        IsEmailOut("Park@mirero.com").Match(
            Some : x =>
            {
                FakeMethod1();
                FakeMethod2();
            },
            None : FakeMethod3);

        IsEmailOut("IsNotEmail").IfNone(() => Assert.True(true));
        IsEmailOut(null).IfNone(() => Assert.True(true));
    }
}

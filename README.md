문서정보 : 2024.03.05.~03.06. 작성, 작성자 [@SAgiKPJH](https://github.com/SAgiKPJH)

- 요약 - 당장 사용 가능한지 분석한 결과 : [LanguageExt 심화](https://github.com/SagiK-Repository/Learn_C_Sharp_LangeageExt/issues/1)

# Language.Ext

# 🚌Language.Ext?

- C#을 확장하여 `함수형 프로그래밍`을 지원하기 위한 라이브러리입니다.
  - 함수형 프로그래밍의 '베이스 클래스 라이브러리'를 제공합니다.
- GitHub 사이트 : https://github.com/louthy/language-ext

### 🤖작성자 Paul Louth은 말한다.

> Paul Louth : C# 프로그래밍을 훨신 더 안정적이고, 코드 작성시 엔지니어의 관성이 명령형이 아닌 선언형이고 기능적이길 바랍니다.

<br>

# 🛻함수형 프로그래밍

- 함수형 프로그래밍(FP : Functional Programming)

> 자료 처리를 수학적 함수의 계산으로 취급하고 상태와 가변 데이터를 멀리하는 프로그래밍 패러다임의 하나입니다.
> - Wikipedia

## 특징

- 수학적 함수 계산을 기반으로 합니다.
- `상태와 가변 데이터를 피하는 방식`입니다.
- **순수함수**
  - `함수의 결과값은 오직 입력값에만 의존`합니다.
  - `외부 환경에 영향을 받지 않습니다.`
  - 순수 함수는 참조에 대해 투명하며, 프로그램의 예측성과 투명성을 높입니다.
- **고차 함수**
  - 함수를 다루는 함수
  - 함수를 인수로 받거나 결과로 반환 가능
  - 함수의 추상화와 재사용성을 증가
- **지연 평가**
  - 함수의 인수를 필요할 때까지 평가하지 않고, `실제 사용하는 사점에 평가`
  - 따라서 무한한 데이터 구조를 다룰 수 있습니다.
- **타입 시스템**
  - 함수형 언어는 대부분 정적 타입 검사를 지원
  - 타입 추론을 통해 타입을 자동으로 결정할 수 있다.
  - 프로그램의 정확성과 안정성을 보장

<br><br>

# 🚜Language.Ext 첫 인사

- Nuget Package에 LanguageExt.Core를 추가합니다.
- 다음 using을 필수로 선언해줍니다.
```cs
using LanguageExt;
using static LanguageExt.Prelude;
```
- 다음 코드를 작성해 확인합니다.
```cs
Option<int> x = Some(123);
Option<int> y = None;

Seq<int> items = Seq(1,2,3,4,5);
List<int> items = List(1,2,3,4,5);
HashMap<int, string> dict = HashMap((1, "Hello"), (2, "World"));
Map<int, string> dict = Map((1, "Hello"), (2, "World"));

var x
 = map(opt, v => v * 2);
// or
var x = opt.Map(v => v * 2);
```

<br><br>

# 🚒Language.Ext 특징

1. 함수형 효과와 IO
   - 함수형 프로그래밍에서 중요한 개념인 효과(effect)와 입출력(IO)을 다룹니다.
   - `Aff<A>` `Eff<A>` `Aff<RT,A>` `Eff<RT, A>` `Pipes`
2. 원자성 동시성과 컬렉션
   - 원자성(atomicity)을 보장하는 동시성(concurrency) 기능과 컬렉션을 제공합니다.
   - `Atom<A>` `Ref<A>` `AtomHashMap<K, V>` `AtopSeq<A>` `VectorClock<A>` `VersionVector<A>` `VersionHashMap <ConflictV, K, V>`
3. 불변 컬렉션
   - 불변성(immutable)을 가진 컬렉션을 제공합니다.
   - `Arr<A>` `Seq<A>` `Lst<A>` `Map<K, V>` `Map<OrdK, K, V>` `HashMap<K, V>` `HashMap<EqK, K, V>` `Set<A>` `Set<OrdA, A>` `HashSet<A>` `HashSet<EqA, A>` `Que<A>` `Stck<A>`
4. 옵셔널 및 대체 값 모나드
   - 옵셔널(optional)과 대체 값(alternative value)을 다루는 모나드를 제공합니다.
   - `Option<A>` `OptionAsync<A>` `OptionUnsafe<A>` `Either<L, R>` `EitherUnsae<L, R>` `EitherAsync<L, R>`
   - `Try<A>` `TryAsync<A>` `TryOption<A>` `TryOptionAsync<A>` `Validation<FAIL, SUCCESS>` `Validation<MonoidFail, FAIL, SUCCESS>`
5. 상태 관리 모나드
   - 상태(state)를 관리하는 모나드를 제공합니다.
   - `Reader<E, A>` `Writer<MonoidW, W, T>` `State<S, A>` `RWS<R, W, S, A>`
6. 파서 콤비네이터
   - 파서(parser)를 조합하는 콤비네이터(combinator)를 제공합니다.
   - `Parser<A>` `Parser<I, O>`
7. 타입 별칭
   - 새로운 타입을 만드는 타입 별칭(type aliasing) 기능을 제공합니다.
   - `NewType<SELF, A, PRED>` `NumType<SELF, NUM, A, PRED>` `FloatType<SELF, FLOATING, A, PRED>`
8. 코드 생성
   - 레코드, 유니온, 프리 모나드, 렌즈 등을 위한 코드 생성 기능을 제공합니다.
   - `Records` `Unions` `Free monads` `Reader` `RWS` `With` `WithLens` `Lens<A, B>` `Record<A>`
9. 기타
   - Pretty : `Doc<A>`
   - Differencing : `Patch<EqA, A>`
10. C# 확장

<br><br>

# 🚑LanguageExt 실 사용

## Linq와의 유사성
- 다음 키워드는 Linq와 동일합니다.
- `Sum`, `Count`, `Bind`, `Exists`, `Filter`, `Fold`, `ForAll`, `Iter`, `Map`, `Lift/LiftUnsafe`, `Select`, `SelectMany`, `Where`

<br>

## 간편한 record types 생성
- C#에서 Record의 `Equals, GetHashCode, IEquatable<A>, IComparer<A>, 연산자 ==, !=, <, <=, >=, >`를 구현하는 것은 쉽지 않습니다.
- 이를 쉽게 해줍니다.
- 기존
  ```cs
    public class User
    {
        public readonly Guid Id;
        public readonly string Name;
        public readonly int Age;

        public User(Guid id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
  ```
- LaunguageExt
  ```cs
    public class UserRecord : Record<UserRecord>
    {
        public readonly Guid Id;
        public readonly string Name;
        public readonly int Age;

        public UserRecord(Guid id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
  ```
- UnitTest
  ```cs
    [Fact]
    public void record_types()
    {
        var spongeGuid = Guid.NewGuid();

        // Use Original C#
        var spongeBob = new User(spongeGuid, "Spongebob", 40);
        var spongeBob2 = new User(spongeGuid, "Spongebob", 40);

        Assert.False(spongeBob.Equals(spongeBob2));

        // Use immutable records available in Language-ext
        var spongeBobRecord = new UserRecord(spongeGuid, "Spongebob", 40);
        var spongeBobRecord2 = new UserRecord(spongeGuid, "Spongebob", 40);

        Assert.True(spongeBobRecord.Equals(spongeBobRecord2));
    }
  ```

<br>

## 쉬운 Parse

- C#의 `TryParse`를 대체합니다.
  ```cs
  int res = parseInt("123").IfNone(0);
  // or
  int res = ifNone(parseInt("123"), 0);
  // or
  int res = parseInt("123").Match(
    Some : x => x * 2,
    None : () => 0
  );
  // or
  int res = match( parseInt("123"),
                   Some : x => x * 2,
                   None : () => 0);
  ```

<br>

## Option 활용한 null 제어

- Option은 F#에도 존재합니다. 기능적 언어에서는 null 값을 허용하지 않습니다.
  ```cs
  Option<int> aValue = 2;
  aValue.Map(x => x + 3); // Some(5)
  
  Option<int> none = None;
  none.Map(x => x + 3); // None
  
  //Left -> Some, Right -> None
  aValue.Match(x => x + 3, () => 0); // 5
  none.Match(x => x + 3, () => 0); // 0
  
  // Returns the Some case 'as is' -> 2 and 1 in the None case
  int value = aValue.IfNone(1);
  int noneValue = none.IfNone(42); // 42
  
  int value = aValue.Match(
    Some : x => x + 3,
    None : () => 0
  );

  int x = optional
    .Some( v  => v + 3 )
    .None( () => 0 );
  ```
- Match
  - 기존 Type와 매칭
- Map
  1. 기존 Type와 매칭
  2. 또는 논리를 수행
  - 심화
    - Option이 None이면 Linq가 호출되지 않습니다.
    - Option은 if를 대체하기에, if obj == null와 같은 의미로 구성되어 있습니다.

<br>

## List Or Fucnctors

- List 따위를 매핑 가능합니다.
  ```cs
  new int[] { 2, 4, 6 }.Map(x => x + 3); // 5,7,9
  new List<int> { 2, 4, 6 }.Map(x => x + 3); // 5,7,9
  //Prefer use List (Immutable list)
  List(2, 4, 6).Map(x => x + 3); // 5,7,9

  List(2, 4, 6)
    .Map(x => Add5(x)) // 7, 9, 11
    .Map(x => Add3(x)) // 10, 12, 14
    .Map(x => Add2(x)) // 12, 14, 16
    .Map(x => Add5(x));// 17, 19, 21
  ```

<br>

## 함수 구성 (Compose)

- 함수에서 map을 통해 함수 합성 수행
  ```cs
  static Func<int, int> Add2 = x => x + 2;
  static Func<int, int> Add3 = x => x + 3;

  static int Add5(int x) => Add2.Compose(Add3)(x);
  ```

<br>

## 묶음 (Bind)

- Monads는 입력한 래핑한 값(Option<double>) 그대로 같은 Type로 나옵니다.
- Bind로 묶어 실행할 수 있습니다.
  ```cs
  static Option<double> Half(double x)
      => x % 2 == 0 ? x / 2 : Option<double>.None;
  
  [Fact]
  public void bind_monad()
  {
      Option<double>.Some(3).Bind(x => Half(x));// None
      Option<double>.Some(4).Bind(x => Half(x));// Some(2)
  }
  
  [Fact]
  public void chain_bind_monad()
  {
      Option<double>.Some(20)
          .Bind(x => Half(x))// Some(10)
          .Bind(x => Half(x))// Some(5)
          .Bind(x => Half(x));// None
  }
  ```

<br>

## Try

- 더 쉽게 Try 예외처리 가능합니다.
- 더이상 Try Catch 필요하지 않습니다.
- 정말 읽기 쉬운 형식으로 파이프 라인을 설명 가능합니다.
  ```cs
  public void file_monad_example()
  {
      GetLine()
          .Bind(ReadFile)
          .Bind(PrintStrln)
          .Match(success => Console.WriteLine("SUCCESS"), // Try Success
                  failure => Console.WriteLine("FAILURE")); // Catch
  }
  
  static Try<string> GetLine()
  {
      Console.Write("File:");
      return Try(() => Console.ReadLine());
  }
  
  static Try<string> ReadFile(string filePath) => Try(() => File.ReadAllText(filePath));
  
  static Try<bool> PrintStrln(string line)
  {
      Console.WriteLine(line);
      return Try(true);
  }
  ```

<br>

## Memoization - 캐싱

- Memoization는 일종의 캐싱입니다.
- 특정 기능을 메모하면, 특정 입력에 대해 메모 한 뒤, 동일한 입력이 들어오면 메모한 내용(캐싱)을 반환합니다.
  ```cs
  static Func<string, string> GenerateGuidForUser = user => user + ":" + Guid.NewGuid();
  static Func<string, string> GenerateGuidForUserMemoized = memo(GenerateGuidForUser);
  
  [Fact]
  public void memoization_example()
  {
      GenerateGuidForUserMemoized("spongebob");// spongebob:e431b439-3397-4016-8d2e-e4629e51bf62
      GenerateGuidForUserMemoized("buzz");// buzz:50c4ee49-7d74-472c-acc8-fd0f593fccfe
      GenerateGuidForUserMemoized("spongebob");// spongebob:e431b439-3397-4016-8d2e-e4629e51bf62
  }
  ```

<br>

## 기능 부분 적용

- 일부 인수를 부분 설정하여 새 기능을 만들 수 있습니다.
  ```cs
  static Func<int, int, int> Multiply = (a, b) => a * b;
  static Func<int, int> TwoTimes = par(Multiply, 2);
  
  [Fact]
  public void partial_app_example()
  {
      Multiply(3, 4); // 12
      TwoTimes(9); // 18
  }
  ```

<br>

## Either (어느 하나)

- 성공사례(오른쪽)와 실패사례(왼쪽) 두 가지 유형의 값을 나타냅니다.
  ```cs
  public static Either<Exception, string> GetHtml(string url)
  {
      var httpClient = new HttpClient(new HttpClientHandler());
      try
      {
          var httpResponseMessage = httpClient.GetAsync(url).Result;
          return httpResponseMessage.Content.ReadAsStringAsync().Result;
      }
      catch (Exception ex) { return ex; }
  }
  
  [Fact]
  public void either_example()
  {
  
      GetHtml("unknown url"); // Left InvalidOperationException
      GetHtml("https://www.google.com"); // Right <!doctype html...
  
      var result = GetHtml("https://www.google.com");
  
      result.Match(
              Left: ex => Console.WriteLine("an exception occured" + ex),
              Right: r => Console.WriteLine(r)
          );
  }
  ```

<br>

## Fold vs Reduce

- List.fold : ('State -> 'T -> 'State) -> 'State -> 'T -> 'T list -> 'State
- List.reduce : ('T->'T->'T) -> 'T list -> 'T
  ```cs
  [Fact]
  public void fold_vs_reduce()
  {
      //fold takes an explicit initial value for the accumulator
      //Can choose the result type
      var foldResult = List(1, 2, 3, 4, 5)
          .Map(x => x * 10)
          .Fold(0m, (x, s) => s + x); // 150m
  
      //reduce uses the first element of the input list as the initial accumulator value
      //Result type will be the one of the list
      var reduceResult = List(1, 2, 3, 4, 5)
          .Map(x => x * 10)
          .Reduce((x, s) => s + x); // 150
  }
  ```

<br><br>

# 🚜추가내용

## TryOption

- Try의 예외처리 기능과 Option의 null 처리 기능이 합친 내용입니다.
  ```cs
  public TryOption<string> GetEmail(long id)
  {
    return Try(() => GetById(id))
            .Map(person => person.Email)
            .ToTryOption();
  }

  public void SendEmail(long personId)
  {
    GetEmail(personId)
      .Match(email =>
      {
        emailService.SendWelcome(email);
        logger.LogSuccess($"Email sent for {personId}");
      },
      () => logger.LogSuccess($"Email not sent for {personId}"),
      exception => logger.LogSuccess($"Error for {personId} {exception}");
      )
  }
  ```
  
<br>


# 활용 예시
- 다중 Null Check -> Option의 Bind 기능 활용하기
- Before
  ```cs
  public string Register(long personId)
  {
    try
    {
      var person = personRepository.GetId(personId);
      if (person == null)
      {
        return null;
      }
      
      var account = twitterService.Register(person.Email, person.Name);
      if (account == null)
      {
        return null;
      }

      var token = twitterService.Authenticate(person.Email, person.Password);
      if (token == null)
      {
        return null;
      }

      var tweet = twitterService.Tweet(token, "Hello les cocos");

      personRepository.Update(personId, account.Id);
      logger.LogSuccess($"User {personID} registered");

      return tweet.Url;
    }
    catch (Exception ex)
    {
      logger.LogFailure($"Unable to register user : {personId} {ex.Message}");
      return null;
    }
  }
  ```
- After
  ```cs
        private TryAsync<Context> CreateContext(long personId)
        {
            return TryAsync(() => personRepository.GetById(personId))
                    .Map(person => new Context(person));
        }

        private TryAsync<Context> RegisterTwitter(Context context)
        {
            return TryAsync(() => twitterService.Register(context.Email, context.Name))
                    .Map(account => context.SetAccount(account));
        }

        private TryAsync<Context> Authenticate(Context context)
        {
            return TryAsync(() => twitterService.Authenticate(context.Email, context.Password))
                    .Map(token => context.SetToken(token));
        }

        private TryAsync<Context> Tweet(Context context)
        {
            return TryAsync(() => twitterService.Tweet(context.Token, "Hello les cocos"))
                    .Map(tweet => context.SetTweet(tweet));
        }

        private TryAsync<Context> UpdateParty(Context context)
        {
            return TryAsync(async () =>
            {
                await personRepository.Update(context.Id, context.AccountId);
                return context;
            });
        }

        public async Task<string> Register(long personId)
        {
            string result = string.Empty;
            await CreateContext(personId)
                    .Bind(RegisterTwitter)
                    .Bind(Authenticate)
                    .Bind(Tweet)
                    .Bind(UpdateParty)
                    .Match(
                    context =>
                    {
                        logger.LogSuccess($"User {personId} registered");
                        result = context.Url;
                    },
                    exception => logger.LogFailure($"Unable to register user : {personId} {exception.Message}"));

            return result;
        }
  ```


<br><br>


# 🚃Async


## OptionAsync
- Option의 Async

## TryAsync
- Try의 Async

## Aff, Eff

- Aff, Eff 타입은 사이드 이펙트를 포착하기 위해 만들어진 모나드입니다.
- 함수형 프로그래밍에서 중요한 원칙 중 하나인 사이드 이펙트가 없는 코드 작성을 돕습니다.
```cs
using LanguageExt;
using static LanguageExt.Prelude;

Aff<int> Add(int x, int y) => Aff<int>(
    async () =>
    {
        await Task.Delay(1000); // Simulate some latency
        return x + y;
    });

var add = Add(10, 20);

var result = await add.Run(); // returns 30
Console.WriteLine($"Result = {result}"); // Result = Succ(30)
```
```cs
using LanguageExt;
using static LanguageExt.Prelude;

Eff<int> Add(int x, int y) => Eff<int>(
    () =>
    {
        return x + y;
    });

var add = Add(10, 20);

var result = add.Run(); // returns 30
```
```cs
public interface FileIO
{
    ValueTask<string[]> ReadAllLinesAsync(string path);
    ValueTask<Unit> WriteAllLinesAsync(string path, string[] lines);
}

public static class FileAff
{
    static readonly FileIO injected;
    
    public static Aff<Seq<string>> readAllLines(string path) =>
        Aff(async () => (await injected.ReadAllLinesAsync(path)).ToSeq());
    
    public static Aff<Unit> writeAllLines(string path, Seq<string> lines) =>
        Aff(async () =>
        {
            await injected.WriteAllLinesAsync(path, lines.ToArray());
            return unit;
        });
}
```

## Task 확장

<br><br>


<br><br>

# 🚲참고자료

- https://github.com/louthy/language-ext
- https://yoan-thirion.gitbook.io/knowledge-base/serious-games/how-to-create-a-game
- https://github.com/ythirion/fp-in-csharp-sandbox





<br><br>


---

<br><br>

# 심화 기술

- match
```cs
    Option<int> two = Some(2);
    Option<int> four = Some(4);
    Option<int> six = Some(6);
    Option<int> none = None;

    // This expression succeeds because all items to the right of 'in' are Some of int
    // and therefore it lands in the Some lambda.
    int r = match( from x in two
                   from y in four
                   from z in six
                   select x + y + z,
                   Some: v => v * 2,
                   None: () => 0 );     // r == 24

    // This expression bails out once it gets to the None, and therefore doesn't calculate x+y+z
    // and lands in the None lambda
    int r = match( from x in two
                   from y in four
                   from _ in none
                   from z in six
                   select x + y + z,
                   Some: v => v * 2,
                   None: () => 0 );     // r == 0
```
- Function 순서
```cs
var add = (int x, int y) => x + y; // Func<int, int, int>

var add = fun( (inr x, int y) => x + y );

var long = act( (int x) => Console.WriteLine(x) );
```

<br>

### 불변의 변환

- With
```cs
public class A
{
    public readonly X X;
    public readonly Y Y;

    public A(X x, Y y)
    {
        X = x;
        Y = y;
    }

    public A With(X X = null, Y Y = null) =>
        new A(
            X ?? this.X,
            Y ?? this.Y
        );
}
```
```cs
val = val.With(X: x);

val = val.With(Y: y);

val = val.With(X: x, Y: y);
```
- [With]
  - Nuget 참조 추가 : LanguageExt.CodeGen (최종 빌드에 미포함, 순전히 코드 생성 목적)
```cs
[With]
public partial class A
{
    public readonly X X;
    public readonly Y Y;

    public A(X x, Y y)
    {
        X = x;
        Y = y;
    }
}
```
- Lens 활용한 getter, setter 캡슐화
```cs
[With]
public partial class Person
{
    public readonly string Name;
    public readonly string Surname;

    public Person(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }

    public static Lens<Person, string> name =>
        Lens<Person, string>.New(
            Get: p => p.Name, // 핵심부분
            Set: x => p => p.With(Name: x));  // 핵심부분

    public static Lens<Person, string> surname =>
        Lens<Person, string>.New( 
            Get: p => p.Surname,  // 핵심부분
            Set: x => p => p.With(Surname: x));  // 핵심부분
}
```
```cs
var person = new Person("Joe", "Bloggs");

var name = Person.name.Get(person);
var person2 = Person.name.Set(name + "l", person);  // Joel Bloggs
var person3 = Person.name.Update(name => name + "l", person);  // Joel Bloggs
```
- [WithLens]
```cs
[WithLens]
public partial class Person : Record<Person>
{
    public readonly string Name;
    public readonly string Surname;
    public readonly Map<int, Appt> Appts;

    public Person(string name, string surname, Map<int, Appt> appts)
    {
        Name = name;
        Surname = surname;
        Appts = appts;
    }
}

[WithLens]
public partial class Appt : Record<Appt>
{
    public readonly int Id;
    public readonly DateTime StartDate;
    public readonly ApptState State;

    public Appt(int id, DateTime startDate, ApptState state)
    {
        Id = id;
        StartDate = startDate;
        State = state;
    }
}

public enum ApptState
{
    NotArrived,
    Arrived,
    DNA,
    Cancelled
}
```
```cs
// Generate a Person with three Appts in a Map
var person = new Person("Paul", "Louth", Map(
    (1, new Appt(1, DateTime.Parse("1/1/2010"), ApptState.NotArrived)),
    (2, new Appt(2, DateTime.Parse("2/1/2010"), ApptState.NotArrived)),
    (3, new Appt(3, DateTime.Parse("3/1/2010"), ApptState.NotArrived))));

// Local function for composing a new lens from 3 other lenses
Lens<Person, ApptState> setState(int id) => 
    lens(Person.appts, Map<int, Appt>.item(id), Appt.state);

// Transform
var person2 = setState(2).Set(ApptState.Arrived, person);
```

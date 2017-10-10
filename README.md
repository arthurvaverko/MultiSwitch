# MultiSwitch
A fluent api that will help you to match patterns of primitives.
So basically a switch statement with multiple variables.

Inspired by @anton-gogolev at https://stackoverflow.com/a/7967689/605129

### Basic usage example
```C#
public void ShouldFindOneMatch()
{
    var correctMatchWasExecuted = false;
    const int i = 1;
    const int j = 34;
    const bool k = true;
    MultiSwitch.Match(i, j, k).
        With(1, 2, false).Do(() => Console.WriteLine("1, 2, 3")).
        With(1, 34, false).Do(() => Console.WriteLine("1, 34, false")).
        With(1, 34, true).Do(() =>
        {
            Console.WriteLine("1, 34, true");
            correctMatchWasExecuted = true;
        });

    Assert.That(correctMatchWasExecuted);

}
```

### Usage with default action
```C#
public void ShouldExecuteDefault()
{
    var defaultWasExecuted = false;

    const int i = 1;
    const int j = 34;
    const bool k = true;
    MultiSwitch.Match(i, j, k).
        With(1, 2, false).Do(() => Console.WriteLine("1, 2, 3")).
        With(1, 34, false).Do(() => Console.WriteLine("1, 34, false")).
        Default(() =>
        {
            Console.WriteLine("This is default action if not match found");
            defaultWasExecuted = true;
        });

    Assert.That(defaultWasExecuted);
}
```
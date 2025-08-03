# ZugZug
...as [trusty Orcs say](https://wowpedia.fandom.com/wiki/Orcish_(language)).

This repository exists for learning [c#](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/). Any comments about e.g.:
- how to improve in c#
- how to organize code better
- naming conventions
- expected formatting
- ...

are highly appreciated.

## Arbitrary code style considerations

### Variable declarations
I'm aware of three options to declare a variable:
```cs
// 1
Int32 parsed_duration_minutes = Int32.Parse( duration_minutes );

// 2
Int32 parsed_duration_minutes = Parse( duration_minutes );

// 3
var parsed_duration_minutes = Int32.Parse( duration_minutes );
```

As far as I'm aware all three are identical. I prefer variant 1 for the following reasons:
- I read a line from left to right, therefore 1 and 2 allow me to see the exact type right away. This way I know the specific goal of the line right away. `var` on the other hand "hides" this.
- I prefer the explicit declaration. Maybe this'll change when I'm more comfortable with the language, but for now I'd like to see the origin of a method directly.

# WhatIsHeDoing.Core

[![NuGet package](https://img.shields.io/NuGet/v/WhatIsHeDoing.Core.svg)](https://www.NuGet.org/packages/WhatIsHeDoing.Core/ 'NuGet package')
[![NuGet downloads](https://img.shields.io/NuGet/dt/WhatIsHeDoing.Core.svg)](https://www.NuGet.org/packages/WhatIsHeDoing.Core/ 'NuGet downloads')
[![AppVeyor Windows build status](https://ci.AppVeyor.com/api/projects/status/xshdrvqh387kqioe?svg=true)][AppVeyor]
[![Codecov code coverage](https://codecov.io/gh/WhatIsHeDoing/WhatIsHeDoing.Core/branch/live/graph/badge.svg)](https://codecov.io/gh/WhatIsHeDoing/WhatIsHeDoing.Core 'Codecov code coverage')
[![Travis CI Linux build status](https://Travis-ci.org/WhatIsHeDoing/WhatIsHeDoing.Core.svg)][Travis]
[![Codenvy badge](https://Codenvy.io/factory/resources/Codenvy-contribute.svg)][Codenvy]

A library of extensions to core .NET functionality.

## 👋 Introduction

The core .NET libraries - those that are available on most .NET runtime versions and environments -
are very feature-rich. However, there are times when you need a little helper function, and the list
of those functions slowly grows. Rather than having disparate collections of them, this project seeks
to group them under the `WhatIsHeDoing.Core` namespace, complete with unit tests in the `WhatIsHeDoing.Core.Tests`
project.

## 📡 Live Demo

Take a look at the editable code examples at [.NET Fiddle].

## 🦮 Usage

### Installing

This package is available via [NuGet].

### Methods

#### Extensions

##### DateTime

* `GetNextWeekday`: Gets the date at the next weekday supplied.
* `PeriodsBetween`: Generates the periods between two date times.

##### IEnumerable

* `Aggregate`: Aggregate with the index of the current element.
* `IterateJagged`: Flattens a collection of collections of unequal lengths after calling `ZipJagged`.
* `Randomise`: Returns a randomised order of the collection.
* `WhereNotNull`: Filters all null elements from a collection.
* `ZipJagged`: Enables a collection of unequal collection lengths to be iterated together, effectively as columns.

##### Integer

* `ToNearestCeiling`: Rounds to the largest comparison number.

##### Long

* `Length`: Determines the length of a positive number.
* `StripDigits`: Strips a specified number of digits from a number.

##### Object

* `AsFluent`: Calls any action fluently, such as void functions, so that calls can be chained to other
members of object.

##### String

* `AsCurrency`: Formats a string as a currency from the current globalisation.
* `IsTrue`: Determines whether this string can be converted to a boolean and that value is true.
* `Parse`: Invoke a Parse method from the TResult type on the value.
* `ToBytes`: Converts a string representation of a byte array - comma-separated values - to an actual byte array.
* `TryParse`: Tries to invoke a Parse method from the TResult type on the value.

##### Unsigned Long

* `Length`: Determines the length of a number.
* `StripDigits`: Strips a specified number of digits from a number.

## ⭐ Other Projects

Missing something? Have you tried these excellent projects?

* [Humanizr]: Humanizer meets all your .NET needs for manipulating and displaying strings, enums, dates,
times, timespans, numbers and quantities.
* [NodaTime]: A better date and time API for .NET.

## 🆘 Contributing

All contributions are greatly welcomed! Please see the [guidelines][contributing] for more information.

If you are developing locally, pull down this repo and build within Visual Studio (any edition), or
run `dotnet test` on any platform; the `live` branch is continuously built on both [Windows][AppVeyor]
and [Linux][Travis]. Alternatively, simply create a new Codenvy workspace from my [factory][Codenvy]!

![Codenvy workspace](Codenvy-WhatIsHeDoing-NuGet.png)

## 👱 Authors

* **Darren Hickling**: <https://darrenhickling.com/>

[.NET Fiddle]: https://dotnetfiddle.net/xXbTcX "C# Online Compiler | .NET Fiddle"
[AppVeyor]: https://ci.AppVeyor.com/project/DarrenHickling/whatishedoing-core-e1tc9
    "WhatIsHeDoing.Core - AppVeyor [Windows build]"
[Codenvy]: https://Codenvy.io/f?id=factorynedmx40ex1ue8pdj "Start development on Codenvy"
[contributing]: CONTRIBUTING.md
[Humanizr]: http://humanizr.net/
[NodaTime]: https://nodatime.org/
[NuGet]: https://www.NuGet.org/packages/WhatIsHeDoing.Core/
[Travis]: https://Travis-ci.org/WhatIsHeDoing/WhatIsHeDoing.Core
    "WhatIsHeDoing/WhatIsHeDoing.Core - Travis CI [Linux build]"

using System;
using Xunit;

namespace Sample.Tests;

public class PreludeSpec
{
    [Fact]
    public void AddSuccess()
    {

    }

    public readonly record struct RT
    (
    ) :
    Has<>
}

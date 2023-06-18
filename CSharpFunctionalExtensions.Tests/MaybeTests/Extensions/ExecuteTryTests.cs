using System;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class ExecuteTryTests : MaybeTestBase
{
    [Fact]
    public void ExecuteTry_does_not_execute_action_if_no_value()
    {
        Maybe<T> instance = null;
            
        instance.ExecuteTry(value => instance = T.Value);

        instance.HasNoValue.Should().BeTrue();
    }

    [Fact]
    public void ExecuteTry_executes_action_if_value()
    {
        Maybe<T> instance = T.Value;

        instance.ExecuteTry(value => value.Should().Be(T.Value));

        instance.Value.Should().Be(T.Value);
    }
    
    [Fact]
    public void ExecuteTry_does_not_execute_action_if_exception()
    {
        Maybe<T> instance = T.Value;
        Exception exception = null;

        instance.ExecuteTry(Throw_Action, e => exception = e);

        exception.Should().NotBeNull();
    }
}

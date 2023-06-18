using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class ExecuteTryTests_Task_Right : MaybeTestBase
{
    [Fact]
    public async Task ExecuteTry_Task_Right_does_not_execute_action_if_no_value()
    {
        Maybe<T> instance = null;
            
        await instance.ExecuteTry(value =>
        {
            instance = T.Value;
            return Task.CompletedTask;
        });

        instance.HasNoValue.Should().BeTrue();
    }

    [Fact]
    public async Task ExecuteTry_Task_Right_executes_action_if_value()
    {
        Maybe<T> instance = T.Value;

        await instance.ExecuteTry(value =>
        {
            value.Should().Be(T.Value);
            return Task.CompletedTask;
        });

        instance.Value.Should().Be(T.Value);
    }
    
    [Fact]
    public async Task ExecuteTry_Task_Right_does_not_execute_action_if_exception()
    {
        Maybe<T> instance = T.Value;
        Exception exception = null;

        await instance.ExecuteTry(Throw_Action_Task, e=> exception = e);

        exception.Should().NotBeNull();
    }
}

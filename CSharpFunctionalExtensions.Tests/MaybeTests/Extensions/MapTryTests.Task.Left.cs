using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class MapTryTests_Task_Left : MaybeTestBase
    {
        [Fact]
        public async Task MapTry_Task_Left_returns_mapped_value()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = await maybe.AsTask().MapTry(ExpectAndReturn(T.Value, T.Value2));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(T.Value2);
        }

        [Fact]
        public async Task MapTry_Task_Left_returns_no_value_if_initial_maybe_is_null()
        {
            Maybe<T> maybe = null;

            var maybe2 = await maybe.AsTask().MapTry(ExpectAndReturn(null, T.Value2));

            maybe2.HasValue.Should().BeFalse();
        }
        
        [Fact]
        public async Task MapTry_Task_Left_returns_no_value_if_exception()
        {
            Maybe<T> maybe = T.Value;
            Exception exception = null;

            var maybe2 = await maybe.AsTask().MapTry(Throw(T.Value), e => exception = e);

            maybe2.HasValue.Should().BeFalse();
            exception.Should().NotBeNull();
        }
    }
}
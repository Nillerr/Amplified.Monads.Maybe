﻿using System.Threading.Tasks;
using Amplified.Monads.Extensions;
using Amplified.Monads.Util;
using Xunit;

namespace Amplified.Monads
{
    // ReSharper disable once InconsistentNaming
    public class AsyncMaybe_Map
    {
        [Fact]
        public async Task Sync_WhenSome_ReturnsMappedResult()
        {
            const int expected = 5;
            var result = await AsyncMaybe<int>.Some(2).Map(some => some + 3).OrFail();
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Sync_WhenNone_ReturnsNone()
        {
            var isNone = await AsyncMaybe<int>.None().Map(some => some + 3).IsNone;
            Assert.True(isNone);
        }
    }
}

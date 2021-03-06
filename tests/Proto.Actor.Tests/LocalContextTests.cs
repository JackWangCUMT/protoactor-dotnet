﻿using System;
using System.Threading.Tasks;
using Proto.TestFixtures;
using Xunit;

namespace Proto.Tests
{
    public class LocalContextTests
    { 
        [Fact]
        public void Given_Context_ctor_should_set_some_fields()
        {
            var producer = (Func<IActor>)(() => null);
            var supervisorStrategyMock = new DoNothingSupervisorStrategy();
            var middleware = new Receive(ctx => Task.CompletedTask);
            var parent = new PID("test", "test");

            var context = new LocalContext(producer, supervisorStrategyMock, middleware, null, parent);

            Assert.Equal(parent, context.Parent);

            Assert.Null(context.Message);
            Assert.Null(context.Sender);
            Assert.Null(context.Self);
            Assert.Null(context.Actor);
            Assert.NotNull(context.Children);
            Assert.Same(context.Children, LocalContext.EmptyChildren);

            Assert.Equal(TimeSpan.Zero, context.ReceiveTimeout);
        }

      
    }
}

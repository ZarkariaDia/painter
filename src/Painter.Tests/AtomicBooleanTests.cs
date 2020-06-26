using FluentAssertions;
using NUnit.Framework;
using Painter.Core;

namespace Painter.Tests
{
    [TestFixture]
    internal class AtomicBooleanTests
    {
        [Test]
        public void Test_initial_state()
        {
            ((bool) new AtomicBoolean()).Should().BeFalse();
            ((bool) new AtomicBoolean(true)).Should().BeTrue();
        }

        [Test]
        public void Test_TrySetTrue_falsy()
        {
            var boolean = new AtomicBoolean();

            boolean.TrySetTrue().Should().BeTrue();
            ((bool) boolean).Should().BeTrue();
        }

        [Test]
        public void Test_TrySetTrue_already_truly()
        {
            var boolean = new AtomicBoolean();

            boolean.TrySetTrue();

            boolean.TrySetTrue().Should().BeFalse();
            ((bool) boolean).Should().BeTrue();
        }

        [Test]
        public void Test_TrySetFalse_truly()
        {
            var boolean = new AtomicBoolean();

            boolean.TrySetTrue();

            boolean.TrySetFalse().Should().BeTrue();
            ((bool) boolean).Should().BeFalse();
        }
        
        [Test]
        public void Test_TrySetFalse_already_falsy()
        {
            var boolean = new AtomicBoolean();

            boolean.TrySetFalse().Should().BeFalse();
            ((bool) boolean).Should().BeFalse();
        }
    }
}
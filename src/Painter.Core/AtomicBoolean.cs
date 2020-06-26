using System.Threading;

namespace Painter.Core
{
    public class AtomicBoolean
    {
        private int state;

        public AtomicBoolean(bool initialState = false)
        {
            state = initialState ? 1 : 0;
        }

        public bool TrySetTrue() => Interlocked.CompareExchange(ref state, 1, 0) == 0;

        public bool TrySetFalse() => Interlocked.CompareExchange(ref state, 0, 1) == 1;

        public static implicit operator bool(AtomicBoolean value) => value.state == 1;
    }
}
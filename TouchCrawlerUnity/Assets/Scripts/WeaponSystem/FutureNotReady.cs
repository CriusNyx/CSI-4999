using System;
using System.Runtime.Serialization;

namespace Assets.Scripts.WeaponSystem
{
    [Serializable]
    internal class FutureNotReady : Exception
    {
        public FutureNotReady()
        {
        }

        public FutureNotReady(string message) : base(message)
        {
        }

        public FutureNotReady(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FutureNotReady(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
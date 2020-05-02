using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SlackAspNet.Types
{
	public interface IStrongType
	{
		object GetValue();
	}

	[Serializable]
	public class StrongType<T> : ISerializable, IEquatable<StrongType<T>>, IStrongType where T : class
	{
		private T value;

		public StrongType(T value)
		{
			this.value = value;
		}

		protected StrongType(SerializationInfo info, StreamingContext context)
		{
			this.value = (T)info.GetValue("Value", typeof(T));
		}

		public static bool operator ==(StrongType<T> a, StrongType<T> b)
		{
			if (a is null)
				return b is null;
			return a.Equals(b);
		}

		public static bool operator !=(StrongType<T> a, StrongType<T> b)
		{
			if (a is null)
				return !(b is null);
			return !a.Equals(b);
		}

		public static bool operator ==(StrongType<T> a, T b)
		{
			if (a is null)
				return b is null;
			return a.value.Equals(b);
		}

		public static bool operator !=(StrongType<T> a, T b)
		{
			if (a is null)
				return !(b is null);
			return !a.value.Equals(b);
		}

		public static bool operator ==(T b, StrongType<T> a)
		{
			if (a is null)
				return b is null;
			return a.value.Equals(b);
		}

		public static bool operator !=(T b, StrongType<T> a)
		{
			if (a is null)
				return !(b is null);
			return !a.value.Equals(b);
		}

		public static explicit operator T(StrongType<T> a)
		{
			return a?.value;
		}

		public override string ToString()
		{
			return value.ToString();
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Value", value);
		}

		public override bool Equals(object obj)
		{
			if (obj is T)
				return ((T)obj) == this;
			if (obj is StrongType<T> st)
				return st?.value == this.value;
			return base.Equals(obj);
		}

		public bool Equals(StrongType<T> other)
		{
			return this.value?.Equals(other?.value) ?? false;
		}

		public override int GetHashCode()
		{
			return value.GetHashCode();
		}

		public object GetValue()
		{
			return value;
		}
	}
}

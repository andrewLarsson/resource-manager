using System;

namespace ResourceManager.Common {
	public class Value : IDouble {
		public double _ { get; }

		private Value(double value) {
			_ = value;
		}

		public static Value From(double value) {
			return new Value(value);
		}

		public override string ToString() {
			return _.ToString();
		}

		protected bool Equals(Value other) {
			return Math.Abs(_ - other._) < 0.001D;
		}

		public override bool Equals(object obj) {
			if (ReferenceEquals(null, obj)) {
				return false;
			}
			if (ReferenceEquals(this, obj)) {
				return true;
			}
			if (obj.GetType() != this.GetType()) {
				return false;
			}
			return Equals((Value)obj);
		}

		public override int GetHashCode() {
			return _.GetHashCode();
		}

		public static Value operator +(Value left, IDouble right) {
			return Value.From(left._ + right._);
		}

		public static Value operator -(Value left, IDouble right) {
			return Value.From(left._ - right._);
		}

		public static bool operator <(Value left, IDouble right) {
			return left._ < right._;
		}

		public static bool operator >(Value left, IDouble right) {
			return left._ > right._;
		}

		public static bool operator ==(Value left, IDouble right) {
			return Math.Abs(left._ - right._) <= 0.001D;
		}

		public static bool operator !=(Value left, IDouble right) {
			return Math.Abs(left._ - right._) < 0.001D;
		}

		public static Value Zero() {
			return Value.From(0D);
		}
	}
}

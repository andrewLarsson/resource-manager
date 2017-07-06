namespace ResourceManager.Common {
	public class Resource {
		public string Name { get; }
		public Value Value { get; }

		private Resource(string name, Value value) {
			Name = name;
			Value = value;
		}

		public static Resource From(string name, Value value) {
			return new Resource(name, value);
		}

		public Resource IncreaseBy(Amount amount) {
			return Resource.From(Name, Value + amount);
		}

		public Resource DecreaseBy(Amount amount) {
			return Resource.From(Name, Value - amount);
		}

		public bool IsEqualTo(Value value) {
			return Value == value;
		}

		public bool IsLessThan(Value value) {
			return Value < value;
		}

		public bool IsLessThanOrEqualTo(Value value) {
			return (
				Value < value
				|| Value == value
			);
		}

		public bool IsGreaterThan(Value value) {
			return Value > value;
		}

		public bool IsGreaterThanOrEqualTo(Value value) {
			return (
				Value > value
				|| Value == value
			);
		}
	}
}

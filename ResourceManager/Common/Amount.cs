using System;

namespace ResourceManager.Common {
	public class Amount : IDouble {
		public double _ { get; }

		private Amount(double amount) {
			if (amount < 0D) {
				throw new Exception("Amount must be positive.");
			}
			_ = amount;
		}

		public static Amount From(double amount) {
			return new Amount(amount);
		}
	}
}

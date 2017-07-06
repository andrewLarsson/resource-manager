using System.Collections.Generic;
using System.Linq;
using ResourceManager.Common;

namespace ResourceManager {
	public class RuleManager : IRuleManager {
		private readonly HashSet<IRule> _rules;

		public RuleManager() {
			_rules = new HashSet<IRule>();
		}

		public void Register(IRule rule) {
			_rules.Add(rule);
		}

		public void Unregister(IRule rule) {
			_rules.Remove(rule);
		}

		public void ApplyAllRules() {
			List<IRule> rules = _rules.ToList();
			foreach (IRule rule in rules) {
				rule.Apply();
			}
		}
	}
}

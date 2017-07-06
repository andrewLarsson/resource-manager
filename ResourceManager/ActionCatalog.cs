using System.Collections.Generic;
using ResourceManager.Common;

namespace ResourceManager {
	public class ActionCatalog : IActionCatalog {
		private readonly Dictionary<string, IAction> _actions;

		public ActionCatalog(IAction defaultAction) {
			_actions = new Dictionary<string, IAction>() {
				{ "Nothing", defaultAction }
			};
		}

		public void Register(IAction action) {
			_actions[action.Name] = action;
		}

		public void Unregister(IAction action) {
			_actions.Remove(action.Name);
		}

		public IAction Select(string actionName) {
			return ((_actions.ContainsKey(actionName))
				? _actions[actionName]
				: _actions["Nothing"]
			);
		}

		public override string ToString() {
			string formatted = "";
			foreach (KeyValuePair<string, IAction> action in _actions) {
				formatted += action.Key + "\n";
			}
			return formatted;
		}
	}
}

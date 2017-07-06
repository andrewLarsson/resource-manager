using System.Collections.Generic;

namespace ResourceManager.Common {
	public interface IResourceManagerController {
		void StartScenario(
			IEnumerable<Resource> resources,
			IEnumerable<IRule> rules,
			IEnumerable<IAction> actions
		);
		bool IsScenarioRunning();
		void TakeAction(string actionName);
		void EndScenario();
	}
}

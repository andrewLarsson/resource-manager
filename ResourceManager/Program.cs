using System.Collections.Generic;
using ResourceManager.Actions;
using ResourceManager.Common;
using ResourceManager.Rules;

namespace ResourceManager {
	public static class Program {
		public static void Main(string[] args) {
			InputOutputController inputOutputController = new InputOutputController();
			ResourceRepository resourceRepository = new ResourceRepository();
			RuleManager ruleManager = new RuleManager();
			ActionCatalog actionCatalog = new ActionCatalog(new NothingAction(inputOutputController));
			ResourceManagerController resourceManagerController = new ResourceManagerController(
				resourceRepository,
				ruleManager,
				actionCatalog,
				inputOutputController
			);
			List<Resource> resources = new List<Resource>() {
				Resource.From("Health", Value.From(100D))
			};
			List<IRule> rules = new List<IRule>() {
				new LifeRule(resourceRepository, inputOutputController, resourceManagerController)
			};
			List<IAction> actions = new List<IAction>() {
				new SellSoulAction(resourceRepository, inputOutputController)
			};
			resourceManagerController.StartScenario(resources, rules, actions);

			while (resourceManagerController.IsScenarioRunning()) {
				inputOutputController.Write("Select an action to take:");
				string action = inputOutputController.Read();
				resourceManagerController.TakeAction(action);
			}

			inputOutputController.Pause();
		}
	}
}

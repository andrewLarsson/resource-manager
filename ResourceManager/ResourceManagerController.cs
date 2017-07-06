using System.Collections.Generic;
using ResourceManager.Common;

namespace ResourceManager {
	public class ResourceManagerController : IResourceManagerController {
		private readonly IResourceRepository _resourceRepository;
		private readonly IRuleManager _ruleManager;
		private readonly IActionCatalog _actionCatalog;
		private readonly IInputOutputController _inputOutputController;

		private bool _isRunning;

		public ResourceManagerController(
			IResourceRepository resourceRepository,
			IRuleManager ruleManager,
			IActionCatalog actionCatalog,
			IInputOutputController inputOutputController
		) {
			_resourceRepository = resourceRepository;
			_ruleManager = ruleManager;
			_actionCatalog = actionCatalog;
			_inputOutputController = inputOutputController;
			_isRunning = false;
		}

		public void StartScenario(IEnumerable<Resource> resources, IEnumerable<IRule> rules, IEnumerable<IAction> actions) {
			if (_isRunning) {
				_inputOutputController.Write("You cannot start the scenario while it's already running.");
				return;
			}
			foreach (Resource resource in resources) {
				_resourceRepository.Save(resource);
			}
			foreach (IRule rule in rules) {
				_ruleManager.Register(rule);
			}
			foreach (IAction action in actions) {
				_actionCatalog.Register(action);
			}
			_isRunning = true;
			_inputOutputController.Write("Scenario has started.");
			_ruleManager.ApplyAllRules();
			_inputOutputController.Write("Resources:");
			_inputOutputController.Write(_resourceRepository.ToString());
			if (_isRunning) {
				_inputOutputController.Write("Actions:");
				_inputOutputController.Write(_actionCatalog.ToString());
			}
		}

		public bool IsScenarioRunning() {
			return _isRunning;
		}

		public void TakeAction(string actionName) {
			if (!_isRunning) {
				_inputOutputController.Write("You cannot take actions while the scenario isn't running.");
				return;
			}
			_actionCatalog.Select(actionName).Do();
			_ruleManager.ApplyAllRules();
			_inputOutputController.Write("Resources:");
			_inputOutputController.Write(_resourceRepository.ToString());
			if (_isRunning) {
				_inputOutputController.Write("Actions:");
				_inputOutputController.Write(_actionCatalog.ToString());
			}
		}

		public void EndScenario() {
			_isRunning = false;
			_inputOutputController.Write("Scenario has ended.");
		}
	}
}

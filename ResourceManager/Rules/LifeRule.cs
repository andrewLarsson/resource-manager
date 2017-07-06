using ResourceManager.Common;

namespace ResourceManager.Rules {
	public class LifeRule : IRule {
		private readonly IResourceRepository _resourceRepository;
		private readonly IInputOutputController _inputOutputController;
		private readonly IResourceManagerController _resourceManagerController;

		public LifeRule(
			IResourceRepository resourceRepository,
			IInputOutputController inputOutputController,
			IResourceManagerController resourceManagerController
		) {
			_resourceRepository = resourceRepository;
			_inputOutputController = inputOutputController;
			_resourceManagerController = resourceManagerController;
		}

		public void Apply() {
			if (_resourceRepository.Load("Health").IsLessThanOrEqualTo(Value.Zero())) {
				_inputOutputController.Write("You have died.");
				_resourceManagerController.EndScenario();
			}
		}
	}
}

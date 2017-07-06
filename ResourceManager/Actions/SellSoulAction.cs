using ResourceManager.Common;

namespace ResourceManager.Actions {
	public class SellSoulAction : IAction {
		public string Name {
			get { return "Sell Soul"; }
		}

		private readonly IResourceRepository _resourceRepository;
		private readonly IInputOutputController _inputOutputController;

		public SellSoulAction(
			IResourceRepository resourceRepository,
			IInputOutputController inputOutputController
		) {
			_resourceRepository = resourceRepository;
			_inputOutputController = inputOutputController;
		}

		public void Do() {
			_resourceRepository.Save(
				_resourceRepository.Load("Health").DecreaseBy(Amount.From(10D))
			);
			_resourceRepository.Save(
				_resourceRepository.Load("Money").IncreaseBy(Amount.From(1D))
			);
			_inputOutputController.Write("You have sold a part of your soul for $1.");
		}
	}
}

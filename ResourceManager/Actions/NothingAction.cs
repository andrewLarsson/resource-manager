using ResourceManager.Common;

namespace ResourceManager.Actions {
	public class NothingAction : IAction {
		public string Name {
			get { return "Nothing"; }
		}

		private readonly IInputOutputController _inputOutputController;

		public NothingAction(IInputOutputController inputOutputController) {
			_inputOutputController = inputOutputController;
		}

		public void Do() {
			_inputOutputController.Write("You have done nothing.");
		}
	}
}

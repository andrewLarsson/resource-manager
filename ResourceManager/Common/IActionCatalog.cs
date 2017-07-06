namespace ResourceManager.Common {
	public interface IActionCatalog {
		void Register(IAction action);
		void Unregister(IAction action);
		IAction Select(string actionName);
	}
}

namespace ResourceManager.Common {
	public interface IAction {
		string Name { get; }
		void Do();
	}
}

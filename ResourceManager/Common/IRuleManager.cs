namespace ResourceManager.Common {
	public interface IRuleManager {
		void Register(IRule rule);
		void Unregister(IRule rule);
		void ApplyAllRules();
	}
}

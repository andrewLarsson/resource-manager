namespace ResourceManager.Common {
	public interface IInputOutputController {
		string Read();
		void Write(string message);
		void Pause();
	}
}

using System;
using ResourceManager.Common;

namespace ResourceManager {
	public class InputOutputController : IInputOutputController {
		public string Read() {
			return Console.ReadLine();
		}

		public void Write(string message) {
			Console.WriteLine(message);
		}

		public void Pause() {
			Console.ReadKey();
		}
	}
}

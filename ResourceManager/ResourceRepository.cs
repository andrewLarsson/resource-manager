using System.Collections.Generic;
using ResourceManager.Common;

namespace ResourceManager {
	public class ResourceRepository : IResourceRepository {
		private readonly Dictionary<string, Resource> _resources;

		public ResourceRepository() {
			_resources = new Dictionary<string, Resource>();
		}

		public Resource Load(string resourceName) {
			return ((_resources.ContainsKey(resourceName))
				? _resources[resourceName]
				: Resource.From(resourceName, Value.Zero())
			);
		}

		public void Save(Resource resource) {
			_resources[resource.Name] = resource;
		}

		public override string ToString() {
			string formatted = "";
			foreach (KeyValuePair<string, Resource> resource in _resources) {
				formatted += resource.Key + ": " + resource.Value.Value + "\n";
			}
			return formatted;
		}
	}
}

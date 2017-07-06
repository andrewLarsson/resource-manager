namespace ResourceManager.Common {
	public interface IResourceRepository {
		Resource Load(string resourceName);
		void Save(Resource resource);
	}
}

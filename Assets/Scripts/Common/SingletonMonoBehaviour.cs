using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	// Base class for Singletons

	private const string FIXED_PREFAB_PATH = "Prefabs/Singletons/";

	private static T instance;

	public static T Instance {
		get {
			if (!instance) {
				string[] parts = typeof(T).ToString().Split('.');
				string name = parts[parts.Length - 1]; // In case of namespaces

				// Look for instance in scene
				if (FindObjectsOfType<T>().Length > 1) {
					Debug.LogError(string.Format("Multiple instances found for SingletonMonoBehaviour {0}", name));
				}
				instance = FindObjectOfType<T>();

				if (!instance) {
					// Check default prefab location
					string path = FIXED_PREFAB_PATH + name;
					GameObject prefab = Resources.Load<GameObject>(path);
					if (prefab) {
						//Debug.Log(string.Format("Loading prefab for {0}", name));
						GameObject obj = Instantiate(prefab);
						instance = obj.GetComponent<T>();
						obj.name = name;

					} else {
						// Create new game object in current scene
						//Debug.Log(string.Format("Creating new GameObject for {0}", name));
						GameObject obj = new GameObject(name);
						instance = obj.AddComponent<T>();
					}
				} else {
					//Debug.Log(string.Format("Found object in scene for {0}", name));
				}
			}

			return instance;
		}
	}

	public void Touch()
	{
		// Hack method to force create instance
	}
}

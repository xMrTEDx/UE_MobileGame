using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;
 
	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				string singletonPath = "Singletons/"+typeof(T).ToString();
				Object singleton = Instantiate(Resources.Load(singletonPath));
				if(singleton)
					_instance = (T)singleton;

				DontDestroyOnLoad(singleton);

				Debug.Log("Create "+typeof(T).ToString()+" singleton");
			}
			
 
			return _instance;
			
		}
	}
	private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = (T)(object)this;
        }
    }
}

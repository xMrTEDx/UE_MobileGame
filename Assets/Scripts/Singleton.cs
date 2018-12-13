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
				GameObject singleton = (GameObject)Instantiate(Resources.Load(singletonPath));
                Debug.Log(singleton);

				if(singleton)
					_instance = singleton.GetComponent<T>();

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

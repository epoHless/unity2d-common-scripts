using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static readonly object Lock = new object();
    private static T _instance;
    
    public static T Instance
    {
        get
        { 
            lock (Lock)
            {
                if (_instance == null)
                {
                    _instance = FindAnyObjectByType<T>();
                    
                    if (_instance == null)
                    {
                        Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
                    }
                }
                return _instance;
            }
        }

        private set => _instance = value;
    }
    
    [SerializeField] protected bool IsPersistent = true;

    protected virtual void Awake()
    {
        SetSingleInstance();
    }

    protected virtual void OnEnable()
    {
        SetSingleInstance();
    }

    private void OnApplicationQuit()
    {
        Instance = null;
    }

    private void SetSingleInstance()
    {
        if (Instance == this)
            return;
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        T[] instances = FindObjectsOfType<T>();

        if(instances.Length > 1)
        {
            Debug.LogError("Multiple instances of " + typeof(T).Name + " found");
            Instance = this as T;
        }
        else if(instances.Length == 1)
        {
            Instance = instances[0];
        }
        
        if (IsPersistent)
            DontDestroyOnLoad(gameObject);
    }
}
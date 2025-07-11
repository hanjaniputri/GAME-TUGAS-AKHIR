using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;

    private static bool m_applicationIsQuitting = false;

    [SerializeField] protected bool _isDontDestroyOnLoad = false;

    public static T GetInstance()
    {
        if (m_applicationIsQuitting) { return null; }

        if (instance == null)
        {
            instance = FindFirstObjectByType<T>();
            if (instance == null)
            {
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                instance = obj.AddComponent<T>();
                return null;
            }
        }
        return instance;
    }

    protected virtual void Awake()
    {
        if (!_isDontDestroyOnLoad) return;
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this as T)
        {
            Destroy(gameObject);
        }
        else { DontDestroyOnLoad(gameObject); }
    }

    private void OnApplicationQuit()
    {
        m_applicationIsQuitting = true;
    }
}
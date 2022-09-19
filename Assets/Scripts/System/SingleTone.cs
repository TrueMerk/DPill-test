using UnityEngine;

public abstract class SingleTone<T> : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (Equals(_instance, null) || _instance == null || _instance.Equals(null))
            {
                var instanceGo = FindObjectOfType<SingleTone<T>>();
                _instance = instanceGo.GetComponent<T>();
                return _instance;
            }
            else
            {
                return _instance;
            }
        }
        set => _instance = value;
    }

    protected void SingletonBuilder(T newInstance)
    {

        var instanceGo = FindObjectsOfType<SingleTone<T>>();
        if (instanceGo.Length>1)
        {
            Destroy(this.gameObject);
            return;
        }

        if (_instance == null)
        {
            _instance = newInstance;
        }
        else if (_instance.Equals(newInstance))
        {
            Debug.LogWarning("Found two singletons of type"+this);
            Destroy(gameObject);
        }
        {
            
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Be aware this will not prevent a non singleton constructor
///   such as `T myT = new T();`
/// To prevent that, add `protected T () {}` to your singleton class.
/// 
/// As a note, this is made as MonoBehaviour because we need Coroutines.
/// </summary>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;

    private static bool singletonDestroyed = false;

    public static T Instance
    {
        get
        {
            if (singletonDestroyed)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                    "' marked for destruction");
                return null;
            }
            return _instance ?? (_instance = FindObjectOfType<T>());
        }

        set { _instance = value; }
    }

    protected virtual void Awake()
    {
        _instance = this as T;
        singletonDestroyed = false;
    }

    protected virtual void OnApplicationQuit()
    {
        singletonDestroyed = true;
    }
}

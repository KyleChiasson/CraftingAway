using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance;
    public void Awake()
    {
        if (Instance == null)
            Instance = (T)this;
        else Destroy(this);
    }
}

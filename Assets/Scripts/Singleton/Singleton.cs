using UnityEngine;

public abstract class Singleoton<Type>: MonoBehaviour where Type : Component {
    static Type _instance;
    public static Type instance {
        get {
            if (!_instance) {
                GameObject obj = new GameObject(typeof(Type).Name);
                _instance = obj.AddComponent<Type>();
            }
            return _instance;
        }
    }

    protected virtual void Awake() {
        if (_instance) {
            Destroy(gameObject);
            return;
        }

        _instance = this as Type;
        DontDestroyOnLoad(gameObject);
    }
}

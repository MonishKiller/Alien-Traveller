using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManger<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            // Check if the instance is null
            if (instance == null)
            {
                // Search for an existing instance in the scene
                instance = FindObjectOfType<T>();

                // If there's no instance in the scene, create a new one
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    instance = singletonObject.AddComponent<T>();
                }
            }

            return instance;
        }
    }
}

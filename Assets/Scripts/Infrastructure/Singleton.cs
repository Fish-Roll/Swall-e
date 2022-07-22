using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class Singleton<T> : MonoBehaviour
        where T : new()
    {
        public static T Instance { get; private set; }

        public Singleton()
        {
            Instance ??= new T();
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace epoHless
{
    public sealed class TimerManager : MonoBehaviour
    {
        private static bool IsPersistent => true;
        private static readonly object lockObject = new object();
        private static TimerManager instance;
        
        private static TimerManager Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = FindObjectOfType<TimerManager>();
                    }

                    return instance;
                }
            }
        }
        
        private List<Timer> timers;
        
        private void Awake()
        {
            timers = new List<Timer>();
        }
        
        private void Update()
        {
            for (int i = 0; i < timers.Count; i++)
            {
                if(!timers[i].IsPaused) timers[i].Tick();
            }
        }
        
        public static void Create(Action onComplete, float duration, bool looping = false)
        {
            Timer timer = new Timer(duration, onComplete, looping);
            Instance.timers.Add(timer);
        }
        
        public static void Clear()
        {
            Instance.timers.Clear();
        }
        
        public static void Pause(Action action)
        {
            var timer = Instance.timers.Find(t => t.onComplete == action);
            timer?.Stop();
        }
        
        public static void Resume(Action action)
        {
            var timer = Instance.timers.Find(t => t.onComplete == action);
            timer?.Resume();
        }
        
        public static void PauseAll()
        {
            for (int i = 0; i < Instance.timers.Count; i++)
            {
                Instance.timers[i].Stop();
            }
        }
        
        public static void ResumeAll()
        {
            for (int i = 0; i < Instance.timers.Count; i++)
            {
                Instance.timers[i].Resume();
            }
        }

        private static class TimerBootstrapper
        {
            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
            private static void CreateManager()
            {
                var go = new GameObject("[SINGLETON] Timer Manager");
                go.AddComponent<TimerManager>();
                if(IsPersistent) DontDestroyOnLoad(go);
            }
        }
    }
}

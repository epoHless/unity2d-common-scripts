using System.Collections.Generic;
using UnityEngine;

namespace epoHless.Framework
{
    public abstract class Global : Singleton<Global>
    {
        [SerializeReference] public List<Subsystem> Subsystems = new List<Subsystem>();

        protected override void OnEnable()
        {
            base.OnEnable();    
            
            foreach (var subsystem in Subsystems)
            {
                subsystem.Initialize();
            }
        }
        
        private void OnDisable()
        {
            foreach (var subsystem in Subsystems)
            {
                subsystem.Shutdown();
            }
        }
        
        private void Update()
        {
            foreach (var subsystem in Subsystems)
            {
                subsystem.Update();
            }
        }

        public void AddSubsystem(Subsystem subsystem) => Subsystems.Add(subsystem);
        public static void Add<T>(Subsystem subsystem) where T : Subsystem => Instance.AddSubsystem(subsystem);
        
        public void RemoveSubsystem(Subsystem subsystem) => Subsystems.Remove(subsystem);
        public static void Remove(Subsystem subsystem) => Instance.RemoveSubsystem(subsystem);

        private T GetSubsystemInternal<T>() where T : Subsystem
        {
            foreach (var subsystem in Subsystems)
            {
                if (subsystem is T t)
                {
                    return t;
                }
            }

            return null;
        }
        public static T GetSubsystem<T>() where T : Subsystem => Instance.GetSubsystemInternal<T>();

        private void RemoveSubsystem<T>() where T : Subsystem
        {
            foreach (var subsystem in Subsystems)
            {
                if (subsystem is T)
                {
                    Subsystems.Remove(subsystem);
                    return;
                }
            }
        }
        public static void Remove<T>() where T : Subsystem => Instance.RemoveSubsystem<T>();
    }
    
    [System.Serializable]
    public abstract class Subsystem 
    {
        [SerializeField] protected bool isInitialized;
        
        public virtual void Initialize()
        {
            Debug.Log($"Initializing {GetType().Name}");
            isInitialized = true;
        }

        public virtual void Shutdown()
        {
            Debug.Log($"Shutting down {GetType().Name}");
            isInitialized = false;
        }

        public virtual void Update() { }
    }
}
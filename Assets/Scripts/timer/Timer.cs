using System;
using UnityEngine;

namespace epoHless
{
    public class Timer
    {
        public bool IsPaused { get; private set; }

        private readonly bool looping = false;
        internal readonly Action onComplete;

        private readonly float duration;
        private float currentTime;

        public Timer(float duration, Action onComplete, bool looping = false)
        {
            this.duration = duration;
            currentTime = this.duration;
            
            this.onComplete = onComplete;
            this.looping = looping;
        }
        
        private Timer(){}

        public void Tick()
        {
            if (IsPaused) return;
            
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                if (looping)
                {
                    currentTime = duration;
                }
                else
                {
                    Stop();
                }
                
                onComplete.Invoke();
            }
        }

        public void Stop()
        {
            IsPaused = true;
        }
        
        public void Resume()
        {
            IsPaused = false;
        }
        
        public void Reset()
        {
            currentTime = duration;
            Resume();
        }
    }
}

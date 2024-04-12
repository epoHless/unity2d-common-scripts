using System;
using UnityEngine;

namespace epoHless.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayer : MonoBehaviour
    {
        private AudioSource audioSource;
        private float timePlaying;
        
        protected virtual void Awake() => audioSource = GetComponent<AudioSource>();

        private void Update()
        {
            if(!gameObject.activeInHierarchy) return;
            
            if (timePlaying >= audioSource.clip.length)
            {
                gameObject.SetActive(false);
            }
            
            timePlaying += Time.deltaTime;
        }

        private void Play(AudioClip clip)
        {
            timePlaying = 0;
            
            audioSource.clip = clip;
            audioSource.Play();
        }
        
        public void PlayAtPoint(AudioClip clip, Vector3? position = null)
        {
            transform.position = position ?? transform.position;
            Play(clip);
        }
    }
}
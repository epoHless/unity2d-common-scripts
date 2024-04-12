using UnityEngine;

namespace epoHless.Audio
{
    public static class AudioManager
    {
        private static AudioPooler audioPooler;
        
        private static void Initialise()
        {
            
        }
        
        public static void Play(AudioClip clip, Vector3? position = null)
        {
            var audioPlayer = audioPooler.Get();
            audioPlayer.gameObject.SetActive(true);
        }
        
        private static class Bootstrap
        {
            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
            private static void OnBeforeSceneLoadRuntimeMethod()
            {
                Initialise();
            }
        }
    }
}
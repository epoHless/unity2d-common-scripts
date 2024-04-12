using UnityEngine;

namespace epoHless.Audio
{
    public class AudioPooler : ObjectPooler<AudioSource>
    {
        public AudioPooler()
        {
            PooledObject = new PooledObject<AudioSource>
            {
                Object = new GameObject("AudioSource").AddComponent<AudioSource>(),
                Quantity = 5,
                ShouldExpand = true
            };
            
            Initialize();
        }
    }
}
using UnityEngine;
using UnityEngine.Audio;

namespace epoHless.Audio
{
    public class VolumeManager : MonoBehaviour
    {
        [SerializeField] private VolumeClass[] volumeClasses;

        private void OnEnable()
        {
            for (int i = 0; i < volumeClasses.Length; i++)
            {
                volumeClasses[i].Enable();
            }
        }
        
        private void OnDisable()
        {
            for (int i = 0; i < volumeClasses.Length; i++)
            {
                volumeClasses[i].Disable();
            }
        }
    }
    
    [System.Serializable]
    public class VolumeClass
    {
        [SerializeField] private string name;
        [SerializeField] private VolumeSlider slider;
        [SerializeField] private AudioMixerGroup mixerGroup;

        public float SliderValue => slider.Value;
        
        public float MixerValue
        {
            get
            {
                mixerGroup.audioMixer.GetFloat(name, out float value);
                return Mathf.Log10(value) * 20f;
            }
        }
        
        public void Enable() => slider.OnVolumeChanged += SetAudioMixerVolume;
        public void Disable() => slider.OnVolumeChanged -= SetAudioMixerVolume;

        protected virtual void SetAudioMixerVolume(float value) => mixerGroup.audioMixer.SetFloat(name, Mathf.Log10(value) * 20f);
    }
}
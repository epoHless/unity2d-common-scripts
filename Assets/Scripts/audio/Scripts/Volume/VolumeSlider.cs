using UnityEngine;
using UnityEngine.UI;

namespace epoHless.Audio
{
    [RequireComponent(typeof(Slider))]
    public class VolumeSlider : MonoBehaviour
    {
        public delegate void VolumeCallback(float value);
        public event VolumeCallback OnVolumeChanged;
        
        private Slider slider;
        public float Value => slider.value;
        
        protected virtual void Awake() => slider = GetComponent<Slider>();
        protected virtual void OnEnable() => slider.onValueChanged.AddListener(ChangeValue);
        protected virtual void OnDisable() => slider.onValueChanged.RemoveListener(ChangeValue);
        private void ChangeValue(float value) => OnVolumeChanged?.Invoke(value);
    }
}
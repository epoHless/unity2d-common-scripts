using UnityEngine;

namespace epoHless.Framework
{
    public sealed class ClickFeedback : MonoBehaviour
    {
        [SerializeField] private Feedback<RectTransform> feedback;

        public void PlayFeedback()
        {
            if (feedback != null) feedback.Play(GetComponent<RectTransform>());
        } 
    }
}
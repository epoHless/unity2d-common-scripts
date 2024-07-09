using DG.Tweening;
using UnityEngine;

namespace epoHless.Framework
{
    [CreateAssetMenu(menuName = "epoHless/Feedbacks/Animations/ScaleFeedback")]
    public class ScaleFeedback : Feedback<RectTransform>
    {
        [SerializeField] private float scale = 1.1f;
        [SerializeField] private float duration = 0.1f;
        [SerializeField] private Ease ease = Ease.Linear;
        
        public override Tween Play(RectTransform component) => 
            component.DOScale(scale, duration).SetEase(ease)
                .OnComplete(() => component.DOScale(1, duration).SetEase(ease));
    }
}
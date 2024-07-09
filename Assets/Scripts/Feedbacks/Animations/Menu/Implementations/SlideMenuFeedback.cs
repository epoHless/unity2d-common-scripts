using DG.Tweening;
using UnityEngine;

namespace epoHless.Framework
{
    [CreateAssetMenu(menuName = "epoHless/Feedbacks/Animations/Menu/SlideMenuFeedback")]
    public class SlideMenuFeedback : MenuFeedback<MenuComponent>
    {
        [SerializeField] private ETarget targetDirection = ETarget.Top;
        [SerializeField] private float duration = 0.5f;
        [SerializeField] private Ease ease = Ease.OutCubic;
        
        private Vector2 Target => (targetDirection) switch
        {
            ETarget.Top => new Vector2(0, Screen.height),
            ETarget.Bottom => new Vector2(0, -Screen.height),
            ETarget.Left => new Vector2(-Screen.width, 0),
            ETarget.Right => new Vector2(Screen.width, 0),
            _ => Vector2.zero
        };

        public override Tween Play(MenuComponent component) => component.RectTransform.DOAnchorPos(component.StartPosition, duration).SetEase(ease);
        public override Tween Reverse(MenuComponent menu) => menu.RectTransform.DOAnchorPos(menu.RectTransform.anchoredPosition + Target, duration).SetEase(ease);

        private enum ETarget
        {
            Top,
            Bottom,
            Left,
            Right
        }
    }
}
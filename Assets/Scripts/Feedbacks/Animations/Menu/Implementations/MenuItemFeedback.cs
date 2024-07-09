using DG.Tweening;
using UnityEngine;

namespace epoHless.Framework
{
    [CreateAssetMenu(menuName = "Feedbacks/Animations/Menu/MenuItem")]
    public class MenuItemFeedback : MenuFeedback<MenuComponent>
    {
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private Ease _ease = Ease.OutCubic;
        
        public override Tween Play(MenuComponent component)
        {
            var menu = component as Menu;
            
            foreach (var item in menu.Items)
            {
                item.Animation.Play(item);
            }
            
            return DOTween.Sequence().AppendInterval(_duration);
        }

        public override Tween Reverse(MenuComponent component)
        {
            var menu = component as Menu;
            
            foreach (var item in menu.Items)
            {
                item.Animation.Reverse(item);
            }
            
            return DOTween.Sequence().AppendInterval(_duration);
        }
    }
}
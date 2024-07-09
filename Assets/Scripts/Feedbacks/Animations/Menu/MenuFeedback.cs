using DG.Tweening;
using UnityEngine;

namespace epoHless.Framework
{
    public abstract class MenuFeedback<T> : Feedback<T> where T : Component
    {
        public abstract Tween Reverse(T menu);
    }
}
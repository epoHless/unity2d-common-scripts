using DG.Tweening;
using UnityEngine;

namespace epoHless.Framework
{
    public abstract class Feedback<T> : ScriptableObject where T : Component
    {
        public abstract Tween Play(T component);
    }
}
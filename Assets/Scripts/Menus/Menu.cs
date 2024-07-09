using DG.Tweening;
using UnityEngine;

namespace epoHless.Framework
{
    [DisallowMultipleComponent]
    public class Menu : MenuComponent
    {
        [field: SerializeField] public bool ExitOnNewPage { get; private set; } = true;
        public MenuItem[] Items { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            Items = GetComponentsInChildren<MenuItem>();
        }

        public virtual Tween Enter() => Animation.Play(this);
        public virtual Tween Exit() => Animation.Reverse(this);

        public virtual void OnOpen()
        { }
        
        public virtual void OnClose()
        { }
    }
}

using UnityEngine;

namespace epoHless.Framework
{
    public abstract class MenuComponent : MonoBehaviour
    {
        [field: SerializeField] public MenuFeedback<MenuComponent> Animation { get; private set;}
        
        public RectTransform RectTransform { get; protected set; }
        public Vector2 StartPosition { get; protected set; }
        
        protected virtual void Awake() => RectTransform = GetComponent<RectTransform>();
        
        protected virtual void Start()
        {
            StartPosition = RectTransform.anchoredPosition;
            
            if (Animation == null)
            {
                Debug.LogError($"No animation found for {name}");
            }
            
            if (RectTransform == null)
            {
                Debug.LogError($"No RectTransform found for {name}");
            }
        }
    }
}
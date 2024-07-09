using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace epoHless.Framework
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] protected Menu initialMenu;
        [SerializeField] protected bool enterInitialMenuOnStart;

        private readonly Stack<Menu> _pageStack = new Stack<Menu>();
        private bool _isAnimating;
        
        protected virtual void Start()
        {
            if (initialMenu != null)
            {
                initialMenu.gameObject.SetActive(true);
                
                if(enterInitialMenuOnStart) initialMenu.Enter().OnComplete(() => _isAnimating = false);
                _pageStack.Push(initialMenu);
            }
        }

        public void PushPage(Menu menu)
        {
            if(_isAnimating) return;
            
            _isAnimating = true;
            
            if (_pageStack.Count > 0)
            {
                Menu currentMenu = _pageStack.Peek();
                
                if (currentMenu.ExitOnNewPage)
                {
                    currentMenu.Exit().OnComplete((() =>
                    {
                        currentMenu.OnClose();
                        
                        currentMenu.gameObject.SetActive(false);
                        
                        menu.gameObject.SetActive(true);
                        
                        menu.Enter().OnComplete(() => _isAnimating = false);
                        
                        menu.OnOpen();
                        
                        _pageStack.Push(menu);
                    }));
                }
            }
        }

        public void PopPage()
        {
            if (_isAnimating) return;
            
            if (_pageStack.Count > 1)
            {
                _isAnimating = true;

                Menu menu = _pageStack.Pop();
                
                menu.Exit().OnComplete(() =>
                {
                    menu.OnClose();
                    
                    menu.gameObject.SetActive(false);
                    
                    Menu newCurrentMenu = _pageStack.Peek();

                    if (newCurrentMenu)
                    {
                        newCurrentMenu.OnOpen();
                        
                        newCurrentMenu.Enter().OnComplete(() => _isAnimating = false);
                    }
                });
            }
            else
            {
                Debug.LogWarning("Cannot pop the last page in the stack.");
            }
        }
    }
}

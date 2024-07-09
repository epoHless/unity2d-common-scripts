using UnityEngine;
using Subsystem = epoHless.Framework.Subsystem;

namespace epoHless.test
{
    public class InputSubsystem : Subsystem
    {
        private PlayerActions playerActions;
        
        public override void Initialize()
        {
            playerActions ??= new PlayerActions();
            playerActions.Enable();
            
            isInitialized = true;
        }
        
        public override void Shutdown()
        {
            playerActions.Disable();
            
            isInitialized = false;
        }

        public override void Update()
        {
            if (!isInitialized) return;
        }
    }
}
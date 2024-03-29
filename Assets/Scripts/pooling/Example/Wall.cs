using UnityEngine;

namespace epoHless
{
    public class Wall : MonoBehaviour, IDamageable
    {
        public int Health { get; set; }
        
        public void OnDeath()
        {
            
        }
    }
}

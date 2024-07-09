using epoHless.Framework;
using UnityEngine;

namespace epoHless.test
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private float moveSpeed = 1f;
        
        public void Move() => transform.position += Vector3.right * (moveSpeed * Time.deltaTime);

        private void Start() => Global.GetSubsystem<EnemySubsystem>().AddEnemy(this);
        private void OnDisable() => Global.GetSubsystem<EnemySubsystem>().RemoveEnemy(this);
    }
    
    public interface IEnemy
    {
        void Move();
    }
}
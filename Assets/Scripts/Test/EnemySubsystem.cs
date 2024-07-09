using System.Collections.Generic;
using epoHless.Framework;

namespace epoHless.test
{
    public class EnemySubsystem : Subsystem
    {
        private readonly List<IEnemy> enemies = new();
        
        public void AddEnemy(IEnemy enemy) => enemies.Add(enemy);
        public void RemoveEnemy(IEnemy enemy) => enemies.Remove(enemy);

        public override void Update()
        {
            if (!isInitialized) return;
            
            foreach (var enemy in enemies)
            {
                enemy.Move();
            }
        }
    }
}
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Projectile collides with an Enemy.
    /// </summary>
    public class ProjectileCollision : Simulation.Event<ProjectileCollision>
    {
        public EnemyController enemy;
        public GameObject projectile;

        public override void Execute()
        {
            var enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.Decrement();
                if (!enemyHealth.IsAlive)
                {
                    Schedule<EnemyDeath>().enemy = enemy;
                }
            }
            else
            {
                Schedule<EnemyDeath>().enemy = enemy;
            }
            Object.Destroy(projectile);
        }
    }
}
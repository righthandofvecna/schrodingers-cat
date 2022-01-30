using Platformer.Core;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the health component on an enemy has a hitpoint value of  0.
    /// </summary>
    /// <typeparam name="EnemyDeath"></typeparam>
    public class EnemyDeath : Simulation.Event<EnemyDeath>
    {
        public EnemyController enemy;

        public override void Execute()
        {
            // enemy._collider.enabled = false;
            enemy.control.enabled = false;
            enemy.animator.SetTrigger("death");
            if (enemy._audio && enemy.ouch)
                enemy._audio.PlayOneShot(enemy.ouch);
            Schedule<DestroyEntity>(0.5f).toDestroy = enemy.gameObject;
        }
    }
}
using System;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using Platformer.UI;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Represents the current vital statistics of the player entity.
    /// </summary>
    public class PlayerHealth : Health
    {
        public override bool Decrement() {
            if (base.IsAlive && base.Decrement()) {
                if (!base.IsAlive) {
                    Schedule<PlayerDeath>();
                }
                else {

                }
                GameObject healthbar = GameObject.FindWithTag("Healthbar");
                if (healthbar != null) {
                    healthbar.GetComponent<HealthbarController>().SetHP(base.HP);
                }
                return true;
            }
            return false;
        }

        public override bool Increment() {
            bool result = base.Increment();
            GameObject healthbar = GameObject.FindWithTag("Healthbar");
            if (healthbar != null) {
                healthbar.GetComponent<HealthbarController>().SetHP(base.HP);
            }
            return result;
        }
    }
}
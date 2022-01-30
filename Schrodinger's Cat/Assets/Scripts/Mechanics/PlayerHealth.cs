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
                GetComponent<Animator>().SetTrigger("hurt");
                PlayerController player = GetComponent<PlayerController>();
                if (player && player.audioSource && player.ouchAudio)
                    player.audioSource.PlayOneShot(player.ouchAudio);
                if (!base.IsAlive) {
                    Schedule<CollapseQuantumSuperposition>();
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
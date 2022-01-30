using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="CollapseQuantumSuperposition"></typeparam>
    public class CollapseQuantumSuperposition : Simulation.Event<CollapseQuantumSuperposition>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            Simulation.SimulationPaused = true;
            var player = model.player;
            player.controlEnabled = false;

            if (Random.value < 0.5f) {
                player.animator.SetBool("dead", true);
                Simulation.Schedule<PlayerDeath>(2);
            } else {
                player.animator.SetBool("alive", true);
                Simulation.Schedule<PlayerLife>(3f);
            }

        }
    }
}


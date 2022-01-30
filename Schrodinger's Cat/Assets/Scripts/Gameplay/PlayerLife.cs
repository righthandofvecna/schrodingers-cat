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
    /// <typeparam name="PlayerLife"></typeparam>
    public class PlayerLife : Simulation.Event<PlayerLife>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            player.health.Revive(2.5f);
            player.animator.SetBool("alive", false);
            Simulation.Schedule<EnablePlayerInput>(1f);

        }
    }
}
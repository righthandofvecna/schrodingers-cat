using System;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

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
                return true;
            }
            return false;
        }
    }
}
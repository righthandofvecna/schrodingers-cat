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
    /// <typeparam name="DestroyEntity"></typeparam>
    public class DestroyEntity : Simulation.Event<DestroyEntity>
    {
        public GameObject toDestroy;

        public override void Execute()
        {
            Object.Destroy(toDestroy);
        }
    }
}
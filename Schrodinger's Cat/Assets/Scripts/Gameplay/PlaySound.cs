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
    /// <typeparam name="PlaySound"></typeparam>
    public class PlaySound : Simulation.Event<PlaySound>
    {
        public AudioSource source;
        public AudioClip clip;

        public override void Execute()
        {
            if (clip && source)
                source.PlayOneShot(clip);
        }
    }
}
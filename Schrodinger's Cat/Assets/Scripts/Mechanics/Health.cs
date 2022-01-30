using System;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Represents the current vital statistics of some game entity.
    /// </summary>
    public class Health : MonoBehaviour
    {
        /// <summary>
        /// The maximum hit points for the entity.
        /// </summary>
        public int maxHP = 1;

        /// <summary>
        /// The amount of invincibility (in seconds) the entity gets after taking damage
        /// </summary>
        public float invincibility = 0.5f;

        /// <summary>
        /// The amount of hit points an entity has remaining.
        /// </summary>
        public int HP => currentHP;

        /// <summary>
        /// Indicates if the entity should be considered 'alive'.
        /// </summary>
        public bool IsAlive => currentHP > 0;

        /// <summary>
        /// Indicates if the entity should be considered 'invincible'.
        /// </summary>
        public bool IsInvincible => invincibilityTime > Time.time;

        int currentHP;

        float invincibilityTime = 0.0f;

        protected virtual void InvincibleAnimation(float duration) {

        }

        /// <summary>
        /// Increment the HP of the entity.
        /// </summary>
        public virtual bool Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
            return true;
        }

        /// <summary>
        /// Decrement the HP of the entity.
        /// </summary>
        public virtual bool Decrement()
        {
            if (!IsInvincible) {
                currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
                invincibilityTime = Time.time + invincibility;
                InvincibleAnimation(invincibility);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Increment the HP of the entity until HP reaches its max.
        /// </summary>
        public void Revive(float respawnInvulnerability)
        {
            while (currentHP < maxHP) Increment();
            invincibilityTime = Time.time + respawnInvulnerability;
            InvincibleAnimation(respawnInvulnerability);
        }

        /// <summary>
        /// Decrement the HP of the entity until HP reaches 0.
        /// </summary>
        public void Die()
        {
            if (currentHP > 0) {
                currentHP = 1;
                Decrement();
            }
        }

        void Awake()
        {
            currentHP = maxHP;
            Increment();
        }
    }
}

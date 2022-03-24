using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KA
{
    public class EnemyStats : CharacterStatsManager
    {
        EnemyAnimatorHandler enemyAnimatorHandler;

        public UIEnemyHealthBar enemyHealthBar;

        protected override void Awake()
        {
            base.Awake();
            enemyAnimatorHandler = GetComponentInChildren<EnemyAnimatorHandler>();
        }

        private void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            enemyHealthBar.SetMaxHealth(maxHealth);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public override void TakeDamageNoAnimation(int physicalDamage, int fireDamage)
        {
            base.TakeDamageNoAnimation(physicalDamage, fireDamage);

            enemyHealthBar.SetHealth(currentHealth);
        }

        public void BreakGuard()
        {
            enemyAnimatorHandler.PlayTargetAnimation("Break Guard", true);
        }

        public override void TakeDamage(int physicalDamage, int fireDamage, string damageAnimation = "Damage_02")
        {
            base.TakeDamage(physicalDamage, fireDamage, damageAnimation);
            enemyHealthBar.SetHealth(currentHealth);
            enemyAnimatorHandler.PlayTargetAnimation(damageAnimation, true);

            if(currentHealth <= 0)
            {
                HandleDeath();
            }
        }

        private void HandleDeath()
        {
            currentHealth = 0;
            enemyAnimatorHandler.PlayTargetAnimation("Death01", true);
            isDead = true;
        }
    }
}
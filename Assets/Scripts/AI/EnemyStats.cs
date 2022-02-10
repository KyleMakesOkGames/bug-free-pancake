using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KA
{
    public class EnemyStats : CharacterStats
    {
        EnemyAnimatorHandler enemyAnimatorHandler;

        public UIEnemyHealthBar enemyHealthBar;

        public int soulsAwardedOnDeath = 50;

        private void Awake()
        {
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

        public void TakeDamageNoAnimation(int damage)
        {
            currentHealth = currentHealth - damage;

            enemyHealthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isDead = true;
            }
        }

        public void TakeDamage(int damage)
        {
            if (isDead)
                return;

            currentHealth = currentHealth - damage;
            enemyHealthBar.SetHealth(currentHealth);

            enemyAnimatorHandler.anim.Play("Damage");

            if (currentHealth <= 0)
            {
                HandleDeath();
            }
        }

        private void HandleDeath()
        {
            currentHealth = 0;
            enemyAnimatorHandler.anim.Play("Dead");
            isDead = true;
        }
    }
}
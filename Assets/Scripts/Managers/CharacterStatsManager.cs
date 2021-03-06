using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KA
{
    public class CharacterStatsManager : MonoBehaviour
    {
        CharacterManager character;
        
        [Header("Team ID")]
        public int teamIDNumber;

        public int maxHealth;
        public int currentHealth;

        public float maxStamina;
        public float currentStamina;

        public float maxFocusPoints;
        public float currentFocusPoints;

        public int soulCount;
        public int soulsAwardedOnDeath;

        public int playerLevel = 1;

        [Header("LEVEL")]
        public int healthLevel;
        public int staminaLevel;
        public int focusLevel;
        public int strengthLevel;
        public int dexterityLevel;
        public int intelligenceLevel;
        public int faithLevel;
        public int poiseLevel;

        [Header("Poise")]
        public float totalPoiseDefence; //The TOTAL poise during damage calculation
        public float offensivePoiseBonus; //The poise you GAIN during an attack with a weapon
        public float armorPoiseBonus; //The poise you GAIN from wearing what ever you have equipped
        public float totalPoiseResetTime;
        public float poiseResetTimer;

        [Header("Armor Absorptions")]
        public float physicalDamageAbsorptionHead;
        public float physicalDamageAbsorptionBody;
        public float physicalDamageAbsorptionLegs;
        public float physicalDamageAbsorptionHands;

        public float flameDamageAbsorptionHead;
        public float flameDamageAbsorptionBody;
        public float flameDamageAbsorptionLegs;
        public float flameDamageAbsorptionHands;

        //Fire Absorption
        //Lightning Absorption
        //Magic Absorption
        //Dark Absorption

        protected virtual void Awake()
        {
            character = GetComponent<CharacterManager>();
        }

        protected virtual void Update()
        {
            HandlePoiseResetTimer();
        }

        private void Start()
        {
            totalPoiseDefence = armorPoiseBonus;
        }

        public virtual void TakeDamage(int physicalDamage, int fireDamage, string damageAnimation, CharacterManager enemyCharacterDamagingMe)
        {
            if (character.isDead)
                return;

            float totalPhysicalDamageAbsorption = 1 -
                (1 - physicalDamageAbsorptionHead / 100) *
                (1 - physicalDamageAbsorptionBody / 100) *
                (1 - physicalDamageAbsorptionLegs / 100) *
                (1 - physicalDamageAbsorptionHands / 100);

            physicalDamage = Mathf.RoundToInt(physicalDamage - (physicalDamage * totalPhysicalDamageAbsorption));

            float totalFireDamageAbsorption = 1 -
                (1 - flameDamageAbsorptionHead / 100) *
                (1 - flameDamageAbsorptionBody / 100) *
                (1 - flameDamageAbsorptionLegs / 100) *
                (1 - flameDamageAbsorptionHands / 100);

            fireDamage = Mathf.RoundToInt(fireDamage - (fireDamage * totalFireDamageAbsorption));

            float finalDamage = physicalDamage + fireDamage; //+ magicDamage + lightningDamage + darkDamage

            if (enemyCharacterDamagingMe.isPerformingFullyChargedAttack)
            {
                finalDamage = finalDamage * 2; 
            }

            currentHealth = Mathf.RoundToInt(currentHealth - finalDamage);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                character.isDead = true;
            }

        }

        public virtual void TakeDamageNoAnimation(int physicalDamage, int fireDamage)
        {
            if (character.isDead)
                return;

            float totalPhysicalDamageAbsorption = 1 -
                (1 - physicalDamageAbsorptionHead / 100) *
                (1 - physicalDamageAbsorptionBody / 100) *
                (1 - physicalDamageAbsorptionLegs / 100) *
                (1 - physicalDamageAbsorptionHands / 100);

            physicalDamage = Mathf.RoundToInt(physicalDamage - (physicalDamage * totalPhysicalDamageAbsorption));

            float totalFireDamageAbsorption = 1 -
                (1 - flameDamageAbsorptionHead / 100) *
                (1 - flameDamageAbsorptionBody / 100) *
                (1 - flameDamageAbsorptionLegs / 100) *
                (1 - flameDamageAbsorptionHands / 100);

            fireDamage = Mathf.RoundToInt(fireDamage - (fireDamage * totalFireDamageAbsorption));

            float finalDamage = physicalDamage + fireDamage; //+ magicDamage + lightningDamage + darkDamage

            currentHealth = Mathf.RoundToInt(currentHealth - finalDamage);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                character.isDead = true;
            }
        }

        public virtual void HandlePoiseResetTimer()
        {
            if (poiseResetTimer > 0)
            {
                poiseResetTimer = poiseResetTimer - Time.deltaTime;
            }
            else
            {
                totalPoiseDefence = armorPoiseBonus;
            }
        }

        public void DrainStaminaBasedOnAttackType()
        {

        }
    }
}

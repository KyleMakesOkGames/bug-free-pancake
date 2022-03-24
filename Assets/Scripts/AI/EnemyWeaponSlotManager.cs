using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KA
{
    public class EnemyWeaponSlotManager : CharacterWeaponSlotManager
    {
        public override void GrantWeaponAttackingPoiseBonus()
        {
            characterStatsManager.totalPoiseDefence = characterStatsManager.totalPoiseDefence + characterStatsManager.offensivePoiseBonus;
        }

        public override void ResetWeaponAttackingPoiseBonus()
        {
            characterStatsManager.totalPoiseDefence = characterStatsManager.armorPoiseBonus;
        }
    }
}

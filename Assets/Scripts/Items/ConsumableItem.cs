using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KA
{
    public class ConsumableItem : Item
    {
        [Header("Item Quantity")]
        public int maxItemAmount;
        public int currentItemAmount;

        [Header("Item Model")]
        public GameObject itemModel;

        [Header("Animations")]
        public string consumeAnimation;
        public bool isInteracting;

        public virtual void AttemptToConsumeItem(PlayerAnimatorManager animatorHandler, WeaponSlotManager weaponSlotManager, PlayerEffectsManager playerEffectsManager)
        {
            if(currentItemAmount > 0)
            {
                animatorHandler.PlayTargetAnimation(consumeAnimation, isInteracting, true);
            }
            else
            {
                animatorHandler.PlayTargetAnimation("Shrug", true);
            }
        }
    }
}
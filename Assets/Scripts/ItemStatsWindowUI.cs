using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace KA
{
    public class ItemStatsWindowUI : MonoBehaviour
    {
        public TMP_Text itemNameText;
        public Image itemIconImage;

        public void UpdateWeaponItemStats(WeaponItem weapon)
        {
            if (weapon != null)
            {
                if (weapon.itemName != null)
                {
                    itemNameText.text = weapon.itemName;
                }
                else
                {
                    itemNameText.text = "";
                }

                if (weapon.itemIcon != null)
                {
                    itemIconImage.gameObject.SetActive(true);
                    itemIconImage.enabled = true;
                    itemIconImage.sprite = weapon.itemIcon;
                }
                else
                {
                    itemIconImage.gameObject.SetActive(false);
                    itemIconImage.enabled = false;
                    itemIconImage.sprite = null;
                }
            }
            else
            {
                itemNameText.text = "";
                itemIconImage.gameObject.SetActive(false);
                itemIconImage.sprite = null;
            }
        }
    }
}

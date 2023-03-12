using Alexandria.ItemAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UGM.Items.Passives
{
    internal class SuperHeart : PassiveItem
    {
        public static void Init()
        {
            string ItemName = "Super Heart";
            string SpriteDirectory = "UGM/Resources/super_heart.png";
            GameObject obj = new GameObject(ItemName);

            var item = obj.AddComponent<SuperHeart>();
            ItemBuilder.AddSpriteToObject(ItemName, SpriteDirectory, obj);

            string shortDesc = "Maximum Health!";
            string longDesc = "A little boost.\n\n" +
            "Adds 2 heart containers.";

            ItemBuilder.SetupItem(item, shortDesc, longDesc, "ugm");

            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Health, 2, StatModifier.ModifyMethod.ADDITIVE);
            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Curse, 1, StatModifier.ModifyMethod.ADDITIVE);

            item.quality = PickupObject.ItemQuality.A;
        }

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            Module.Log($"Player picked up {DisplayName}");
        }

        public override void DisableEffect(PlayerController player)
        {
            Module.Log($"Player dropped or got rid of {DisplayName}");
        }
    }
}


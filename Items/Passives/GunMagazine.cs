using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Alexandria.ItemAPI;

namespace UGM
{
    public class GunMagazine : PassiveItem
    {
        //Call this method from the Start() method of your ETGModule extension
        public static void Register()
        {
            //The name of the item
            string itemName = "Gun Fanatic's Magazine";

            //Refers to an embedded png in the project. Make sure to embed your resources! Google it
            string resourceName = "UGM/Resources/gun_magazine";

            //Create new GameObject
            GameObject obj = new GameObject(itemName);

            //Add a PassiveItem component to the object
            var item = obj.AddComponent<GunMagazine>();

            //Adds a sprite component to the object and adds your texture to the item sprite collection
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);

            //Ammonomicon entry variables
            string shortDesc = "Become a gun master?";
            string longDesc = "The art of gunmanship\n\n" +
                "This weekly magazine was once cherished by a gun fanatic. It reeks of sweat and gunpowder. Boosts all gun related stats, but reduces the player's max health, and triples their curse.";

            //Adds the item to the gungeon item list, the ammonomicon, the loot table, etc.
            //Do this after ItemBuilder.AddSpriteToObject!
            ItemBuilder.SetupItem(item, shortDesc, longDesc, "ugm");

            //Debuffs
            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Health, -1, StatModifier.ModifyMethod.ADDITIVE);
            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Curse, 3f, StatModifier.ModifyMethod.MULTIPLICATIVE);
            //Buffs
            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Damage, 1.5f, StatModifier.ModifyMethod.MULTIPLICATIVE);
            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.ProjectileSpeed, 1.5f, StatModifier.ModifyMethod.MULTIPLICATIVE);
            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.ReloadSpeed, 1.5f, StatModifier.ModifyMethod.MULTIPLICATIVE);
            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Accuracy, 2f, StatModifier.ModifyMethod.MULTIPLICATIVE);


            //Set the rarity of the item
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
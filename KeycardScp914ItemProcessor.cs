using Interactables.Interobjects.DoorUtils;
using InventorySystem;
using InventorySystem.Items;
using LabApi.Features.Interfaces;
using LabApi.Features.Wrappers;
using Scp914;
using Scp914.Processors;
using System;
using KeycardItem = LabApi.Features.Wrappers.KeycardItem;

namespace CustomKeycardAPI
{
    internal class KeycardScp914ItemProcessor : IScp914ItemProcessor
    {
        public bool UsePickupMethodOnly => false;

        public Scp914Result UpgradeItem(Scp914KnobSetting setting, Item item)
        {
            var level = ((KeycardItem)item).Levels;
            var cardType = Utils.LevelsToKeycardType(level.Containment, level.Armory, level.Admin);
            //Logger.Info(cardType);
            return cardType.GetTemplate().GetComponent<Scp914ItemProcessor>().UpgradeInventoryItem(setting, item.Base);
            //var pickup = item.Base.ServerDropItem(false);
            //return UpgradePickup(setting, Pickup.Get(pickup));
        }

        public Scp914Result UpgradePickup(Scp914KnobSetting setting, Pickup pickup)
        {
            // I don't know how to get the card permission from the Pickup
            // So i have to create an Inventory instance and convert the Pickup to an Item
            var inv = new Inventory();
            var item = (InventorySystem.Items.Keycards.KeycardItem)inv.CreateItemInstance(new ItemIdentifier(pickup.Type, pickup.Serial), false);
            var level = new KeycardLevels(item.GetPermissions(null));
            var cardType = Utils.LevelsToKeycardType(level.Containment, level.Armory, level.Admin);
            //Logger.Info(cardType);
            return cardType.GetTemplate().GetComponent<Scp914ItemProcessor>().UpgradePickup(setting, pickup.Base);
        }
    }
}

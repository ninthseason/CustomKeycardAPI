using Interactables.Interobjects.DoorUtils;
using InventorySystem;
using InventorySystem.Items;
using InventorySystem.Items.Keycards;
using InventorySystem.Items.Pickups;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Arguments.Scp914Events;
using LabApi.Events.CustomHandlers;
using LabApi.Features.Console;
using LabApi.Features.Interfaces;
using LabApi.Features.Wrappers;
using Scp914;
using Scp914.Processors;
using System;
using System.Collections.Generic;
using System.Reflection;
using KeycardItem = InventorySystem.Items.Keycards.KeycardItem;

namespace CustomKeycardAPI
{
    public class PluginEventHanders : CustomEventsHandler
    {

        public override void OnServerRoundRestarted()
        {
            CustomKeycardAPI.RefreshDataBase();
        }
        public override void OnPlayerPickedUpItem(PlayerPickedUpItemEventArgs ev)
        {
            if (!CustomKeycardAPI.dtable.ContainsKey(ev.Player.UserId)) { return; }
            Utils.ReplaceKeycard(ev.Item, ev.Player);
        }
        public override void OnPlayerReceivedLoadout(PlayerReceivedLoadoutEventArgs ev)
        {
            if (!CustomKeycardAPI.dtable.ContainsKey(ev.Player.UserId)) { return; }
            List<Item> ItemsToReplace = new List<Item>();
            foreach (var item in ev.Player.Items)
            {
                switch (item.Type)
                {
                    case ItemType.KeycardMTFPrivate:
                        if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFPrivate == null) { return; }
                        ItemsToReplace.Add(item); break;
                    case ItemType.KeycardMTFOperative:
                        if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFOperative == null) { return; }
                        ItemsToReplace.Add(item); break;
                    case ItemType.KeycardMTFCaptain:
                        if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFCaptain == null) { return; }
                        ItemsToReplace.Add(item); break;
                    case ItemType.KeycardGuard:
                        if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardGuard == null) { return; }
                        ItemsToReplace.Add(item); break;
                    case ItemType.KeycardJanitor:
                        if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardJanitor == null) { return; }
                        ItemsToReplace.Add(item); break;
                    case ItemType.KeycardScientist:
                        if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardScientist == null) { return; }
                        ItemsToReplace.Add(item); break;
                    case ItemType.KeycardResearchCoordinator:
                        if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardResearchCoordinator == null) { return; }
                        ItemsToReplace.Add(item); break;
                    case ItemType.KeycardContainmentEngineer:
                        if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardContainmentEngineer == null) { return; }
                        ItemsToReplace.Add(item); break;
                    case ItemType.KeycardZoneManager:
                        if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardZoneManager == null) { return; }
                        ItemsToReplace.Add(item); break;
                    case ItemType.KeycardFacilityManager:
                        if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardFacilityManager == null) { return; }
                        ItemsToReplace.Add(item); break;

                }
            }
            foreach (var item in ItemsToReplace)
            {
                Utils.ReplaceKeycard(item, ev.Player);
            }
        }

        //public override void OnPlayerDroppedItem(PlayerDroppedItemEventArgs ev)
        //{
        //    //Type type = typeof(KeycardDetailSynchronizer);
        //    //Dictionary<ushort, ArraySegment<byte>> Database = (Dictionary<ushort, ArraySegment<byte>>)type.GetField("Database", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
        //    //Logger.Info(Database[ev.Pickup.Serial]);
        //    var inv = new Inventory();
        //    var item = (KeycardItem)inv.CreateItemInstance(new ItemIdentifier(ev.Pickup.Type, ev.Pickup.Serial), false);
        //    Logger.Info(item.GetPermissions(null));
        //}
    }
}

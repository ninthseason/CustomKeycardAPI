using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;
using LabApi.Features.Console;
using LabApi.Features.Wrappers;
using System.Collections.Generic;

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
            //Logger.Info($"Player {ev.Player.UserId} trigger customcardstyle");
            switch (ev.Item.Type)
            {
                case ItemType.KeycardMTFPrivate:
                    if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFPrivate == null) { return; }
                    ev.Player.RemoveItem(ev.Item);
                    KeycardItem.CreateCustomKeycardTaskForce(ev.Player,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFPrivate.CardName,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFPrivate.HolderName,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(2, 2, 1),
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFPrivate.PrimaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFPrivate.SecondaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFPrivate.SeriesCode,
                        0);
                    break;
                case ItemType.KeycardMTFOperative:
                    if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFOperative == null) { return; }
                    ev.Player.RemoveItem(ev.Item);
                    KeycardItem.CreateCustomKeycardTaskForce(ev.Player,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFOperative.CardName,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFOperative.HolderName,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(2, 2, 2),
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFOperative.PrimaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFOperative.SecondaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFOperative.SeriesCode,
                        0);
                    break;
                case ItemType.KeycardMTFCaptain:
                    if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFCaptain == null) { return; }
                    ev.Player.RemoveItem(ev.Item);
                    KeycardItem.CreateCustomKeycardTaskForce(ev.Player,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFCaptain.CardName,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFCaptain.HolderName,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(2, 3, 2),
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFCaptain.PrimaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFCaptain.SecondaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFCaptain.SeriesCode,
                        0);
                    break;
                case ItemType.KeycardGuard:
                    if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardGuard == null) { return; }
                    ev.Player.RemoveItem(ev.Item);
                    KeycardItem.CreateCustomKeycardMetal(ev.Player,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardGuard.CardName,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardGuard.HolderName,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardGuard.CardLabel,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(1, 1, 1),
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardGuard.PrimaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardGuard.SecondaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardGuard.LabelColor,
                        0,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardGuard.SeriesCode
                        );
                    break;
                case ItemType.KeycardJanitor:
                    if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardJanitor == null) { return; }
                    ev.Player.RemoveItem(ev.Item);
                    KeycardItem.CreateCustomKeycardSite02(ev.Player,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardJanitor.CardName,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardJanitor.HolderName,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardJanitor.CardLabel,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(1, 0, 0),
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardJanitor.PrimaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardJanitor.SecondaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardJanitor.LabelColor,
                        0);
                    break;
                case ItemType.KeycardScientist:
                    if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardScientist == null) { return; }
                    ev.Player.RemoveItem(ev.Item);
                    KeycardItem.CreateCustomKeycardSite02(ev.Player,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardScientist.CardName,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardScientist.HolderName,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardScientist.CardLabel,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(2, 0, 0),
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardScientist.PrimaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardScientist.SecondaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardScientist.LabelColor,
                        1);
                    break;
                case ItemType.KeycardResearchCoordinator:
                    if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardResearchCoordinator == null) { return; }
                    ev.Player.RemoveItem(ev.Item);
                    KeycardItem.CreateCustomKeycardSite02(ev.Player,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardResearchCoordinator.CardName,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardResearchCoordinator.HolderName,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardResearchCoordinator.CardLabel,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(2, 0, 1),
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardResearchCoordinator.PrimaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardResearchCoordinator.SecondaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardResearchCoordinator.LabelColor,
                        2);
                    break;
                case ItemType.KeycardContainmentEngineer:
                    if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardContainmentEngineer == null) { return; }
                    ev.Player.RemoveItem(ev.Item);
                    KeycardItem.CreateCustomKeycardSite02(ev.Player,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardContainmentEngineer.CardName,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardContainmentEngineer.HolderName,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardContainmentEngineer.CardLabel,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(3, 0, 1),
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardContainmentEngineer.PrimaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardContainmentEngineer.SecondaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardContainmentEngineer.LabelColor,
                        3);
                    break;
                case ItemType.KeycardZoneManager:
                    if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardZoneManager == null) { return; }
                    ev.Player.RemoveItem(ev.Item);
                    KeycardItem.CreateCustomKeycardManagement(ev.Player,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardZoneManager.CardName,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardZoneManager.CardLabel,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(1, 0, 1),
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardZoneManager.PrimaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardZoneManager.SecondaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardZoneManager.LabelColor
                        );
                    break;
                case ItemType.KeycardFacilityManager:
                    if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardFacilityManager == null) { return; }
                    ev.Player.RemoveItem(ev.Item);
                    KeycardItem.CreateCustomKeycardManagement(ev.Player,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardFacilityManager.CardName,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardFacilityManager.CardLabel,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(3, 0, 3),
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardFacilityManager.PrimaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardFacilityManager.SecondaryColor,
                        CustomKeycardAPI.dtable[ev.Player.UserId].KeycardFacilityManager.LabelColor
                        );
                    break;

            }
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
                switch (item.Type)
                {
                    case ItemType.KeycardMTFPrivate:
                        ev.Player.RemoveItem(item);
                        KeycardItem.CreateCustomKeycardTaskForce(ev.Player,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFPrivate.CardName,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFPrivate.HolderName,
                            new Interactables.Interobjects.DoorUtils.KeycardLevels(2, 2, 1),
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFPrivate.PrimaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFPrivate.SecondaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFPrivate.SeriesCode,
                            0);
                        break;
                    case ItemType.KeycardMTFOperative:
                        ev.Player.RemoveItem(item);
                        KeycardItem.CreateCustomKeycardTaskForce(ev.Player,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFOperative.CardName,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFOperative.HolderName,
                            new Interactables.Interobjects.DoorUtils.KeycardLevels(2, 2, 2),
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFOperative.PrimaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFOperative.SecondaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFOperative.SeriesCode,
                            0);
                        break;
                    case ItemType.KeycardMTFCaptain:
                        ev.Player.RemoveItem(item);
                        KeycardItem.CreateCustomKeycardTaskForce(ev.Player,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFCaptain.CardName,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFCaptain.HolderName,
                            new Interactables.Interobjects.DoorUtils.KeycardLevels(2, 3, 2),
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFCaptain.PrimaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFCaptain.SecondaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardMTFCaptain.SeriesCode,
                            0);
                        break;
                    case ItemType.KeycardGuard:
                        ev.Player.RemoveItem(item);
                        KeycardItem.CreateCustomKeycardMetal(ev.Player,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardGuard.CardName,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardGuard.HolderName,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardGuard.CardLabel,
                            new Interactables.Interobjects.DoorUtils.KeycardLevels(1, 1, 1),
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardGuard.PrimaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardGuard.SecondaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardGuard.LabelColor,
                            0,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardGuard.SeriesCode
                            );
                        break;
                    case ItemType.KeycardJanitor:
                        ev.Player.RemoveItem(item);
                        KeycardItem.CreateCustomKeycardSite02(ev.Player,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardJanitor.CardName,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardJanitor.HolderName,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardJanitor.CardLabel,
                            new Interactables.Interobjects.DoorUtils.KeycardLevels(1, 0, 0),
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardJanitor.PrimaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardJanitor.SecondaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardJanitor.LabelColor,
                            0);
                        break;
                    case ItemType.KeycardScientist:
                        ev.Player.RemoveItem(item);
                        KeycardItem.CreateCustomKeycardSite02(ev.Player,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardScientist.CardName,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardScientist.HolderName,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardScientist.CardLabel,
                            new Interactables.Interobjects.DoorUtils.KeycardLevels(2, 0, 0),
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardScientist.PrimaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardScientist.SecondaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardScientist.LabelColor,
                            1);
                        break;
                    case ItemType.KeycardResearchCoordinator:
                        ev.Player.RemoveItem(item);
                        KeycardItem.CreateCustomKeycardSite02(ev.Player,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardResearchCoordinator.CardName,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardResearchCoordinator.HolderName,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardResearchCoordinator.CardLabel,
                            new Interactables.Interobjects.DoorUtils.KeycardLevels(2, 0, 1),
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardResearchCoordinator.PrimaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardResearchCoordinator.SecondaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardResearchCoordinator.LabelColor,
                            2);
                        break;
                    case ItemType.KeycardContainmentEngineer:
                        ev.Player.RemoveItem(item);
                        KeycardItem.CreateCustomKeycardSite02(ev.Player,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardContainmentEngineer.CardName,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardContainmentEngineer.HolderName,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardContainmentEngineer.CardLabel,
                            new Interactables.Interobjects.DoorUtils.KeycardLevels(3, 0, 1),
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardContainmentEngineer.PrimaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardContainmentEngineer.SecondaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardContainmentEngineer.LabelColor,
                            3);
                        break;
                    case ItemType.KeycardZoneManager:
                        ev.Player.RemoveItem(item);
                        KeycardItem.CreateCustomKeycardManagement(ev.Player,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardZoneManager.CardName,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardZoneManager.CardLabel,
                            new Interactables.Interobjects.DoorUtils.KeycardLevels(1, 0, 1),
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardZoneManager.PrimaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardZoneManager.SecondaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardZoneManager.LabelColor
                            );
                        break;
                    case ItemType.KeycardFacilityManager:
                        if (CustomKeycardAPI.dtable[ev.Player.UserId].KeycardFacilityManager == null) { return; }
                        ev.Player.RemoveItem(item);
                        KeycardItem.CreateCustomKeycardManagement(ev.Player,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardFacilityManager.CardName,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardFacilityManager.CardLabel,
                            new Interactables.Interobjects.DoorUtils.KeycardLevels(3, 0, 3),
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardFacilityManager.PrimaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardFacilityManager.SecondaryColor,
                            CustomKeycardAPI.dtable[ev.Player.UserId].KeycardFacilityManager.LabelColor
                            );
                        break;

                }
            }
        }
               
    }
}

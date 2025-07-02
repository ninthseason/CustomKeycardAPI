using LabApi.Features.Wrappers;

namespace CustomKeycardAPI
{
    public static class Utils
    {
        public static void ReplaceKeycard(Item keycard, Player player)
        {
            switch (keycard.Type)
            {
                case ItemType.KeycardMTFPrivate:
                    if (CustomKeycardAPI.dtable[player.UserId].KeycardMTFPrivate == null) { return; }
                    player.RemoveItem(keycard);
                    KeycardItem.CreateCustomKeycardTaskForce(player,
                        CustomKeycardAPI.dtable[player.UserId].KeycardMTFPrivate.CardName,
                        CustomKeycardAPI.dtable[player.UserId].KeycardMTFPrivate.HolderName,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(2, 2, 1),
                        CustomKeycardAPI.dtable[player.UserId].KeycardMTFPrivate.PrimaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardMTFPrivate.SecondaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardMTFPrivate.SeriesCode,
                        0);
                    break;
                case ItemType.KeycardMTFOperative:
                    if (CustomKeycardAPI.dtable[player.UserId].KeycardMTFOperative == null) { return; }
                    player.RemoveItem(keycard);
                    KeycardItem.CreateCustomKeycardTaskForce(player,
                        CustomKeycardAPI.dtable[player.UserId].KeycardMTFOperative.CardName,
                        CustomKeycardAPI.dtable[player.UserId].KeycardMTFOperative.HolderName,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(2, 2, 2),
                        CustomKeycardAPI.dtable[player.UserId].KeycardMTFOperative.PrimaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardMTFOperative.SecondaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardMTFOperative.SeriesCode,
                        0);
                    break;
                case ItemType.KeycardMTFCaptain:
                    if (CustomKeycardAPI.dtable[player.UserId].KeycardMTFCaptain == null) { return; }
                    player.RemoveItem(keycard);
                    KeycardItem.CreateCustomKeycardTaskForce(player,
                        CustomKeycardAPI.dtable[player.UserId].KeycardMTFCaptain.CardName,
                        CustomKeycardAPI.dtable[player.UserId].KeycardMTFCaptain.HolderName,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(2, 3, 2),
                        CustomKeycardAPI.dtable[player.UserId].KeycardMTFCaptain.PrimaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardMTFCaptain.SecondaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardMTFCaptain.SeriesCode,
                        0);
                    break;
                case ItemType.KeycardGuard:
                    if (CustomKeycardAPI.dtable[player.UserId].KeycardGuard == null) { return; }
                    player.RemoveItem(keycard);
                    KeycardItem.CreateCustomKeycardMetal(player,
                        CustomKeycardAPI.dtable[player.UserId].KeycardGuard.CardName,
                        CustomKeycardAPI.dtable[player.UserId].KeycardGuard.HolderName,
                        CustomKeycardAPI.dtable[player.UserId].KeycardGuard.CardLabel,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(1, 1, 1),
                        CustomKeycardAPI.dtable[player.UserId].KeycardGuard.PrimaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardGuard.SecondaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardGuard.LabelColor,
                        0,
                        CustomKeycardAPI.dtable[player.UserId].KeycardGuard.SeriesCode
                        );
                    break;
                case ItemType.KeycardJanitor:
                    if (CustomKeycardAPI.dtable[player.UserId].KeycardJanitor == null) { return; }
                    player.RemoveItem(keycard);
                    KeycardItem.CreateCustomKeycardSite02(player,
                        CustomKeycardAPI.dtable[player.UserId].KeycardJanitor.CardName,
                        CustomKeycardAPI.dtable[player.UserId].KeycardJanitor.HolderName,
                        CustomKeycardAPI.dtable[player.UserId].KeycardJanitor.CardLabel,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(1, 0, 0),
                        CustomKeycardAPI.dtable[player.UserId].KeycardJanitor.PrimaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardJanitor.SecondaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardJanitor.LabelColor,
                        0);
                    break;
                case ItemType.KeycardScientist:
                    if (CustomKeycardAPI.dtable[player.UserId].KeycardScientist == null) { return; }
                    player.RemoveItem(keycard);
                    KeycardItem.CreateCustomKeycardSite02(player,
                        CustomKeycardAPI.dtable[player.UserId].KeycardScientist.CardName,
                        CustomKeycardAPI.dtable[player.UserId].KeycardScientist.HolderName,
                        CustomKeycardAPI.dtable[player.UserId].KeycardScientist.CardLabel,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(2, 0, 0),
                        CustomKeycardAPI.dtable[player.UserId].KeycardScientist.PrimaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardScientist.SecondaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardScientist.LabelColor,
                        1);
                    break;
                case ItemType.KeycardResearchCoordinator:
                    if (CustomKeycardAPI.dtable[player.UserId].KeycardResearchCoordinator == null) { return; }
                    player.RemoveItem(keycard);
                    KeycardItem.CreateCustomKeycardSite02(player,
                        CustomKeycardAPI.dtable[player.UserId].KeycardResearchCoordinator.CardName,
                        CustomKeycardAPI.dtable[player.UserId].KeycardResearchCoordinator.HolderName,
                        CustomKeycardAPI.dtable[player.UserId].KeycardResearchCoordinator.CardLabel,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(2, 0, 1),
                        CustomKeycardAPI.dtable[player.UserId].KeycardResearchCoordinator.PrimaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardResearchCoordinator.SecondaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardResearchCoordinator.LabelColor,
                        2);
                    break;
                case ItemType.KeycardContainmentEngineer:
                    if (CustomKeycardAPI.dtable[player.UserId].KeycardContainmentEngineer == null) { return; }
                    player.RemoveItem(keycard);
                    KeycardItem.CreateCustomKeycardSite02(player,
                        CustomKeycardAPI.dtable[player.UserId].KeycardContainmentEngineer.CardName,
                        CustomKeycardAPI.dtable[player.UserId].KeycardContainmentEngineer.HolderName,
                        CustomKeycardAPI.dtable[player.UserId].KeycardContainmentEngineer.CardLabel,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(3, 0, 1),
                        CustomKeycardAPI.dtable[player.UserId].KeycardContainmentEngineer.PrimaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardContainmentEngineer.SecondaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardContainmentEngineer.LabelColor,
                        3);
                    break;
                case ItemType.KeycardZoneManager:
                    if (CustomKeycardAPI.dtable[player.UserId].KeycardZoneManager == null) { return; }
                    player.RemoveItem(keycard);
                    KeycardItem.CreateCustomKeycardManagement(player,
                        CustomKeycardAPI.dtable[player.UserId].KeycardZoneManager.CardName,
                        CustomKeycardAPI.dtable[player.UserId].KeycardZoneManager.CardLabel,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(1, 0, 1),
                        CustomKeycardAPI.dtable[player.UserId].KeycardZoneManager.PrimaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardZoneManager.SecondaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardZoneManager.LabelColor
                        );
                    break;
                case ItemType.KeycardFacilityManager:
                    if (CustomKeycardAPI.dtable[player.UserId].KeycardFacilityManager == null) { return; }
                    player.RemoveItem(keycard);
                    KeycardItem.CreateCustomKeycardManagement(player,
                        CustomKeycardAPI.dtable[player.UserId].KeycardFacilityManager.CardName,
                        CustomKeycardAPI.dtable[player.UserId].KeycardFacilityManager.CardLabel,
                        new Interactables.Interobjects.DoorUtils.KeycardLevels(3, 0, 3),
                        CustomKeycardAPI.dtable[player.UserId].KeycardFacilityManager.PrimaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardFacilityManager.SecondaryColor,
                        CustomKeycardAPI.dtable[player.UserId].KeycardFacilityManager.LabelColor
                        );
                    break;
            }
        }

        public static ItemType LevelsToKeycardType(int containment, int armory, int admin)
        {
            if (containment == 1 && armory == 1 && admin == 1) { return ItemType.KeycardGuard; }
            if (containment == 2 && armory == 0 && admin == 0) { return ItemType.KeycardScientist; }
            if (containment == 2 && armory == 0 && admin == 1) { return ItemType.KeycardResearchCoordinator; }
            if (containment == 3 && armory == 0 && admin == 1) { return ItemType.KeycardContainmentEngineer; }
            if (containment == 1 && armory == 0 && admin == 0) { return ItemType.KeycardJanitor; }
            if (containment == 2 && armory == 2 && admin == 1) { return ItemType.KeycardMTFPrivate; }
            if (containment == 2 && armory == 2 && admin == 2) { return ItemType.KeycardMTFOperative; }
            if (containment == 2 && armory == 3 && admin == 2) { return ItemType.KeycardMTFCaptain; }
            if (containment == 1 && armory == 0 && admin == 1) { return ItemType.KeycardZoneManager; }
            if (containment == 3 && armory == 0 && admin == 3) { return ItemType.KeycardFacilityManager; }
            return ItemType.KeycardCustomSite02;
        }
    }
}

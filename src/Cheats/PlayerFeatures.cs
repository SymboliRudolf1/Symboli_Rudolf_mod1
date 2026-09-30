using UnityEngine;
using InnerNet;

namespace MalumMenu;

public static class PlayerFeatures
{
    public static void FollowPlayer(PlayerControl target)
    {
        if (target == null || PlayerControl.LocalPlayer == null) return;
        var localPlayer = PlayerControl.LocalPlayer;
        Vector3 targetPos = target.transform.position;
        localPlayer.NetTransform.RpcSnapTo(new Vector2(targetPos.x + 0.5f, targetPos.y + 0.5f));
    }

    public static void RevivePlayer(PlayerControl target)
    {
        if (!AmongUsClient.Instance.AmHost || target == null) return;
        target.Revive();
        target.Data.IsDead = false;
        target.gameObject.SetActive(true);
    }

    public static void ChangePlayerPet(PlayerControl target, string petId)
    {
        if (target == null) return;
        target.RpcSetPet(petId);
    }

    public static void RemovePlayerPet(PlayerControl target)
    {
        if (target == null) return;
        target.RpcSetPet("");
    }

    public static void MorphInto(PlayerControl target)
    {
        if (target == null || PlayerControl.LocalPlayer == null) return;
        var localPlayer = PlayerControl.LocalPlayer;
        var targetOutfit = target.Data.DefaultOutfit;
        localPlayer.RpcSetColor((byte)targetOutfit.ColorId);
        localPlayer.RpcSetHat(targetOutfit.HatId);
        localPlayer.RpcSetSkin(targetOutfit.SkinId);
        localPlayer.RpcSetPet(targetOutfit.PetId);
        localPlayer.RpcSetVisor(targetOutfit.VisorId);
        localPlayer.RpcSetNamePlate(targetOutfit.NamePlateId);
    }
}
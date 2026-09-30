using UnityEngine;
using InnerNet;
using System.Linq;
using System.Collections.Generic;

namespace MalumMenu;

public static class PlayerTrollFeatures
{
    // Teletransportar a TODOS los jugadores a tu posición
    public static void TeleportAllToMe()
    {
        if (!AmongUsClient.Instance.AmHost) return;
        
        var localPos = PlayerControl.LocalPlayer.transform.position;
        
        foreach (var player in PlayerControl.AllPlayerControls)
        {
            if (player != null && !player.AmOwner)
            {
                player.NetTransform.RpcSnapTo(new Vector2(localPos.x, localPos.y));
            }
        }
    }

    // Scatter - Mandar a todos los jugadores a posiciones aleatorias
    public static void ScatterAllPlayers()
    {
        if (!AmongUsClient.Instance.AmHost) return;
        
        foreach (var player in PlayerControl.AllPlayerControls)
        {
            if (player != null && !player.AmOwner)
            {
                Vector2 randomPos = new Vector2(
                    Random.Range(-20f, 20f),
                    Random.Range(-20f, 20f)
                );
                player.NetTransform.RpcSnapTo(randomPos);
            }
        }
    }

    // Enviar chat como si fueras otro jugador
    public static void SendChatAsPlayer(PlayerControl target, string message)
    {
        if (target == null) return;
        target.RpcSendChat(message);
    }

    // Cambiar nombre de otro jugador (solo host)
    public static void ChangePlayerName(PlayerControl target, string newName)
    {
        if (!AmongUsClient.Instance.AmHost || target == null) return;
        target.RpcSetName(newName);
    }

    // Cambiar color de otro jugador (solo host)
    public static void ChangePlayerColor(PlayerControl target, byte colorId)
    {
        if (!AmongUsClient.Instance.AmHost || target == null) return;
        target.RpcSetColor(colorId);
    }

    // Resetear cooldown de kill de un impostor (solo host)
    public static void ResetKillCooldown(PlayerControl target)
    {
        if (!AmongUsClient.Instance.AmHost || target == null) return;
        
        if (target.Data.Role.IsImpostor)
        {
            target.SetKillTimer(0f);
        }
    }

    // Congelar jugador
    private static Dictionary<byte, Vector2> frozenPlayers = new Dictionary<byte, Vector2>();
    
    public static void ToggleFreezePlayer(PlayerControl target)
    {
        if (!AmongUsClient.Instance.AmHost || target == null) return;
        
        if (frozenPlayers.ContainsKey(target.PlayerId))
            frozenPlayers.Remove(target.PlayerId);
        else
            frozenPlayers[target.PlayerId] = target.transform.position;
    }

    // Actualizar congelados (llamar en Update)
    public static void UpdateFrozenPlayers()
    {
        if (!AmongUsClient.Instance.AmHost) return;
        
        foreach (var kvp in frozenPlayers.ToList())
        {
            var player = PlayerControl.AllPlayerControls.ToArray().FirstOrDefault(p => p?.PlayerId == kvp.Key);
            if (player != null)
                player.NetTransform.RpcSnapTo(kvp.Value);
        }
    }
}
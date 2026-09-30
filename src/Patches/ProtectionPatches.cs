using HarmonyLib;
using Il2CppInterop.Runtime;
using InnerNet;
using System;
using System.Reflection;
using UnityEngine;

namespace MalumMenu
{
    public static class ProtectionPatches
    {
        // Anti-Kick: Bloquea kicks del servidor
        [HarmonyPatch(typeof(InnerNetClient), nameof(InnerNetClient.KickPlayer))]
        public static class AntiKickPatch
        {
            public static bool Prefix(InnerNetClient __instance, int clientId, bool ban)
            {
                if (!CheatToggles.AntiKick) return true;
                
                // Si es nuestro propio clientId, bloquear
                if (clientId == AmongUsClient.Instance.ClientId)
                {
                    MalumMenu.Log.LogInfo("Anti-Kick: Bloqueado intento de kick");
                    return false;
                }
                return true;
            }
        }

        // Anti-Ban: Similar al anti-kick pero específico para bans
        [HarmonyPatch(typeof(InnerNetClient), nameof(InnerNetClient.KickPlayer))]
        public static class AntiBanPatch
        {
            public static bool Prefix(InnerNetClient __instance, int clientId, bool ban)
            {
                if (!CheatToggles.AntiBan) return true;
                
                if (ban && clientId == AmongUsClient.Instance.ClientId)
                {
                    MalumMenu.Log.LogInfo("Anti-Ban: Bloqueado intento de ban");
                    return false;
                }
                return true;
            }
        }

        // No Penalty DC: Evita penalización por desconexión
        [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnDisconnected))]
        public static class NoPenaltyDCPatch
        {
            public static void Postfix(AmongUsClient __instance, DisconnectReasons reason, string stringReason)
            {
                if (!CheatToggles.NoPenaltyDC) return;
                
                // Resetear estado de ban points
                try
                {
                    // Intentar obtener ban data mediante reflexión
                    var dataManagerType = Type.GetType("AmongUs.DataManager, Assembly-CSharp");
                    if (dataManagerType != null)
                    {
                        var playerProperty = dataManagerType.GetProperty("Player", BindingFlags.Static | BindingFlags.Public);
                        if (playerProperty != null)
                        {
                            var playerData = playerProperty.GetValue(null);
                            var banProperty = playerData.GetType().GetProperty("Ban");
                            if (banProperty != null)
                            {
                                var banData = banProperty.GetValue(playerData);
                                var banPointsField = banData.GetType().GetField("banPoints", 
                                    BindingFlags.NonPublic | BindingFlags.Instance);
                                if (banPointsField != null)
                                {
                                    banPointsField.SetValue(banData, 0.0f);
                                    MalumMenu.Log.LogInfo("No Penalty DC: Ban points reseteados");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MalumMenu.Log.LogInfo($"No Penalty DC Error: {ex.Message}");
                }
            }
        }

        // Anti-Vote: Evita que los votos te afecten
        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.CmdCastVote))]
        public static class AntiVotePatch
        {
            public static bool Prefix(MeetingHud __instance, byte playerId, byte suspectPlayerId)
            {
                // Si alguien vota por nosotros y Anti-Vote está activo
                if (CheatToggles.AntiVote && suspectPlayerId == PlayerControl.LocalPlayer.PlayerId)
                {
                    MalumMenu.Log.LogInfo($"Anti-Vote: Bloqueado voto de jugador {playerId}");
                    return false;
                }
                return true;
            }
        }

        // Anti-Report: Bloquea reportes de cuerpos (versión compatible v18s)
        [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.ReportDeadBody))]
        public static class AntiReportPatch
        {
            // Usamos object[] __args para mayor compatibilidad entre versiones
            public static bool Prefix(PlayerControl __instance, object[] __args)
            {
                if (!CheatToggles.AntiReport) return true;
                
                // Si somos nosotros quienes reportamos, permitir
                if (__instance.PlayerId == PlayerControl.LocalPlayer.PlayerId) return true;
                
                // Bloquear reportes de otros jugadores
                MalumMenu.Log.LogInfo("Anti-Report: Bloqueado reporte de otro jugador");
                return false;
            }
        }

        // Auto-Kick: Kickea jugadores automáticamente (placeholder)
        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Update))]
        public static class AutoKickPatch
        {
            private static float lastKickTime = 0f;
            
            public static void Postfix(MeetingHud __instance)
            {
                if (!CheatToggles.AutoKick) return;
                
                // Solo host puede kickear
                if (!AmongUsClient.Instance.AmHost) return;
                
                // Cooldown de 5 segundos entre kicks
                if (Time.time - lastKickTime < 5f) return;
                
                // Implementación básica - kickar jugadores específicos
                // Aquí puedes agregar lógica para kickar jugadores específicos
            }
        }

        // Anti-Cheat Detection: Oculta detección de cheats básica
        [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.RpcSendChat))]
        public static class AntiDetectionPatch
        {
            public static void Prefix(ref string chatMessage)
            {
                // Sanitizar mensajes para evitar detección automática
                if (string.IsNullOrEmpty(chatMessage)) return;
                
                // Limitar longitud para evitar spam detection
                if (chatMessage.Length > 100)
                {
                    chatMessage = chatMessage.Substring(0, 100);
                }
            }
        }
    }
}
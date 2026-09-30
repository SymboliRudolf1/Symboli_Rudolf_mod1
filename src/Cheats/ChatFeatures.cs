using UnityEngine;
using InnerNet;

namespace MalumMenu;

public static class ChatFeatures
{
    // Enviar mensaje como si fueras otro jugador
    public static void SendChatAsPlayer(PlayerControl target, string message)
    {
        if (target == null || string.IsNullOrWhiteSpace(message)) return;
        
        // Envía el mensaje usando el RPC del jugador objetivo
        target.RpcSendChat(message);
    }

    // Spam de mensajes rápidos
    public static void SpamChat(PlayerControl target, string message, int times)
    {
        if (target == null || string.IsNullOrWhiteSpace(message)) return;
        
        for (int i = 0; i < times; i++)
        {
            target.RpcSendChat($"{message} [{i}]");
        }
    }

    // Mensajes predefinidos
    public static void SendPresetMessage(PlayerControl target, int presetIndex)
    {
        if (target == null) return;
        
        string[] presets = new string[]
        {
            "I am impostor",
            "Hello everyone",
            "Sus",
            "Where?",
            "Vote red",
            "Trust me",
            "I saw him vent",
            "Self report"
        };
        
        if (presetIndex >= 0 && presetIndex < presets.Length)
        {
            target.RpcSendChat(presets[presetIndex]);
        }
    }
}
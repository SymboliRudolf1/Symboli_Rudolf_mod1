using UnityEngine;
using InnerNet;
using System.Linq;

namespace MalumMenu;

public class ChatTab : ITab
{
    public string name => "Chat";
    
    // Variables para Send Chat As Player
    private Vector2 playerScrollPosition;
    private PlayerControl selectedPlayer;
//    private int selectedPreset = 0;
    
    private string[] presetMessages = new string[]
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

    public void Draw()
    {
        GUILayout.BeginVertical(GUILayout.Width(MenuUI.windowWidth * 0.425f));

        DrawGeneral();

        GUILayout.Space(15);

        DrawTextbox();

        GUILayout.Space(15);
        
        // NUEVA SECCIÓN: Send Chat As Player
        DrawSendChatAsPlayer();

        GUILayout.EndVertical();
    }

    private void DrawGeneral()
    {
        CheatToggles.enableChat = GUILayout.Toggle(CheatToggles.enableChat, " Habilitar chat");

        CheatToggles.bypassUrlBlock = GUILayout.Toggle(CheatToggles.bypassUrlBlock, " Omitir el bloqueo de URL");

        CheatToggles.lowerRateLimits = GUILayout.Toggle(CheatToggles.lowerRateLimits, " Límites de tarifas más bajos");
    }

    private void DrawTextbox()
    {
        GUILayout.Label("Caja de Texto", GUIStylePreset.TabSubtitle);

        CheatToggles.unlockCharacters = GUILayout.Toggle(CheatToggles.unlockCharacters, " Desbloquea caracteres adicionales");

        CheatToggles.longerMessages = GUILayout.Toggle(CheatToggles.longerMessages, " Permitir mensajes más largos");

        CheatToggles.unlockClipboard = GUILayout.Toggle(CheatToggles.unlockClipboard, " Desbloquear el portapapeles");
    }
    
    // NUEVA FUNCIÓN: Send Chat As Player
    private void DrawSendChatAsPlayer()
    {
        GUILayout.Label("Send Chat As Player:", GUIStylePreset.TabSubtitle);
        
        // Selección de jugador
        GUILayout.Label("Select Player:", GUILayout.Height(20));
        
        var players = PlayerControl.AllPlayerControls.ToArray()
            .Where(p => p != null && !p.AmOwner)
            .ToArray();
        
        playerScrollPosition = GUILayout.BeginScrollView(playerScrollPosition, GUILayout.Height(80));
        
        foreach (var player in players)
        {
            bool isSelected = selectedPlayer == player;
            GUI.backgroundColor = isSelected ? Color.green : Color.white;
            
            if (GUILayout.Button(player.Data?.PlayerName ?? "Unknown", GUILayout.Height(22)))
            {
                selectedPlayer = player;
            }
        }
        
        GUI.backgroundColor = Color.white;
        GUILayout.EndScrollView();
        
        GUILayout.Space(5);
        
        // Mensajes predefinidos
        GUILayout.Label("Quick Messages:", GUILayout.Height(20));
        
        for (int i = 0; i < presetMessages.Length; i++)
        {
            if (GUILayout.Button(presetMessages[i], GUILayout.Height(22)))
            {
                if (selectedPlayer != null)
                {
                    ChatFeatures.SendChatAsPlayer(selectedPlayer, presetMessages[i]);
                }
            }
        }
        
        GUILayout.Space(5);
        
        // Info del jugador seleccionado
        if (selectedPlayer != null)
        {
            GUILayout.Label($"Target: {selectedPlayer.Data?.PlayerName}");
        }
        else
        {
            GUILayout.Label("Select a player above");
        }
    }
}
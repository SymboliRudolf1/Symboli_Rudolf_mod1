using UnityEngine;
using InnerNet;
using System.Linq;

namespace MalumMenu;

public class TrollTab : ITab
{
    public string name => "Troll";
    
    private Vector2 scrollPosition;
    private PlayerControl selectedPlayer;
//    private bool showNameInput = false;
//    private bool showChatInput = false;

    public void Draw()
    {
        GUILayout.BeginVertical();
        
        bool isHost = AmongUsClient.Instance.AmHost;
        
        GUILayout.Label($"Status: {(isHost ? "HOST" : "CLIENT")}");
        GUILayout.Space(10);
        
        // Mass Actions (Host only)
        GUILayout.Label("Mass Actions (Host):", new GUIStyle(GUI.skin.label) { fontStyle = FontStyle.Bold });
        
        GUI.enabled = isHost;
        
        if (GUILayout.Button("Teleport ALL to Me", GUILayout.Height(30)))
        {
            PlayerTrollFeatures.TeleportAllToMe();
        }
        
        if (GUILayout.Button("Scatter All Players", GUILayout.Height(30)))
        {
            PlayerTrollFeatures.ScatterAllPlayers();
        }
        
        GUILayout.Space(10);
        
        // Player Selection
        GUILayout.Label("Select Player:", new GUIStyle(GUI.skin.label) { fontStyle = FontStyle.Bold });
        
        var players = PlayerControl.AllPlayerControls.ToArray()
            .Where(p => p != null && !p.AmOwner)
            .ToArray();
        
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(100));
        
        foreach (var player in players)
        {
            bool isSelected = selectedPlayer == player;
            GUI.backgroundColor = isSelected ? Color.green : Color.white;
            
            if (GUILayout.Button($"{player.Data?.PlayerName}"))
            {
                selectedPlayer = player;
            }
        }
        
        GUI.backgroundColor = Color.white;
        GUILayout.EndScrollView();
        
        GUILayout.Space(10);
        
        // Player Actions
        GUILayout.Label("Player Actions:", new GUIStyle(GUI.skin.label) { fontStyle = FontStyle.Bold });
        
        GUI.enabled = selectedPlayer != null && isHost;
        
        // Change Name - Usar botones predefinidos en lugar de input
        if (GUILayout.Button("Change Name to 'Impostor'", GUILayout.Height(25)))
        {
            PlayerTrollFeatures.ChangePlayerName(selectedPlayer, "Impostor");
        }
        
        if (GUILayout.Button("Change Name to 'Crewmate'", GUILayout.Height(25)))
        {
            PlayerTrollFeatures.ChangePlayerName(selectedPlayer, "Crewmate");
        }
        
        // Change Color
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Color: Red")) PlayerTrollFeatures.ChangePlayerColor(selectedPlayer, 0);
        if (GUILayout.Button("Color: Blue")) PlayerTrollFeatures.ChangePlayerColor(selectedPlayer, 1);
        if (GUILayout.Button("Color: Green")) PlayerTrollFeatures.ChangePlayerColor(selectedPlayer, 2);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Color: Pink")) PlayerTrollFeatures.ChangePlayerColor(selectedPlayer, 3);
        if (GUILayout.Button("Color: Orange")) PlayerTrollFeatures.ChangePlayerColor(selectedPlayer, 4);
        if (GUILayout.Button("Color: Yellow")) PlayerTrollFeatures.ChangePlayerColor(selectedPlayer, 5);
        GUILayout.EndHorizontal();
        
        // Reset Kill Cooldown
        if (GUILayout.Button("Reset Kill Cooldown", GUILayout.Height(25)))
        {
            PlayerTrollFeatures.ResetKillCooldown(selectedPlayer);
        }
        
        // Freeze
        if (GUILayout.Button("Toggle Freeze", GUILayout.Height(25)))
        {
            PlayerTrollFeatures.ToggleFreezePlayer(selectedPlayer);
        }
        
        GUILayout.Space(10);
        
        // Chat Spoof - Mensajes predefinidos
        GUILayout.Label("Chat Spoof:", new GUIStyle(GUI.skin.label) { fontStyle = FontStyle.Bold });
        
        GUI.enabled = selectedPlayer != null;
        
        if (GUILayout.Button("Say: 'I am impostor'", GUILayout.Height(25)))
        {
            PlayerTrollFeatures.SendChatAsPlayer(selectedPlayer, "I am impostor");
        }
        
        if (GUILayout.Button("Say: 'Hello'", GUILayout.Height(25)))
        {
            PlayerTrollFeatures.SendChatAsPlayer(selectedPlayer, "Hello");
        }
        
        if (GUILayout.Button("Say: 'Sus'", GUILayout.Height(25)))
        {
            PlayerTrollFeatures.SendChatAsPlayer(selectedPlayer, "Sus");
        }
        
        GUI.enabled = true;
        
        GUILayout.EndVertical();
    }
}
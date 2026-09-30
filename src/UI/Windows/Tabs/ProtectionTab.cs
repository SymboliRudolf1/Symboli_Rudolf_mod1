using UnityEngine;

namespace MalumMenu;

public class ProtectionTab : ITab
{
    public string name => "Protection";

    public void Draw()
    {
        GUILayout.BeginVertical();
        
        GUILayout.Label("Protection Settings:", new GUIStyle(GUI.skin.label) { fontStyle = FontStyle.Bold });
        GUILayout.Space(10);
        
        GUI.backgroundColor = ProtectionFeatures.antiKickEnabled ? Color.green : Color.red;
        if (GUILayout.Button($"Anti-Kick: {(ProtectionFeatures.antiKickEnabled ? "ON" : "OFF")}", GUILayout.Height(30)))
        {
            ProtectionFeatures.ToggleAntiKick();
        }
        GUI.backgroundColor = Color.white;
        
        GUILayout.Space(5);
        
        GUI.backgroundColor = ProtectionFeatures.antiBanEnabled ? Color.green : Color.red;
        if (GUILayout.Button($"Anti-Ban: {(ProtectionFeatures.antiBanEnabled ? "ON" : "OFF")}", GUILayout.Height(30)))
        {
            ProtectionFeatures.ToggleAntiBan();
        }
        GUI.backgroundColor = Color.white;
        
        GUILayout.Space(5);
        
        GUI.backgroundColor = ProtectionFeatures.disconnectProtection ? Color.green : Color.red;
        if (GUILayout.Button($"No Penalty DC: {(ProtectionFeatures.disconnectProtection ? "ON" : "OFF")}", GUILayout.Height(30)))
        {
            ProtectionFeatures.ToggleDisconnectProtection();
        }
        GUI.backgroundColor = Color.white;
        
        GUILayout.Space(5);
        
        GUI.backgroundColor = ProtectionFeatures.antiVoteEnabled ? Color.green : Color.red;
        if (GUILayout.Button($"Anti-Vote: {(ProtectionFeatures.antiVoteEnabled ? "ON" : "OFF")}", GUILayout.Height(30)))
        {
            ProtectionFeatures.ToggleAntiVote();
        }
        GUI.backgroundColor = Color.white;
        
        GUILayout.Space(5);
        
        GUI.backgroundColor = ProtectionFeatures.antiReport ? Color.green : Color.red;
        if (GUILayout.Button($"Anti-Report Body: {(ProtectionFeatures.antiReport ? "ON" : "OFF")}", GUILayout.Height(30)))
        {
            ProtectionFeatures.ToggleAntiReport();
        }
        GUI.backgroundColor = Color.white;
        
        GUILayout.Space(15);
        
        if (GUILayout.Button("Disconnect (No Penalty)", GUILayout.Height(30)))
        {
            ProtectionFeatures.DisconnectWithoutPenalty();
        }
        
        GUILayout.EndVertical();
    }
}
using UnityEngine;
using InnerNet;
using System.Linq;

namespace MalumMenu;

public class PlayerFeaturesTabV2 : ITab  // <-- Nombre cambiado
{
    public string name => "Players";
    private Vector2 scrollPosition;
    private PlayerControl selectedPlayer;
    private PlayerControl morphTarget;
    private int selectedPetIndex = 0;

    public void Draw()
    {
        GUILayout.BeginVertical();
        bool isHost = AmongUsClient.Instance.AmHost;
        GUILayout.Label($"Status: {(isHost ? "HOST" : "CLIENT")}");
        GUILayout.Space(10);

        GUILayout.Label("Select Player:", new GUIStyle(GUI.skin.label) { fontStyle = FontStyle.Bold });
        var players = PlayerControl.AllPlayerControls.ToArray().Where(p => p != null && !p.AmOwner).ToArray();
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(120));
        
        foreach (var player in players)
        {
            bool isSelected = selectedPlayer == player;
            GUI.backgroundColor = isSelected ? Color.green : Color.white;
            string status = player.Data?.IsDead ?? false ? "DEAD" : "ALIVE";
            if (GUILayout.Button($"{player.Data?.PlayerName} [{status}]")) selectedPlayer = player;
        }
        GUI.backgroundColor = Color.white;
        GUILayout.EndScrollView();
        GUILayout.Space(10);

        GUI.enabled = selectedPlayer != null;
        if (GUILayout.Button("Teleport to Player", GUILayout.Height(25))) PlayerFeatures.FollowPlayer(selectedPlayer);
        
        GUI.enabled = selectedPlayer != null && isHost && (selectedPlayer.Data?.IsDead ?? false);
        if (GUILayout.Button("Revive Player", GUILayout.Height(25))) PlayerFeatures.RevivePlayer(selectedPlayer);
        
        GUI.enabled = selectedPlayer != null;
        GUILayout.Space(10);

        GUILayout.Label("Pet Control:", new GUIStyle(GUI.skin.label) { fontStyle = FontStyle.Bold });
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("None", GUILayout.Width(60))) selectedPetIndex = 0;
        if (GUILayout.Button("Dog", GUILayout.Width(60))) selectedPetIndex = 1;
        if (GUILayout.Button("Cat", GUILayout.Width(60))) selectedPetIndex = 2;
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Bird", GUILayout.Width(60))) selectedPetIndex = 3;
        if (GUILayout.Button("Chick", GUILayout.Width(60))) selectedPetIndex = 4;
        if (GUILayout.Button("UFO", GUILayout.Width(60))) selectedPetIndex = 5;
        GUILayout.EndHorizontal();

        string[] petIds = { "", "pet_dog", "pet_cat", "pet_bird", "pet_chick", "pet_ufo", "pet_cube", "", "", "pet_robot", "pet_bedcrab" };
        if (GUILayout.Button("Set Pet", GUILayout.Height(25))) PlayerFeatures.ChangePlayerPet(selectedPlayer, petIds[selectedPetIndex]);
        if (GUILayout.Button("Remove Pet", GUILayout.Height(25))) PlayerFeatures.RemovePlayerPet(selectedPlayer);
        GUILayout.Space(10);

        GUILayout.Label("Morph:", new GUIStyle(GUI.skin.label) { fontStyle = FontStyle.Bold });
        if (GUILayout.Button("Copy Outfit", GUILayout.Height(25)))
        {
            morphTarget = selectedPlayer;
            PlayerFeatures.MorphInto(selectedPlayer);
        }
        GUI.enabled = true;
        if (morphTarget != null) GUILayout.Label($"Morphed as: {morphTarget.Data?.PlayerName}");
        GUILayout.EndVertical();
    }
}
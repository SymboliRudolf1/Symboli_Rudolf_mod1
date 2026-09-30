using UnityEngine;

namespace MalumMenu;

public class ESPTab : ITab
{
    public string name => "ESP";

    public void Draw()
    {
        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical(GUILayout.Width(MenuUI.windowWidth * 0.425f));

        DrawGeneral();

        GUILayout.Space(15);

        DrawCamera();

        GUILayout.EndVertical();

        GUILayout.BeginVertical();

        DrawTracers();

        GUILayout.Space(15);

        DrawMinimap();

        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
    }

    private void DrawGeneral()
    {
        CheatToggles.seePlayerInfo = GUILayout.Toggle(CheatToggles.seePlayerInfo, " Ver información del jugador");

        CheatToggles.seeRoles = GUILayout.Toggle(CheatToggles.seeRoles, " Ver roles");

        CheatToggles.seeGhosts = GUILayout.Toggle(CheatToggles.seeGhosts, " Ver fantasmas");

        CheatToggles.noShadows = GUILayout.Toggle(CheatToggles.noShadows, " Sin sombras");

        CheatToggles.taskArrows = GUILayout.Toggle(CheatToggles.taskArrows, " Flechas de tarea");

        CheatToggles.revealVotes = GUILayout.Toggle(CheatToggles.revealVotes, " Revelar votos");

        CheatToggles.seeLobbyInfo = GUILayout.Toggle(CheatToggles.seeLobbyInfo, " Ver información del Lobby");
    }

    private void DrawCamera()
    {
        GUILayout.Label("Camara", GUIStylePreset.TabSubtitle);

        CheatToggles.zoomOut = GUILayout.Toggle(CheatToggles.zoomOut, " Aleja la imagen");

        CheatToggles.spectate = GUILayout.Toggle(CheatToggles.spectate, " Espectador");

        CheatToggles.freecam = GUILayout.Toggle(CheatToggles.freecam, " Cámara Libre");
    }

    private void DrawTracers()
    {
        GUILayout.Label("Rastreadores", GUIStylePreset.TabSubtitle);

        CheatToggles.tracersCrew = GUILayout.Toggle(CheatToggles.tracersCrew, " Tripulantes");

        CheatToggles.tracersImps = GUILayout.Toggle(CheatToggles.tracersImps, " Impostores");

        CheatToggles.tracersGhosts = GUILayout.Toggle(CheatToggles.tracersGhosts, " Fantasmas");

        CheatToggles.tracersBodies = GUILayout.Toggle(CheatToggles.tracersBodies, " Cuerpos Muertos");

        CheatToggles.colorBasedTracers = GUILayout.Toggle(CheatToggles.colorBasedTracers, " Basado en el color");

        CheatToggles.distanceBasedTracers = GUILayout.Toggle(CheatToggles.distanceBasedTracers, " Basado en la distancia");
    }

    private void DrawMinimap()
    {
        GUILayout.Label("Mini Mapa", GUIStylePreset.TabSubtitle);

        CheatToggles.mapCrew = GUILayout.Toggle(CheatToggles.mapCrew, " Tripulantes");

        CheatToggles.mapImps = GUILayout.Toggle(CheatToggles.mapImps, " Impostores");

        CheatToggles.mapGhosts = GUILayout.Toggle(CheatToggles.mapGhosts, " Fantasma");

        CheatToggles.colorBasedMap = GUILayout.Toggle(CheatToggles.colorBasedMap, " Basado en el color");
    }
}

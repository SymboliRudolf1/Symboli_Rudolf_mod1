using UnityEngine;

namespace MalumMenu;

public class HostOnlyTab : ITab
{
    public string name => "Solo Host";

    public void Draw()
    {
        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical(GUILayout.Width(MenuUI.windowWidth * 0.425f));

        DrawGeneral();

        GUILayout.Space(15);

        DrawMurder();

        GUILayout.Space(15);

        DrawGameState();

        GUILayout.EndVertical();

        GUILayout.BeginVertical();

        DrawMeetings();

        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
    }

    private void DrawGeneral()
    {
        CheatToggles.killVanished = GUILayout.Toggle(CheatToggles.killVanished, " Matar mientras está desaparecido");

        CheatToggles.killAnyone = GUILayout.Toggle(CheatToggles.killAnyone, " Matar a cualquiera");

        CheatToggles.noKillCd = GUILayout.Toggle(CheatToggles.noKillCd, " Sin tiempo de espera para matar");

        CheatToggles.showProtectMenu = GUILayout.Toggle(CheatToggles.showProtectMenu, " Mostrar menú de protección");

        // CheatToggles.forceRole = GUILayout.Toggle(CheatToggles.forceRole, " Force Role");

        // CheatToggles.noOptionsLimits = GUILayout.Toggle(CheatToggles.noOptionsLimits, " No Options Limits");
    }

    private void DrawMurder()
    {
        GUILayout.Label("Asesinato", GUIStylePreset.TabSubtitle);

        CheatToggles.killPlayer = GUILayout.Toggle(CheatToggles.killPlayer, " Matar jugador");

        CheatToggles.telekillPlayer = GUILayout.Toggle(CheatToggles.telekillPlayer, " Teleport kill");

        CheatToggles.killAllCrew = GUILayout.Toggle(CheatToggles.killAllCrew, " Matar a todos los Tripulantes");

        CheatToggles.killAllImps = GUILayout.Toggle(CheatToggles.killAllImps, " Mata a todos los Impostores");

        CheatToggles.killAll = GUILayout.Toggle(CheatToggles.killAll, " Matar a todos");
    }

    private void DrawGameState()
    {
        GUILayout.Label("Estado de juego", GUIStylePreset.TabSubtitle);

        CheatToggles.forceStartGame = GUILayout.Toggle(CheatToggles.forceStartGame, " Forzar el inicio del juego");

        CheatToggles.noGameEnd = GUILayout.Toggle(CheatToggles.noGameEnd, " No hay final de juego");
    }

    private void DrawMeetings()
    {
        GUILayout.Label("Reuniones", GUIStylePreset.TabSubtitle);

        CheatToggles.skipMeeting = GUILayout.Toggle(CheatToggles.skipMeeting, " Saltarse la reunión");

        CheatToggles.voteImmune = GUILayout.Toggle(CheatToggles.voteImmune, " Voto Inmune");

        CheatToggles.ejectPlayer = GUILayout.Toggle(CheatToggles.ejectPlayer, " Expulsar jugador");
    }
}

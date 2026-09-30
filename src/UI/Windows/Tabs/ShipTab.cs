using UnityEngine;

namespace MalumMenu;

public class ShipTab : ITab
{
    public string name => "Nave";

    public void Draw()
    {
        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical(GUILayout.Width(MenuUI.windowWidth * 0.425f));

        DrawGeneral();

        GUILayout.Space(15);

        DrawSabotage();

        GUILayout.EndVertical();

        GUILayout.BeginVertical();

        DrawVents();

        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
    }

    private void DrawGeneral()
    {
        CheatToggles.unfixableLights = GUILayout.Toggle(CheatToggles.unfixableLights, " Luces irreparables");

        // CheatToggles.reportBody = GUILayout.Toggle(CheatToggles.reportBody, " Report Body");

        CheatToggles.callMeeting = GUILayout.Toggle(CheatToggles.callMeeting, " Llamar Reunión");

        CheatToggles.closeMeeting = GUILayout.Toggle(CheatToggles.closeMeeting, " Cerrar Reunión");

        CheatToggles.autoReportBodies = GUILayout.Toggle(CheatToggles.autoReportBodies, " Informe Automático de Cuerpos");

        CheatToggles.autoOpenDoorsOnUse = GUILayout.Toggle(CheatToggles.autoOpenDoorsOnUse, " Abrir puertas Automaticámente");
    }

    private void DrawSabotage()
    {
        GUILayout.Label("Sabotaje", GUIStylePreset.TabSubtitle);

        CheatToggles.reactorSab = GUILayout.Toggle(CheatToggles.reactorSab, " Reactor");

        CheatToggles.oxygenSab = GUILayout.Toggle(CheatToggles.oxygenSab, " Oxígeno");

        CheatToggles.elecSab = GUILayout.Toggle(CheatToggles.elecSab, " Luces");

        CheatToggles.commsSab = GUILayout.Toggle(CheatToggles.commsSab, " Comunicaciones");

        CheatToggles.showDoorsMenu = GUILayout.Toggle(CheatToggles.showDoorsMenu, " Mostrar Menú de puertas");

        CheatToggles.mushSab = GUILayout.Toggle(CheatToggles.mushSab, " Mezcla de Setas");

        CheatToggles.mushSpore = GUILayout.Toggle(CheatToggles.mushSpore, " Esporas Desencadenantes");

        CheatToggles.sabotageMap = GUILayout.Toggle(CheatToggles.sabotageMap, " Mapa de sabotaje abierto");
    }

    private void DrawVents()
    {
        GUILayout.Label("Alcantarilla", GUIStylePreset.TabSubtitle);

        CheatToggles.unlockVents = GUILayout.Toggle(CheatToggles.unlockVents, " Desbloquear Alcantarillas");

        CheatToggles.kickVents = GUILayout.Toggle(CheatToggles.kickVents, " Expulsa a todos de las Alcantarillas");

        CheatToggles.walkInVents = GUILayout.Toggle(CheatToggles.walkInVents, " Caminar en las Alcantarillas");
    }
}

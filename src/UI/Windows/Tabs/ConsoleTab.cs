using UnityEngine;

namespace MalumMenu;

public class ConsoleTab : ITab
{
    public string name => "Consola";

    public void Draw()
    {
        GUILayout.BeginVertical(GUILayout.Width(MenuUI.windowWidth * 0.425f));

        DrawGeneral();

        GUILayout.EndVertical();
    }

    private void DrawGeneral()
    {
        CheatToggles.showConsole = GUILayout.Toggle(CheatToggles.showConsole, " Mostrar consola");

        CheatToggles.logDeaths = GUILayout.Toggle(CheatToggles.logDeaths, " Registro de muertes");

        CheatToggles.logShapeshifts = GUILayout.Toggle(CheatToggles.logShapeshifts, " Registro de Cambiaformas");

        CheatToggles.logVents = GUILayout.Toggle(CheatToggles.logVents, " Registro de ductos de ventilación ");
    }
}

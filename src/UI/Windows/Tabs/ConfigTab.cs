using UnityEngine;

namespace MalumMenu;

public class ConfigTab : ITab
{
    public string name => "Configuracion";

    public void Draw()
    {
        GUILayout.BeginVertical(GUILayout.Width(MenuUI.windowWidth * 0.425f));

        DrawGeneral();

        GUILayout.EndVertical();
    }

    private void DrawGeneral()
    {
        CheatToggles.openConfig = GUILayout.Toggle(CheatToggles.openConfig, " Abrir Configuración");

        CheatToggles.reloadConfig = GUILayout.Toggle(CheatToggles.reloadConfig, " Recargar Configuracion");

        CheatToggles.saveProfile = GUILayout.Toggle(CheatToggles.saveProfile, " Guardar en el perfil");

        CheatToggles.loadProfile = GUILayout.Toggle(CheatToggles.loadProfile, " Cargar desde perfil");
    }
}

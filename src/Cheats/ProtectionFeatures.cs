using UnityEngine;
using InnerNet;

namespace MalumMenu;

public static class ProtectionFeatures
{
    public static bool antiKickEnabled = false;
    public static bool antiBanEnabled = false;
    public static bool disconnectProtection = false;
    public static bool antiVoteEnabled = false;
    public static bool antiReport = false;

    public static void ToggleAntiKick() => antiKickEnabled = !antiKickEnabled;
    public static void ToggleAntiBan() => antiBanEnabled = !antiBanEnabled;
    public static void ToggleDisconnectProtection() => disconnectProtection = !disconnectProtection;
    public static void ToggleAntiVote() => antiVoteEnabled = !antiVoteEnabled;
    public static void ToggleAntiReport() => antiReport = !antiReport;

    public static void DisconnectWithoutPenalty()
    {
        AmongUsClient.Instance.ExitGame(DisconnectReasons.Destroy);
    }

    // Eliminado ClearPenaltyHistory - StatsManager no existe en esta versión
}
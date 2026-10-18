using Unity.Netcode;
using UnityEngine;

public class NetworkStartUI : MonoBehaviour
{
    private void OnGUI()
    {
        // Tworzymy prosty obszar z przyciskami w lewym górnym rogu ekranu
        GUILayout.BeginArea(new Rect(20, 20, 250, 200));

        // Jeśli jeszcze nie połączyliśmy się jako Host ani Client, pokaż przyciski:
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            if (GUILayout.Button("Stwórz grę (HOST)", GUILayout.Height(50)))
            {
                NetworkManager.Singleton.StartHost();
            }

            if (GUILayout.Button("Dołącz do gry (CLIENT)", GUILayout.Height(50)))
            {
                NetworkManager.Singleton.StartClient();
            }
        }
        else
        {
            // Gdy już się połączymy, wyświetl kim jesteśmy:
            string rola = NetworkManager.Singleton.IsHost ? "HOST (Gracz 1)" : "CLIENT (Gracz 2)";
            GUILayout.Label("Połączono jako: " + rola);
        }

        GUILayout.EndArea();
    }
}
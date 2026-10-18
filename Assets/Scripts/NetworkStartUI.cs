using Unity.Netcode;
using UnityEngine;

public class NetworkStartUI : MonoBehaviour
{
    private void OnGUI()
    {
        // Zabezpieczenie przed błędem NullReferenceException z konsoli:
        if (NetworkManager.Singleton == null) return;

        GUILayout.BeginArea(new Rect(20, 20, 250, 200));

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
            string rola = NetworkManager.Singleton.IsHost ? "HOST (Gracz 1)" : "CLIENT (Gracz 2)";
            GUILayout.Label("Połączono jako: " + rola);
        }

        GUILayout.EndArea();
    }
}
using Fusion;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private Transform ViewportContent;
    [SerializeField] private GameObject lobbyPrefab;

    void Start()
    {
        PhotonManager._PhotonManager.onSessionListUpdated += UpdateSessionCanvas;
        PhotonManager._PhotonManager.onSessionListUpdated += DestroyCanvasContent;
    }

    public void UpdateSessionCanvas()
    {
        DestroyCanvasContent();

        foreach (SessionInfo session in PhotonManager._PhotonManager.availableSessions)
        {
            GameObject sessionInstance = Instantiate(lobbyPrefab, ViewportContent);
            sessionInstance.GetComponent<SessionEntry>().SetInfo(session);
        }

        for (int i = 0; i < PhotonManager._PhotonManager.availableSessions.Count; i++)
        {
            GameObject sessionInstance = Instantiate(lobbyPrefab, ViewportContent);
            sessionInstance.GetComponent<SessionEntry>().SetInfo(PhotonManager._PhotonManager.availableSessions[i]);
        }
    }

    public void DestroyCanvasContent()
    {
        foreach (Transform child in ViewportContent)
        {
            Destroy(child.gameObject);
        }
    }
}

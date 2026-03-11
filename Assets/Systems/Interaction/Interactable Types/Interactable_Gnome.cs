using UnityEngine;

public class Interactable_Gnome : MonoBehaviour, IInteractable
{
    [Header("Message")]
    [SerializeField] private string message;

    private UIManager uiManager;

    private void Awake()
    {
        uiManager = ServiceHub.Instance.UIManager;

        if (uiManager == null) Debug.Log("UIManager not found in ServiceHub");
    }

    public void Focused()
    {
    }

    public void Interact()
    {
        uiManager.TalkToGnome(message);
    }

    public void UnFocused()
    {
    }
}

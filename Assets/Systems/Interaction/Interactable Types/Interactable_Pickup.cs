using UnityEngine;

public class Interactable_Pickup : MonoBehaviour, IInteractable
{
    public bool debugEnabled = false;

    public void Interact()
    {
        if (debugEnabled) Debug.Log("Interacted with " + gameObject.name);

        Destroy(gameObject);
    }

    public void Focused()
    {
    }

    public void UnFocused()
    {
    }
}

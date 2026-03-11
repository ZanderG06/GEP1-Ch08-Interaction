using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] bool debugEnabled = false;

    [Header("Interact Message")]
    [SerializeField] float messageDuration = 3.0f;
    [SerializeField] float fadeOutTime = .5f;
    float elapsedTime = 0f;

    [SerializeField] private TMP_Text messageText;

    private Coroutine fadeCoroutine;

    public void DisplayMessage(string message)
    {
        if(fadeCoroutine != null) StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(DisplayMessageAndFade(message));
    }

    private IEnumerator DisplayMessageAndFade(string message)
    {
        messageText.text = message;
        messageText.alpha = 1;

        yield return new WaitForSeconds(messageDuration);

        Color OriginalColor = messageText.color;

        while(elapsedTime < messageDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutTime);
            
            messageText.alpha = alpha;
            
            yield return null;
        }
        messageText.text = "";
    }

    public void DisplayPrompt()
    {
        messageText.alpha = 1;
        messageText.text = "Interact [Spacebar]";
    }

    public void HidePrompt()
    {
        messageText.text = "";
    }
}

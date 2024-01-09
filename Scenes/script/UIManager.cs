using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text interactionText;

    void Awake()
    {
        Instance = this;
    }

    public void DisplayInteractionMessage(string message)
    {
        // Combine the new message with the existing message
        string combinedMessage = message + "\nhello, I am stambata";

        interactionText.text = combinedMessage;
        interactionText.gameObject.SetActive(true);
    }

    public void HideInteractionMessage()
    {
        interactionText.gameObject.SetActive(false);
    }
}

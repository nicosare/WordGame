using UnityEngine;
using UnityEngine.UI;

public class DialogueWindow : MonoBehaviour
{
    private void Awake() => CloseWindow();

    public void CloseWindow() => gameObject.SetActive(false);

    public void OpenWindowWithMessage(string message)
    {
        gameObject.SetActive(true);
        transform.GetComponentInChildren<Text>().text = message;
    }
}
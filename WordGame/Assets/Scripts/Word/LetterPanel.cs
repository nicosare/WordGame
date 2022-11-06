using UnityEngine;
using UnityEngine.UI;

public class LetterPanel : MonoBehaviour
{
    [SerializeField] private GameObject closingPanel;

    public char Letter { get; set; }

    private void Start() => transform.GetComponentInChildren<Text>().text = Letter.ToString();

    public void OpenLetter() => closingPanel.SetActive(false);
}
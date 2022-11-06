using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterPanel : MonoBehaviour
{
    public char Letter { get; set; }
    [SerializeField] private GameObject closingPanel;
    
    private void Start()
    {
        transform.GetComponentInChildren<Text>().text = Letter.ToString();
    }

    public void OpenLetter()
    {
        closingPanel.SetActive(false);
    }
}

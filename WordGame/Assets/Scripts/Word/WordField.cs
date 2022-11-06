using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordField : MonoBehaviour
{
    [SerializeField] private Transform letterPanel;
    private List<LetterPanel> letterPanels;
    public void LoadWordToGame(string newWord)
    {
        letterPanels = new List<LetterPanel>();
        foreach (var letter in newWord)
        {
            var newLetterPanel = Instantiate(letterPanel, transform);
            newLetterPanel.GetComponent<LetterPanel>().Letter = letter;
            letterPanels.Add(newLetterPanel.GetComponent<LetterPanel>());
        }
    }

    public void OpenLetter(int index)
    {
        letterPanels[index].OpenLetter();
    }

    public void ClearField()
    {
        letterPanels.Clear();
        for (var i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
    }
}

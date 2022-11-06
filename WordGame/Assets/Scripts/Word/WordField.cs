using System.Collections.Generic;
using UnityEngine;

public class WordField : MonoBehaviour
{
    [SerializeField] private Transform letterPanel;

    private List<LetterPanel> letterPanels;
    private string wordInGame;

    public void LoadWordToGame(string newWord)
    {
        wordInGame = newWord;
        letterPanels = new List<LetterPanel>();

        foreach (var letter in newWord)
        {
            var newLetterPanel = Instantiate(letterPanel, transform);
            newLetterPanel.GetComponent<LetterPanel>().Letter = letter;
            letterPanels.Add(newLetterPanel.GetComponent<LetterPanel>());
        }
    }

    public void ClearField()
    {
        letterPanels.Clear();

        for (var i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
    }

    public void OpenAllLetters(char inputLetter)
    {
        for (var index = 0; index < wordInGame.Length; index++)
            if (wordInGame[index] == inputLetter)
                OpenLetter(index);
    }

    public void OpenLetter(int index) => letterPanels[index].OpenLetter();
}
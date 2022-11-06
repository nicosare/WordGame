using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

public class Game : MonoBehaviour
{
    public static Game Instance;

    [SerializeField] private TextAsset text;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private WordField wordField;
    [SerializeField] private Keyboard keyboard;

    public string WordForGame { get; private set; }
    private List<string> wordsForGame;
    private bool isFirstPlay;

    private void Awake()
    {
        isFirstPlay = true;
        wordsForGame = text.GetWordsWithLengthNotLessThan(gameSettings.MinimalWordLength);
        Instance = this;
        PlayNextWord();
    }

    public string GetWordForGame()
    {
        if (wordsForGame.Count > 0)
        {
            return wordsForGame.SelectNextRandom();
        }
        else throw new Exception("");
    }

    public void CheckLetter(char inputLetter)
    {
        var regex = new Regex(inputLetter.ToString());

        for (var index = 0; index < WordForGame.Length; index++)
        {
            if (WordForGame[index] == inputLetter)
            {
                WordForGame = regex.Replace(WordForGame, " ", 1);
                wordField.OpenLetter(index);
            }
        }
        keyboard.CloseKey(inputLetter);
        
        if (WordForGame.Trim() == String.Empty)
        {
            PlayNextWord();
        }
    }

    public void PlayNextWord()
    {
        if (!isFirstPlay)
        {
            wordField.ClearField();
            keyboard.ClearKeyboard();
        }
        WordForGame = GetWordForGame();
        wordField.LoadWordToGame(WordForGame);
        isFirstPlay = false;
    }
}

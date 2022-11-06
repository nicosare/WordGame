using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Game : MonoBehaviour
{
    public static Game Instance;

    [SerializeField] private TextAsset text;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private WordField wordField;
    [SerializeField] private Keyboard keyboard;
    [SerializeField] private Score score;
    [SerializeField] private Attempts attempts;
    [SerializeField] private DialogueWindow dialogueWindow;

    public string WordForGame { get; private set; }
    private List<string> wordsForGame;
    private bool isFirstPlay;

    private void Awake()
    {
        Instance = this;
        isFirstPlay = true;
        wordsForGame = text.GetWordNotLessThan(gameSettings.MinimalWordLength);
        score.ResetScore();
        PlayNextWord();
    }

    public void CheckLetter(char inputLetter)
    {
        var regex = new Regex(inputLetter.ToString());

        if (WordForGame.Contains(inputLetter))
        {
            WordForGame = regex.Replace(WordForGame, " ");
            wordField.OpenAllLetters(inputLetter);
        }
        else attempts.DecreaseByOne();

        keyboard.CloseKey(inputLetter);
        CheckEnd();
    }

    private void CheckEnd()
    {
        if (WordForGame.Trim() == string.Empty)
        {
            if (wordsForGame.Count > 0)
                PlayNextWord();
            else
                Win();
        }

        if (attempts.Amount <= 0)
        {
            Lose();
        }
    }

    private void PlayNextWord()
    {
        CheckFirstPlay();
        WordForGame = wordsForGame.SelectNextRandom();
        wordField.LoadWordToGame(WordForGame);
        attempts.ResetAmount();
    }

    private void CheckFirstPlay()
    {
        if (!isFirstPlay)
        {
            wordField.ClearField();
            keyboard.ClearKeyboard();
            score.AddPoints(attempts.Amount);
        }
        isFirstPlay = false;
    }

    public void Win() => dialogueWindow.OpenWindowWithMessage("YOU WIN!");

    public void Lose() => dialogueWindow.OpenWindowWithMessage("YOU LOSE!");

}
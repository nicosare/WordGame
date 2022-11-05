using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private TextAsset text;
    [SerializeField] private GameSettings gameSettings;

    private void Awake()
    {
        var wordsForGame = text.GetWordsWithLengthNotLessThan(gameSettings.MinimalWordLength);
        foreach (var word in wordsForGame)
        {
            Debug.Log(word);
        }
    }
}

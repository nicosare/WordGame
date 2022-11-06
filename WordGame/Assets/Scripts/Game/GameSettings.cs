using UnityEngine;

[CreateAssetMenu(menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private int minimalWordLength;
    [SerializeField] private int attemptsAmount;

    public int MinimalWordLength => minimalWordLength;
    public int AttemptsAmount => attemptsAmount;
}
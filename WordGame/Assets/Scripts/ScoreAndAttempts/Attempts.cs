using UnityEngine;
using UnityEngine.UI;

public class Attempts : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;

    public int Amount { get; private set; }

    private void Awake() => Amount = gameSettings.AttemptsAmount;

    private void Update() => transform.GetComponent<Text>().text = "Attempts left: " + Amount.ToString();

    public void DecreaseByOne() => Amount -= 1;

    public void ResetAmount() => Amount = gameSettings.AttemptsAmount;
}
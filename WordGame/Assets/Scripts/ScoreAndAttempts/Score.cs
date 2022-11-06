using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int Points { get; private set; }

    private void Update() => transform.GetComponent<Text>().text = "Score: " + Points.ToString();

    public void AddPoints(int addedPoints) => Points += addedPoints;

    public void ResetScore() => Points = 0;
}
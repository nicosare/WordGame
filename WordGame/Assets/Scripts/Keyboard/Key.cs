using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public char Letter { get; set; }

    private void Start()
    {
        transform.GetComponentInChildren<Text>().text = Letter.ToString();
    }

    public void PressLetter()
    {
        Game.Instance.CheckLetter(Letter);
    }

}

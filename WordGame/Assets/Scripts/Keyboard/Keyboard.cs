using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [SerializeField] private Key[] keys;

    private readonly char[] alphabet = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();

    private void Awake()
    {
        for (var keyIndex = 0; keyIndex < keys.Length; keyIndex++)
            keys[keyIndex].Letter = alphabet[keyIndex];
    }

    public void CloseKey(char letter)
    {
        foreach (var key in keys)
            if (key.Letter == letter)
                key.gameObject.SetActive(false);
    }

    public void ClearKeyboard()
    {
        foreach (var key in keys)
            key.gameObject.SetActive(true);
    }
}
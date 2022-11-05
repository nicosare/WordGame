using UnityEngine;
using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class TextAssetExtension
{
    public static string[] GetWordsWithLengthNotLessThan(this TextAsset text, int minimalWordLength)
    {
        var txt = text.text;
        var regex = new Regex("[^a-zA-Z]");
        txt = regex.Replace(txt, " ");
        var words = txt.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        words = words.Select(word => word.ToLower())
                     .Distinct()
                     .Where(word => word != "the")
                     .Where(word => word.Length >= minimalWordLength)
                     .ToArray();
        return words;
    }
}

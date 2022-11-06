using UnityEngine;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public static class TextAssetExtension
{
    public static List<string> GetWordNotLessThan(this TextAsset text, int minimalWordLength)
    {
        var txt = text.text;
        var regex = new Regex("[^a-zA-Z]");
        txt = regex.Replace(txt, " ");
        var words = txt.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                       .ToList();
        words = words.Select(word => word.ToLower())
                     .Distinct()
                     .Where(word => word.Length >= minimalWordLength)
                     .ToList();
        return words;
    }
}
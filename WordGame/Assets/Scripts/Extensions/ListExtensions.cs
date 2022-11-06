using System.Collections.Generic;

public static class ListExtensions
{
    public static T SelectNextRandom<T>(this List<T> list)
    {
        if (list.Count > 0)
        {
            var randomIndex = UnityEngine.Random.Range(0, list.Count);
            var randomElement = list[randomIndex];
            list.RemoveAt(randomIndex);
            return randomElement;
        }
        else return default;
    }
}
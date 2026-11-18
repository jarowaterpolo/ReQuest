using UnityEngine;

public class Calculator
{
    public static string RollRarity()
    {
        int legendaryChance = 2; int epicChance = 5; int rareChance = 10; int uncommonChance = 25;

        var randomNum = Random.Range(0, 100);

        if (randomNum < legendaryChance)
        {
            return "Legendary"; //2,0%
        }
        else
        {
            randomNum = Random.Range(0, 100);
            if (randomNum < epicChance)
            {
                return "Epic"; //4,9%
            }
            else
            {
                randomNum = Random.Range(0, 100);
                if (randomNum < rareChance)
                {
                    return "Rare"; //9,31%
                }
                else
                {
                    randomNum = Random.Range(0, 100);
                    if (randomNum < uncommonChance)
                    {
                        return "Uncommon"; //20,95% 
                    }
                    else
                    {
                        return "Common"; //62,84%
                    }
                }
            }
        }
    }
}

using System;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

[CreateAssetMenu(fileName = "Quest", menuName = "Scriptable Objects/Quest")]
public class Quest : ScriptableObject
{
    [SerializeField]
    private string questName;
    public string QuestName => questName;
    [SerializeField]
    private ResourceRewardPile[] resourceRewardPiles;
    public ResourceRewardPile[] ResourceRewardPiles => resourceRewardPiles;

    [SerializeField]
    private float dieChance;
    public float DieChance => dieChance;

    [SerializeField]
    private float questDuration;
    public float QuestDuration => questDuration;
    [SerializeField]
    private RarityChances rarityChances;

    public void GetReward()
    {
        var rarity = Calculator.RollRarity(rarityChances.legendaryChance, rarityChances.epicChance, rarityChances.rareChance, rarityChances.uncommonChance);
        foreach (var pile in resourceRewardPiles) {
            if (pile.name == rarity)
            {
                var randomNum = UnityEngine.Random.Range(0, pile.rewards.Length);
                pile.rewards[randomNum].resource.value += pile.rewards[randomNum].amount;
                //var resourceStr = pile.rewards[randomNum].resource.ToString().Replace(" (Resource)", "");
                //Debug.Log($"you got {pile.rewards[randomNum].amount} {resourceStr}");
            }
        }
    }
}

[Serializable]
public class RarityChances
{
    public int legendaryChance;
    public int epicChance;
    public int rareChance;
    public int uncommonChance;
}
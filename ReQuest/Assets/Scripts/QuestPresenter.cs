using TMPro;
using UnityEngine;

public class QuestPresenter : MonoBehaviour
{
    [SerializeField]
    private Quest quest;
    [SerializeField]
    private TMP_Text nameText;
    [SerializeField]
    private TMP_Text dieChanceText;
    [SerializeField]
    private TMP_Text rewardText;

    void SetText()
    {
        nameText.text = quest.QuestName;
        dieChanceText.text = quest.DieChance.ToString();
        string rewards = "";
        foreach (var resourcePile in quest.ResourceRewardPiles)
        {
            foreach (var reward in resourcePile.rewards)
            {
                var resourceStr = reward.resource.ToString().Replace(" (Resource)", "");
                rewards += $"{resourceStr} x{reward.amount} \n";
            }
        }
        rewardText.text = rewards;
    }
    private void OnEnable()
    {
        SetText();
    }
}

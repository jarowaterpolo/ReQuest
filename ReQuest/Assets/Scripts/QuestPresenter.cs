using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

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
            //rewards += $"{resourcePile.name}: \n";
            foreach (var reward in resourcePile.rewards)
            {
                var resourceStr = reward.resource.ToString().Replace(" (Resource)", "");
                rewards += $"{resourceStr} x{reward.amount}, ";
            }

            //Debug.Log($"reward text = {rewards}");
            rewards = rewards.Remove(rewards.Length - 2, 2);
            //Debug.Log($"reward after remove text = {rewards}");
            rewards += "\n";
        }
        rewardText.text = rewards;
    }
    private void OnEnable()
    {
        SetText();
    }
}

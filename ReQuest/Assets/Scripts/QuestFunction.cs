using System.Collections;
using UnityEngine;

public class QuestFunction : MonoBehaviour
{
    [SerializeField]
    private Quest quests;
    [SerializeField]
    private Resource adventurers;

    public void ActivateQuest()
    {
        StartCoroutine(RunQuest());
        Debug.Log("start quest");
    }

    private IEnumerator RunQuest()
    {
        quests.GetReward();

        yield return new WaitForSeconds(quests.QuestDuration);

        var randomNum = Random.Range(0, 100);
        if (randomNum >= quests.DieChance)
        {
            adventurers.value++;
        }
        Debug.Log("quest done");
    }
}

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
        if (adventurers.value > 0)
        {
            adventurers.value--;
            StartCoroutine(RunQuest());
            //Debug.Log("start quest");
        }
    }

    private IEnumerator RunQuest()
    {
        Debug.Log($"an adventurer started the {quests.QuestName} and will be busy with it for {quests.QuestDuration} seconds");
        yield return new WaitForSeconds(quests.QuestDuration);

        var randomNum = Random.Range(0, 100);
        if (randomNum >= quests.DieChance)
        {
            adventurers.value++;
        }
        quests.GetReward();
        //Debug.Log("quest done");
    }
}

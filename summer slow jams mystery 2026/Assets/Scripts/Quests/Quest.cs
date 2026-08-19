using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    public List<Goal> goals {get; set;} = new List<Goal>();
    public string QuestName {get; set;}
    public string QuestDescription {get; set;}
    public string WordReward {get; set;}
    public bool IsCompleted {get; set;} 

    public void CheckGoals()
    {
        IsCompleted = goals.All(goal => goal.IsCompleted);
    }

    public void GiveWordReward()
    {
        if (WordReward != null)
        {
            InventoryController.Instance.AddWordToInventory(WordReward);
            Debug.Log("Word reward given: " + WordReward);
        }
    }
}

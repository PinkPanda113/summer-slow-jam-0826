using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    public List<Goal> goals {get; set;} = new List<Goal>();
    public string questName {get; set;}
    public string questDescription {get; set;}
    public string wordReward {get; set;}
    public bool isCompleted {get; set;} 

    public void CheckGoals()
    {
        isCompleted = goals.All(goal => goal.isCompleted);
        if (isCompleted)
        {
            Debug.Log("Quest completed: " + questName);
            GiveWordReward();
        }
    }

    void GiveWordReward()
    {
        if (wordReward != null)
        {
            InventoryController.Instance.AddWordToInventory(wordReward);
            Debug.Log("Word reward given: " + wordReward);
        }
    }
}

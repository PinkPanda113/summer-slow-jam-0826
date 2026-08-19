using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; } 
    public bool QuestCompleted { get; set; }
    [SerializeField] private GameObject Quests;
    [SerializeField] private Quest quest; //?
    [SerializeField] private string questType;
    public Quest Quest { get; set; }

    public override void Interact()
    {
        // Here you can add logic to start a quest or show quest details
        Debug.Log("QuestGiver " + npcName + " is giving a quest.");
        if (!AssignedQuest && !QuestCompleted)
        {
            base.Interact();
            AssignQuest();
            Debug.Log("Quest assigned to player.");
        }
        else if (AssignedQuest && !QuestCompleted)
        {
            CheckQuest();
            Debug.Log("Player is currently on the quest.");
        }
        else if (AssignedQuest && QuestCompleted)
        {
            // // DialogSystem.Instance.AddNewDialogue(new string[]{"Thanks for help"}, name);
            Debug.Log("Player has completed the quest.");
        }
    }

    void AssignQuest()
    {
        // Logic to assign the quest to the player
        AssignedQuest = true;
        //Quest = (Quest)Quests.AddComponent(System.Type.GetType(questType)); // Assuming Quest is a MonoBehaviour, otherwise adjust accordingly
        //Quest = (Quest)Quests.Set(playerInteract);
        
    }

    void CheckQuest()
    {
        if (quest.IsCompleted)
        {
            Quest.GiveWordReward();
            QuestCompleted = true;
            AssignedQuest = false;
            Debug.Log("Quest complited?");
            // DialogSystem.Instance.AddNewDialogue(new string[]{"Thanks for that! Here's the words!", "More dialogue"}, name);
        }
        else
        {
            Debug.Log("You did not complited the quest");
            // DialogSystem.Instance.AddNewDialogue(new string[]{"Do you have the book? I'm still waiting!", "Go find it"}, name);
        }
    }
}

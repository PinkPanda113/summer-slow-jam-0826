using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; } 
    public bool QuestCompleted { get; set; }
    public QuestState state { get; set; }
    [SerializeField] private GameObject Quests;
    [SerializeField] private Quest quest; //?
    [SerializeField] private string questType;
    bool waitingForQuestDialogue;
    //public Quest Quest { get; set; }

    public override void Interact()
    {
        if (waitingForQuestDialogue)
        {
            return;
        }

        switch (state)
        {
            case QuestState.NotAssigned:
            waitingForQuestDialogue = true;
            DialogueSystem.Instance.DialogueFinished += AssignQuestAfterDialogue;
            base.Interact();
            break;
            case QuestState.Assigned:
            Debug.Log("Player is currently on the quest.");
            CheckQuest();
            break;
            case QuestState.Completed:
            // DialogSystem.Instance.AddNewDialogue(new string[]{"Thanks for help"}, name);
            Debug.Log("Player has completed the quest.");
            break;
        }
        
        /*
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
            Debug.Log("Player is currently on the quest." + "Is? :" + QuestCompleted + AssignedQuest);
            CheckQuest();
        }
        else if (!AssignedQuest && QuestCompleted)
        {
            // // DialogSystem.Instance.AddNewDialogue(new string[]{"Thanks for help"}, name);
            Debug.Log("Player has completed the quest.");
        }
        */
    }

    void AssignQuest()
    {
        state = QuestState.Assigned;
        AssignedQuest = true;
        if (quest != null)
        {
            quest.Activate();
        }
        Debug.Log("Quest assigned to player.");
    }

    void AssignQuestAfterDialogue()
    {
        if (!waitingForQuestDialogue)
        {
            return;
        }

        waitingForQuestDialogue = false;
        DialogueSystem.Instance.DialogueFinished -= AssignQuestAfterDialogue;
        AssignQuest();
    }

    void OnDestroy()
    {
        if (DialogueSystem.Instance != null)
        {
            DialogueSystem.Instance.DialogueFinished -= AssignQuestAfterDialogue;
        }
    }

    void CheckQuest()
    {
        if (quest == null)
        {
            Debug.LogError("QuestGiver: No quest is assigned in the Inspector.");
            return;
        }

        if (quest.IsCompleted)
        {
            quest.GiveWordReward();
            state = QuestState.Completed;
            // QuestCompleted = true;
            // AssignedQuest = false;
            Debug.Log("Quest completed!");
            // DialogSystem.Instance.AddNewDialogue(new string[]{"Thanks for that! Here's the words!", "More dialogue"}, name);
        }
        else
        {
            Debug.Log("You did not complited the quest");
            // DialogSystem.Instance.AddNewDialogue(new string[]{"Do you have the book? I'm still waiting!", "Go find it"}, name);
        }
    }
}

public enum QuestState
{
    NotAssigned,
    Assigned,
    Completed
}

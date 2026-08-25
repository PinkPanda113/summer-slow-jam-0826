using UnityEngine;

public class ProfessorQuest : Quest
{
    [SerializeField] private PlayerInteract playerInteract;

    public void SetPlayerInteract(PlayerInteract playerInteract)
    {
        this.playerInteract = playerInteract;

        Debug.Log("Librarian Quet received playerInteract: " + playerInteract);
    }


    void Start()
    {
        Debug.Log("Plyer Interact" + playerInteract);

        QuestName = "Professor's Quest";
        QuestDescription = "Professor Thaddeus Vane can help you, but he is old. Bring him potion to refresh memmory";
        WordReward = "Astra Revelio";

        Debug.Log("Professor's Quest playerInteract= "+ playerInteract);
        Debug.Log("Is null?" + (playerInteract == null));

    }

    public override void Activate()
    {
        if (goals.Count > 0)
        {
            return;
        }

        goals.Add(new CollectPotionGoal(this, playerInteract, 3, "Collect this potion", false, false));
        goals.ForEach(goal => goal.Initialize());
    }
}

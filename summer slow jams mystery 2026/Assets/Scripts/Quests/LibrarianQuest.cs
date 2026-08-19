using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LibrarianQuest : Quest
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

        QuestName = "Librarian's Quest";
        QuestDescription = "The librarian has asked you to retrieve a rare book from the old library. Find the book and return it to her.";
        WordReward = "Ianua Aperta";

        Debug.Log("Librarian's Quest playerInteract= "+ playerInteract);
        Debug.Log("Is null?" + (playerInteract == null));

        goals.Add(new CollectBookGoal(this, playerInteract, 0, "Collect this book", false, false));
        //goals.Add(new CollectBookGoal(this, playerInteract, 1, "Collect this book", false, false));

        goals.ForEach(goal => goal.Initialize());
        
    }

}

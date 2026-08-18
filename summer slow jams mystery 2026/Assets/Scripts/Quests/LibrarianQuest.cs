using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LibrarianQuest : Quest
{
    void Start()
    {
        QuestName = "Librarian's Request";
        QuestDescription = "The librarian has asked you to retrieve a rare book from the old library. Find the book and return it to her.";
        WordReward = "Ianua Aperta";

        goals.Add(new CollectBookGoal(this,0, "Collect this book", false, false));
        goals.Add(new CollectBookGoal(this,1, "Collect this book", false, false));

        goals.ForEach(goal => goal.Initialize());
        
    }

}

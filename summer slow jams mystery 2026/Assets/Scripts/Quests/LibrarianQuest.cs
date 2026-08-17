using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LibrarianQuest : Quest
{
    void Start()
    {
        questName = "Librarian's Request";
        questDescription = "The librarian has asked you to retrieve a rare book from the old library. Find the book and return it to her.";
        wordReward = "Ianua Aperta";

        goals.Add(new CollectBookGoal(0, "Collect this book", false, false));
        goals.Add(new CollectBookGoal(1, "Collect this book", false, false));

        goals.ForEach(goal => goal.Initialize());
        
    }

}

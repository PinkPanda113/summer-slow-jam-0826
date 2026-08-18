using UnityEngine;

public class CollectBookGoal : Goal
{
    [SerializeField] private PlayerInteract playerInteract; // Reference to the PlayerInteract script
    public int BookId { get; set; } // The ID of the book to collect

    public CollectBookGoal(Quest Quest,int BookId, string Description, bool IsCompleted = false, bool HasInteracted = false)
    {
        this.Quest = Quest;
        this.BookId = BookId;
        this.Description = Description;
        this.IsCompleted = IsCompleted;
        this.HasInteracted = HasInteracted;
    }

    public override void Initialize()
    {
        base.Initialize();
        playerInteract.OnInteraction += Bookcollected; // Subscribe to the OnInteraction event
    }

    void Bookcollected(ObjectsInteractable book)
    {
        if (book.id == this.BookId)
        {
            Evaluate();
            Debug.Log("Book collected: " + book.gameObject.name);
        }
    }

}

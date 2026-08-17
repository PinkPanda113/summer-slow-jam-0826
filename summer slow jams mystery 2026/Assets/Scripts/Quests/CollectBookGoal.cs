using UnityEngine;

public class CollectBookGoal : Goal
{
    [SerializeField] private PlayerInteract playerInteract; // Reference to the PlayerInteract script
    public int bookId { get; set; } // The ID of the book to collect

    public CollectBookGoal(int bookId, string description, bool isCompleted = false, bool hasInteracted = false)
    {
        this.bookId = bookId;
        this.description = description;
        this.isCompleted = isCompleted;
        this.hasInteracted = hasInteracted;
    }

    public override void Initialize()
    {
        base.Initialize();
        playerInteract.OnInteraction += Bookcollected; // Subscribe to the OnInteraction event
    }

    void Bookcollected(ObjectsInteractable book)
    {
        if (book.id == this.bookId)
        {
            Evaluate();
            Debug.Log("Book collected: " + book.gameObject.name);
        }
    }

}

using UnityEngine;

public class CollectBookGoal : Goal
{
    //[SerializeField] 
    private PlayerInteract playerInteract; // Reference to the PlayerInteract script
    public int BookId { get; set; } // The ID of the book to collect

    public CollectBookGoal(Quest Quest, PlayerInteract playerInteract, int BookId, string Description, bool IsCompleted, bool HasInteracted)
    {
        Debug.Log("Constractor received PlayerInteract = " + playerInteract);
        Debug.Log("Constructor null?" + (playerInteract == null));

        this.Quest = Quest;
        this.playerInteract = playerInteract;
        this.BookId = BookId;
        this.Description = Description;
        this.IsCompleted = IsCompleted;
        this.HasInteracted = HasInteracted;
    }

    public override void Initialize()
    {
        base.Initialize();
        if (playerInteract == null)
        {
            Debug.LogError("CollectBookGoal: playerInteract is null.");
            return;
        }
        playerInteract.OnInteraction += BookCollected; // Subscribe to the OnInteraction event
    }

    void BookCollected(ObjectsInteractable book)
    {
        Debug.Log("Received interaction wwith: " + book.name);
        Debug.Log("Book ID: " + book.id + "| Required ID: " + BookId);
        if (book.id == BookId)
        {
            HasInteracted = true;
            Evaluate();
            Debug.Log("Book collected: " + book.gameObject.name + IsCompleted + HasInteracted);
        }
    }

}

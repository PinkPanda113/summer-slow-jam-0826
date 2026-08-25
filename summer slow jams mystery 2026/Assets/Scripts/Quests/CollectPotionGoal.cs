using UnityEngine;

public class CollectPotionGoal : Goal
{
    //[SerializeField] 
    private PlayerInteract playerInteract; // Reference to the PlayerInteract script
    public int PotionId { get; set; } // The ID of the book to collect

    public CollectPotionGoal(Quest Quest, PlayerInteract playerInteract, int PotionId, string Description, bool IsCompleted, bool HasInteracted)
    {
        Debug.Log("Constractor received PlayerInteract = " + playerInteract);
        Debug.Log("Constructor null?" + (playerInteract == null));

        this.Quest = Quest;
        this.playerInteract = playerInteract;
        this.PotionId = PotionId;
        this.Description = Description;
        this.IsCompleted = IsCompleted;
        this.HasInteracted = HasInteracted;
    }

    public override void Initialize()
    {
        base.Initialize();
        if (playerInteract == null)
        {
            Debug.LogError("CollectPotionGoal: playerInteract is null.");
            return;
        }
        playerInteract.OnInteraction += PotionCollected; // Subscribe to the OnInteraction event
    }

    void PotionCollected(ObjectsInteractable potion)
    {
        Debug.Log("Received interaction with: " + potion.name);
        Debug.Log("Potion ID: " + potion.id + "| Required ID: " + PotionId);
        if (potion.id == PotionId)
        {
            HasInteracted = true;
            Evaluate();
            Debug.Log("Potion collected: " + potion.gameObject.name + IsCompleted + HasInteracted);
        }
    }
}

using UnityEngine;

public class Goal
{
    public Quest Quest { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public bool HasInteracted { get; set; }

    public virtual void Initialize()
    {
        this.Description = Description;
        IsCompleted = false;
        HasInteracted = false;
    }

    public void Evaluate()
    {
        if (HasInteracted == true)
        {
            Complete();
        }
    }

    public void Interact()
    {
        HasInteracted = true;
    }
    public void Complete()
    {
        
        IsCompleted = true;
        Quest.CheckGoals();
        Debug.Log("Goal completed: " + Description);
    }
}

using UnityEngine;

public class Goal
{
    public string description { get; set; }
    public bool isCompleted { get; set; }
    public bool hasInteracted { get; set; }

    public virtual void Initialize()
    {
        this.description = description;
        isCompleted = false;
        hasInteracted = false;
    }

    public void Evaluate()
    {
        if (hasInteracted == true)
        {
            Complete();
        }
    }

    public void Interact()
    {
        hasInteracted = true;
    }
    public void Complete()
    {
        isCompleted = true;
    }
}

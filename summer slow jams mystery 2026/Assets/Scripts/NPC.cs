using UnityEngine;

public class NPC : ObjectsInteractable
{
    public string[] dialogueLines;
    public string npcName;

    public override void Interact()
    {
        //DialogueSystem.Instance.AddNewDialogue(dialogueLines, npcName);
        Debug.Log("Interacting with NPC: " + npcName);
    }
}

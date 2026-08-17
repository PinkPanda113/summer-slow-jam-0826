using UnityEngine;

public class ObjectsInteractable : MonoBehaviour
{
    [SerializeField] private string interactText;
    [SerializeField] public int id; 
    public void Interact()
    {
        Debug.Log("Interacted with: " + gameObject.name);
    }

    public string GetInteractText()
    {
        return interactText;
    }
}

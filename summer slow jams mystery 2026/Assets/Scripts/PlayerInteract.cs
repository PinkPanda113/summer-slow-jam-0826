using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public event Action<ObjectsInteractable> OnInteraction;
   
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            ObjectsInteractable interactable1= GetInteractableObject();
            if (interactable1 != null)
            {
                interactable1.Interact();
                OnInteraction?.Invoke(interactable1);
            }
        }

    }

    public ObjectsInteractable GetInteractableObject()
    {
        List<ObjectsInteractable> interactableObjectsList = new List<ObjectsInteractable>();
        Vector3 interactRange = new Vector3(2f, 2f, 2f);
        Collider[] colliderArray = Physics.OverlapBox(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent (out ObjectsInteractable interactable))
            {
               interactableObjectsList.Add(interactable);
            }
        }
        ObjectsInteractable closestObject = null;
        foreach (ObjectsInteractable interactable in interactableObjectsList)
        {
            if (closestObject == null )
            {
                closestObject = interactable;
            }
            else
            {
                if (Vector3.Distance(transform.position, interactable.transform.position) < Vector3.Distance(transform.position, closestObject.transform.position))
                {
                    closestObject = interactable;
                }
            }
        }
        return closestObject;        
    }
}

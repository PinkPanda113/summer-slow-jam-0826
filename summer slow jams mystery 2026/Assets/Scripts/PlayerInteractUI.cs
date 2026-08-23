using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
   [SerializeField] private GameObject containerGameObject;
   [SerializeField] private PlayerInteract playerInteract;
   [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

   private void Update()
   {
      if (playerInteract == null || containerGameObject == null || interactTextMeshProUGUI == null)
      {
         return;
      }

      ObjectsInteractable interactable = playerInteract.GetInteractableObject();
      if (interactable != null)
      {
         ShowContainer(interactable);
      }
      else
      {
         HideContainer();
      }
   }

   private void ShowContainer(ObjectsInteractable objectsInteractable)
   {
      containerGameObject.SetActive(true);
      interactTextMeshProUGUI.text = objectsInteractable.GetInteractText();
   }
   private void HideContainer()
   {
      containerGameObject.SetActive(false);
   }
}

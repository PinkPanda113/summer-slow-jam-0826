using UnityEngine;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; private set; }
    private List<string> inventoryWords = new List<string>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddWordToInventory(string word)
    {
        if (!inventoryWords.Contains(word))
        {
            inventoryWords.Add(word);
            Debug.Log("Added word to inventory: " + word);
        }
    }

    public bool HasWordInInventory(string word)
    {
        return inventoryWords.Contains(word);
    }

    public void RemoveWordFromInventory(string word)
    {
        if (inventoryWords.Contains(word))
        {
            inventoryWords.Remove(word);
            Debug.Log("Removed word from inventory: " + word);
        }
    }

    public List<string> GetInventoryWords()
    {
        return new List<string>(inventoryWords);
    }
}

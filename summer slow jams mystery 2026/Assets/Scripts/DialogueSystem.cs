using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance {get; set;}
    public GameObject dialoguePanel;

    public List<string> dialogueLines = new List<string>();
    public string npcName;
    public event Action DialogueFinished;

    Button continueButton;
    TMP_Text dialogueText, nameText;
    int dialogueIndex;

    // void Awake()
    // {
    //     Debug.Log("Dialogue Panel reference: " + dialoguePanel);

    //     if (Instance != null && Instance != this)
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }

    //     Instance = this;

    //     continueButton = dialoguePanel.transform
    //         .Find("Continue")
    //         .GetComponent<Button>();

    //     dialogueText = dialoguePanel.transform
    //         .Find("Text")
    //         .GetComponent<Text>();

    //     nameText = dialoguePanel.transform
    //         .Find("NPCName/Text")
    //         .GetComponent<Text>();

    //     Debug.Log("Continue reference: " + continueButton);
    //     Debug.Log("Dialogue Text reference: " + dialogueText);
    //     Debug.Log("Name text reference: " + nameText);

    //     dialoguePanel.SetActive(false);

    //     continueButton.onClick.AddListener(ContinueDialogue);
    // }
    
    void Awake()
    {
        if (dialoguePanel == null)
        {
            Debug.LogError("DialogueSystem: Dialogue Panel is not assigned in the Inspector.");
            return;
        }

        Transform continueTransform = dialoguePanel.transform.Find("Continue");
        Transform textTransform = dialoguePanel.transform.Find("Text");
        Transform nameTransform = dialoguePanel.transform.Find("NPCName/Text");
        continueButton = continueTransform != null ? continueTransform.GetComponent<Button>() : null;
        dialogueText = textTransform != null ? textTransform.GetComponent<TMP_Text>() : null;
        nameText = nameTransform != null ? nameTransform.GetComponent<TMP_Text>() : null;

        if (continueButton == null || dialogueText == null || nameText == null)
        {
            Debug.LogError("DialogueSystem: Dialogue Panel must contain Button 'Continue' and TMP text objects 'Text' and 'NPCName/Text'.");
            return;
        }

        dialoguePanel.SetActive(false);

        continueButton.onClick.AddListener(delegate{ ContinueDialogue(); });

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewDialogue (string[] lines, string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        this.npcName = npcName;
        Debug.Log(dialogueLines.Count);
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        if (dialoguePanel == null || dialogueText == null || nameText == null)
        {
            Debug.LogError("DialogueSystem: Cannot create dialogue because the UI references are missing.");
            return;
        }

        if (dialogueLines == null || dialogueLines.Count == 0)
        {
            Debug.LogError("DialogueSystem: Cannot create dialogue because there are no dialogue lines.");
            return;
        }

        Debug.Log("Creating dialogue");
        Debug.Log("Lines count: " + dialogueLines.Count);
        Debug.Log("Dialogue text reference: " + dialogueText);
        Debug.Log("Name text reference: " + nameText);
        Debug.Log("NPC name: " + npcName);

        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];

        }
        else
        {
            dialoguePanel.SetActive(false);
            DialogueFinished?.Invoke();
        }
        
    }
}

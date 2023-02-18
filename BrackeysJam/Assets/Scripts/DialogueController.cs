using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueController : MonoBehaviour
{
   [Header("Dialogue management")]
   [SerializeField] private GameObject characterNameGO;
   [SerializeField] private GameObject textFieldGO;
   private TextMeshProUGUI characterName;
   private TextMeshProUGUI textField;
   [SerializeField] private Dialogue[] dialogue;
   private string[] dialogueLines;
   [SerializeField] private float dialogueSpeed;

   private int interactionCounter = 0;
   private int interactionCounterMax = 1;
   private int index;

   [Header("Others")] 
   [SerializeField] private GameEvent enablePlayerMovement;

   private void OnEnable()
   {
      characterName = characterNameGO.GetComponent<TextMeshProUGUI>();
      textField = textFieldGO.GetComponent<TextMeshProUGUI>();
      
      if(!characterName || !textField) {Debug.Log("Component problem in " + gameObject.name);
         return;
      }
      
      dialogueLines = dialogue[interactionCounter].lines;
      characterName.text = dialogue[interactionCounter].characterName;
      textField.text = string.Empty;
      
      StartDialogue();
   }

   private void Update()
   {
      if (Input.GetKeyUp(KeyCode.Space))
      {
         // When we press space and the line has already finished, we go to the next line.
         if (textField.text == dialogueLines[index])
         {
            NextLine();
         }
         // If it hasn't finish, we make it skip the char by char and write it all.
         else
         {
            StopAllCoroutines();
            textField.text = dialogueLines[index];
         }
      }
   }

   private void StartDialogue()
   {
      index = 0;
      StartCoroutine(TypeLine());
   }

   private void NextLine()
   {
      // If there still more lines to show, we add 1 to index so it reads next line. Else, we stop showing the dialogue box.
      if (index < dialogueLines.Length - 1)
      {
         index++;
         textField.text = string.Empty;
         StartCoroutine(TypeLine());
      }
      else
      {
         if(interactionCounter < interactionCounterMax) interactionCounter++;
         enablePlayerMovement.Raise();
         gameObject.SetActive(false);
      }
   }

   private IEnumerator TypeLine()
   {
      // Way of writing character by character.
      foreach (char c in dialogueLines[index].ToCharArray())
      {
         textField.text += c;
         yield return new WaitForSeconds(dialogueSpeed);
      }
   }
}

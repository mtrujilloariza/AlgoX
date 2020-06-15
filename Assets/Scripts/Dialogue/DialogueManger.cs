using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManger : MonoBehaviour
{
    private Queue<string> sentences = new Queue<string>();
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    public float typingSpeed;
    private bool typing;
    private string sentence;
    public float dialogueDelay;
    public float skipDelay;

    public void finishSentence(){
        StopAllCoroutines();
        StartCoroutine(skipTyping()); 
    }
    IEnumerator skipTyping(){
        dialogueText.text = sentence;
        yield return new WaitForSeconds(skipDelay);
        typing = false;
    }

    public void startDialogue(Dialogue dialogue) {

       animator.SetBool("IsOpen", true);

       sentences.Clear();

        nameText.text = dialogue.name;

       foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
            
       }

       displayNextSentence();
    }

    public void displayNextSentence() {
        if (sentences.Count == 0) {
            endDialogue();
            return;
        }

        sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence){
        typing = true;
        dialogueText.text = "";
        yield return new WaitForSeconds(dialogueDelay);
        foreach (char letter in sentence.ToCharArray()){
              dialogueText.text += letter;
              yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(skipDelay);
        typing = false;
    }

    public void endDialogue() {
        animator.SetBool("IsOpen", false);
    }

    public bool IsTyping(){
        return typing;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public float dialogueDelay; 
    public Dialogue dialogue; 


    void Start()
    {
        StartCoroutine(startDialogue());
    }
    void Update()
    {
        if (!(FindObjectOfType<DialogueManger>().IsTyping()) && Input.GetKeyDown("space")) {
            FindObjectOfType<DialogueManger>().displayNextSentence();
        } else if ((FindObjectOfType<DialogueManger>().IsTyping()) && Input.GetKeyDown("space")){
            FindObjectOfType<DialogueManger>().finishSentence();
        }
    }
    
    IEnumerator startDialogue() {
        yield return new WaitForSeconds(dialogueDelay);
        FindObjectOfType<DialogueManger>().startDialogue(dialogue);
    }



}

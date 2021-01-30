using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public float typingSpeed;
    public Animator animator;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogo dialogue)
    {
        animator.SetBool("isOpened", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentece in dialogue.sentences)
        {
            sentences.Enqueue(sentece);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence() { 
        if (sentences.Count == 0) //osea que alcanzamos el final de la cola
        {
            EndDialogo();
            return;
        }        
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogo()
    {
        animator.SetBool("isOpened", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Base on https://www.youtube.com/watch?v=_nRzoTzeyxU and https://www.youtube.com/watch?v=f-oSXg6_AMQ taking the Kendall Tencio implementation.
//Modified by Jorge Gutiérrez
public class DialogoManager : MonoBehaviour
{
    private int index;
    [Header("Text box objects")]
    public GameObject text_box_canvas; //to active true or false
    public Text name_Field_Obj;
    public Text dialogue_Field_Obj;
    public Image character_default_Image;
    public Button dialogue_start_button;
    [Header("Text box Data")]
    public string character_Name;
    public int[] character_talk_order;
    [TextArea(3, 10)]
    public string[] sentences;
    //public string[] ownSentences;
    public float typingSpeed;
    public Sprite[] character_Images;

    [Header("Animator")]
    public Animator animator; 
    
    public void StartDialogue()
    {
        dialogue_start_button.gameObject.SetActive(false);
        character_default_Image.gameObject.SetActive(true);
        animator.SetBool("isOpened", true);
        dialogue_Field_Obj.text = character_Name;                
        DisplayNextSentence();
    }

    public void DisplayNextSentence() { 
        if (index < sentences.Length) //osea que alcanzamos el final de la cola
        {            
            string sentence = sentences[index];
            dialogue_Field_Obj.text = sentence;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
            index++;
        }
        else
        {
            dialogue_Field_Obj.text = "";            
            EndDialogo();
                        
        }        
    }

    IEnumerator TypeSentence(string sentence)
    {
        Debug.Log("index: " + index);
        character_default_Image.sprite = character_Images[character_talk_order[index]];// asigno game object..
        
        /*
         * if(index ==0){
         * what_to_do_text.setActive(true);
         * answer_one_button.setActive(true);
         * answer_two_button.setActive(true);
         * next_button.setActive(false);
         * answer_one_button.text = response_one;
         * answer_two_button.text = response_two;
         * }else{
         * * what_to_do_text.setActive(false);
         * answer_one_button.setActive(false);
         * answer_two_button.setActive(false);
         * next_button.setActive(true);
         * código de abajo
         */
        dialogue_Field_Obj.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogue_Field_Obj.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogo()
    {
        character_default_Image.gameObject.SetActive(false);
        animator.SetBool("isOpened", false);
        dialogue_start_button.gameObject.SetActive(true);
        index = 0;
    }
}

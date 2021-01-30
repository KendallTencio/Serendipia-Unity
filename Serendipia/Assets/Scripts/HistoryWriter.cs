using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script se coloca en un objeto y nos permite iniciar un nuevo diálogo
public class HistoryWriter : MonoBehaviour
{
    public Dialogo dialogue;
    public void HistoryTelling()
    {
        FindObjectOfType<DialogoManager>().StartDialogue(dialogue); // le dice al dialog manager qué conversación comenzar
    }
}

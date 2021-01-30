using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Synopsis : MonoBehaviour
{
    public string[] text_sentences;
    public Sprite[] images;
    public Image images_holder;
    public Text text_display;
    public GameObject canvas;
    public GameObject BackButton;

    private int count_sentences;
    private int count_limit;

    void Start()
    {
        count_sentences = 0;
        count_limit = text_sentences.Length;
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
        text_display.text = text_sentences[count_sentences];
        images_holder.sprite = images[count_sentences];
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            text_display.color = new Color(1, 1, 1, i);
            images_holder.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

    public void NextSentence()
    {
        if (count_sentences != (count_limit - 1))
        {
            count_sentences++;
            StartCoroutine(FadeImage());
        }
        else
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }

    public void BackSentence()
    {
        if (count_sentences != 0)
        {
            count_sentences--;
            StartCoroutine(FadeImage());
        }
    }
}

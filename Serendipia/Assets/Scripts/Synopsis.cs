using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Synopsis : MonoBehaviour
{
    public string[] text_sentences;
    public GameObject[] images;
    public GameObject images_holder;
    public Text text_display;

    public GameObject canvas;
    public Text chapter_text;

    void Start()
    {
        canvas.SetActive(false);
    }

    IEnumerator FadeImage()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            chapter_text.color = new Color(1, 1, 1, i);
            yield return null;
        }

        yield return new WaitForSeconds(1.5f);
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            chapter_text.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

    void NextSentence()
    {
        canvas.SetActive(true);
        StartCoroutine(FadeImage());
    }
}

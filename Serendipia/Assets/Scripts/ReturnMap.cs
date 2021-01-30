using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMap : MonoBehaviour
{
  public void Return()
    {

        StartCoroutine(rutinaReturn());
    }

    IEnumerator rutinaReturn()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Mapa");
    }
}

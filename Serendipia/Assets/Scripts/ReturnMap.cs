﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMap : MonoBehaviour
{
  public void Return()
    {
        SceneManager.LoadScene("Mapa");
    }
}

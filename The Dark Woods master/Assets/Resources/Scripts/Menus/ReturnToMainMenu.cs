﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
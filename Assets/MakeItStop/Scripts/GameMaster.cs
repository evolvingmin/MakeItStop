﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}

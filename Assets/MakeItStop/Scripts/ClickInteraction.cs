using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInteraction : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect()
    {
        if (Time.timeScale == 0.0f)
            return;

        audioSource.Play();
    }
}

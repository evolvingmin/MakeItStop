using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{

    private Animator anim;

    private AudioSource audioSource;

    private float speed = 15.0f;
    private float pushBackPower = 2.5f;

    private float fowardSpeed = 0.015f;


    private float maxWaitTime = 2.0f;
    private float minWaitTime = 1.0f;

    private Coroutine wonderRoutine = null;

    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        wonderRoutine = StartCoroutine(Wonder());
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Running") == false)
            return;

        transform.transform.position += fowardSpeed * Vector3.back;
    }

    IEnumerator Wonder()
    {
        while(true)
        {
            float runningTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(runningTime);
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Running"))
            {
                anim.SetTrigger("Run");

                float destX = 0.0f;
                if(transform.position.x  == 0 )
                {
                    bool isLeft = Random.Range(0, 2) == 0;
                    destX = Random.Range(0, 2) == 0 ? -1.5f : 1.5f;
                }
                else
                {
                    destX = 0.0f;
                }
                transform.DOMoveX(destX, runningTime);

            }
        }

        

    }

    public void OnSelect()
    {
        if (audioSource.isPlaying)
            return;

        anim.SetTrigger("Click");
        audioSource.Play();

        transform.DOMove(transform.position + Vector3.forward * pushBackPower, 0.5f);
    }
}

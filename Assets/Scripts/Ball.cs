using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.5f;

    Vector2 paddleToBallVector;
    bool isStarted = false;

    AudioSource myAudioSource;
    Rigidbody2D myRigitBody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigitBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStarted)
        {
            LockTheBall();
            LaunchBallOnClick();
        }
    }

    private void LaunchBallOnClick()
    {
       if(Input.GetMouseButtonDown(0))
        {
            myRigitBody2D.velocity = new Vector2(2f, 13f);
            isStarted = true;
        }
    }

    private void LockTheBall()
    {
        
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 velocityTweak = new Vector2
            (UnityEngine.Random.Range(0f, randomFactor),
            UnityEngine.Random.Range(0f, randomFactor));


        if (isStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigitBody2D.velocity += velocityTweak;
        }
    }
}

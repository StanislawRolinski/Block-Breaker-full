using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidth = 16f;
    [SerializeField] float minX = 2f;
    [SerializeField] float maxX = 14f;
    // Start is called before the first frame update

     Ball ball;
    GameStatus status;
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        status = FindObjectOfType<GameStatus>();
        
    }

    // Update is called once per frame
    void Update()
    { 
        Vector2 paddlePoss = new Vector2(transform.position.x, transform.position.y);
        paddlePoss.x = Mathf.Clamp(GetXPoss(), minX, maxX);
        transform.position = paddlePoss;
    } 

    private float GetXPoss()
    {
        if(status.IsAutoplayEnabled())
        {
            return ball.transform.position.x;
        } else return Input.mousePosition.x / Screen.width * screenWidth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien_script : MonoBehaviour
{
    public int alienValue = 100;

    private float horizontalPeriod;
    private float horizontalMovement = 0.75f;
    private float verticalMovement = 1.0f;
    private float nextHorizontalMoveTime = 0.0f;
    private float startTime;
    private float elapsedTime;
    private bool moveLeft = false;
    private int iterations;
    private int level;
    private GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameController");
        level = controller.GetComponent<GameController_Script>().level;
        horizontalPeriod = 2.0f - (0.25f * ((float)level-1));
        nextHorizontalMoveTime = horizontalPeriod;
        iterations = 0;
        startTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime = Time.time - startTime;
        if (elapsedTime > nextHorizontalMoveTime)
        {
            if (moveLeft)
                    MoveLeft();
                else
                    MoveRight();
            nextHorizontalMoveTime += horizontalPeriod;
            iterations++;
            if (iterations == 4)
            {
                Invoke("MoveDown", horizontalPeriod / 2f);
                moveLeft = !moveLeft;
                iterations = 0;
            }
        }


    }
    void MoveLeft()
    {
        transform.position = new Vector3(transform.position.x - horizontalMovement, transform.position.y, 0);
    }
    void MoveRight()
    {
        transform.position = new Vector3(transform.position.x + horizontalMovement, transform.position.y, 0);
    }
    void MoveDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - verticalMovement, 0);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        controller.GetComponent<GameController_Script>().AlienDestroyed(alienValue);
        Destroy(gameObject);
    }
}

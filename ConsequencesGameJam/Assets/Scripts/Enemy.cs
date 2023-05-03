using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private bool alertMode = false;
    private int health;
    private float speed;
    private float timer = 0;
    private int facingDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);

        if(timer >= 5 && alertMode == false)
        {
            facingDirection = Random.Range(0, 3);
        }

        if(facingDirection == 0)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        else if (facingDirection == 1)
        {
            transform.position -= transform.forward * Time.deltaTime * speed;
        }
        else if (facingDirection == 2)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        if (alertMode == false)
        {
            speed = 1.0f;
        }
        else
        {
            speed = 2.0f;
        }
    }

    private void PatrolMode()
    {

    }
}

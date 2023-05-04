using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private bool alertMode = false;
    private int health;
    private float speed;
    private float timer = 0.0f;
    private int facingDirection;
    public string patrolOrientation;
    private enum Orientation { UP, DOWN, RIGHT, LEFT };
    private Orientation orientation;
    public int patrolLength;

    // Start is called before the first frame update
    void Start()
    {
        if(patrolOrientation == "vertical")
        {
            orientation = Orientation.UP;
            facingDirection = 0;
        }
        else if(patrolOrientation == "horizontal")
        {
            orientation = Orientation.RIGHT;
            facingDirection = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= patrolLength && alertMode == false)
        {
            ChangeDirection();
            timer = 0;
        }

        if (facingDirection == 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
            transform.position += Vector3.up * Time.deltaTime * speed;
            Debug.Log("Up");
        }
        else if (facingDirection == 1)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.right);
            transform.position += Vector3.right * Time.deltaTime * speed;
            Debug.Log("Right");
        }
        else if (facingDirection == 2)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.down);
            transform.position -= Vector3.up * Time.deltaTime * speed;
            Debug.Log("Down");
        }
        else if (facingDirection == 3)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.left);
            transform.position -= Vector3.right * Time.deltaTime * speed;
            Debug.Log("Left");
        }
        else
        {
            Debug.Log("DAMNIT");
        }


        if (alertMode == false)
        {
            speed = 2.0f;
        }
        else
        {
            speed = 3.0f;
        }
    }

    private void ChangeDirection()
    {
        Debug.Log("THINGY");
        
        if(patrolOrientation == "vertical")
        {
            orientation = (orientation == Orientation.UP) ? Orientation.DOWN : Orientation.UP;
            Debug.Log("v");
            facingDirection = (orientation == Orientation.UP) ? 0 : 2;
        }
        
        if(patrolOrientation == "horizontal")
        {
            orientation = (orientation == Orientation.RIGHT) ? Orientation.LEFT : Orientation.RIGHT;
            facingDirection = (orientation == Orientation.RIGHT) ? 1 : 3;
        }
    }
}

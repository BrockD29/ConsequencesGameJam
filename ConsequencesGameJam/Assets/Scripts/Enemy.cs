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
    public Transform target;
    public Transform eyes;
    private static Vector3 STARTING_POSITION;
    private float cooldown;

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

        STARTING_POSITION = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        timer += Time.deltaTime;

        if(timer >= patrolLength && alertMode == false)
        {
            ChangeDirection();
            timer = 0;
        }

        if((Vector3.Distance(target.position, eyes.position)) <= 20) 
        {
            CheckForPlayer();
        }
        
        if (alertMode == false)
        {
            speed = 2.0f;
            PatrolMode();
        }
        else
        {
            speed = 5.0f;
            ChaseMode();
        }
    }

    private void ChangeDirection()
    {     
        if(patrolOrientation == "vertical")
        {
            orientation = (orientation == Orientation.UP) ? Orientation.DOWN : Orientation.UP;
            facingDirection = (orientation == Orientation.UP) ? 0 : 2;
        }
        
        if(patrolOrientation == "horizontal")
        {
            orientation = (orientation == Orientation.RIGHT) ? Orientation.LEFT : Orientation.RIGHT;
            facingDirection = (orientation == Orientation.RIGHT) ? 1 : 3;
        }
    }

    private void CheckForPlayer()
    {
        Vector3 targetDir = target.position - eyes.position;
        float angle = Vector3.Angle(eyes.position, targetDir);
        if(facingDirection == 0 && (angle < 95.0f && angle > 85.0f))
        {
            Debug.Log("Close looking up");
            if(cooldown <= 0)
            {
                alertMode = true;
            }
        }
        else if(facingDirection == 1 && angle < 5.0f)
        {
            Debug.Log("Close looking right");
            if (cooldown <= 0)
            {
                alertMode = true;
            }
        }
        else if(facingDirection == 2 && (angle < 95.0f && angle > 85.0f))
        {
            Debug.Log("Close looking down");
            if (cooldown <= 0)
            {
                alertMode = true;
            }
        }
        else if (facingDirection == 3 && angle > 175.0f)
        {
            Debug.Log("Close looking left");
            if (cooldown <= 0)
            {
                alertMode = true;
            }
        }
    }
    
    private void PatrolMode()
    {
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
    }

    private void ChaseMode()
    {
        Vector3 targetDir = target.position - eyes.position;
        float angle = Vector3.Angle(eyes.position, targetDir);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetDir);
        transform.position += targetDir * Time.deltaTime * speed;

        if(Input.GetKeyDown(KeyCode.E))
        {
            cooldown = 3;
            alertMode = false;
            ReturnToPost();
        }
    }

    private void ReturnToPost()
    {
        Vector3 targetDir = STARTING_POSITION - transform.position;
        float angle = Vector3.Angle(transform.position, targetDir);
        if(transform.position != STARTING_POSITION)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, targetDir);
            transform.position += targetDir * Time.deltaTime * speed;
        }
        else
        {
            PatrolMode();
        }
    }
}

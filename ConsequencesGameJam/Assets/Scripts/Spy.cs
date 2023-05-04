using UnityEngine;

public class Spy : MonoBehaviour
{
    public bool crouch = false;
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        //Crouch Speed
        if (crouch == true)
        {
            speed = 2.5f;
        }
        else
        {
            speed = 5.0f;
        }

        //Spy Movement
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }
        else if(Input.GetAxis("Vertical")  < 0)
        {
            transform.position -= transform.up * Time.deltaTime * speed;
        } 

        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += transform.right * Time.deltaTime * speed;
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            transform.position -= transform.right * Time.deltaTime * speed;
        }

        //Toggle Crouch
        if (Input.GetKeyDown(KeyCode.Q))
        {
            crouch = (crouch == false) ? true : false;
        }
    }
}

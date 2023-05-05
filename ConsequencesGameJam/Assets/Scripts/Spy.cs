using UnityEngine.Audio;
using UnityEngine;

public class Spy : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] bool crouch = false;
    [SerializeField] float speed;
    AudioSource walking;
    [SerializeField] bool isMoving;

    void Start()
    {
        walking = GetComponent<AudioSource>();
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
        if(Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.up * Time.deltaTime * speed;
            isMoving = true;
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            transform.position -= transform.up * Time.deltaTime * speed;
            isMoving = true;
        }
       
        
        
        if(Input.GetAxis("Horizontal") > 0)
        {
            transform.position += transform.right * Time.deltaTime * speed;
            isMoving = true;
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            transform.position -= transform.right * Time.deltaTime * speed;
            isMoving = true;
        }

        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) 
        { 
            isMoving = false; 
        }


        if(isMoving == true && crouch == false && !walking.isPlaying) 
        {
            walking.Play();
        }
        else
        {
            walking.Stop();
        }

        //Toggle Crouch
        if (Input.GetKeyDown(KeyCode.Q))
        {
            crouch = (crouch == false) ? true : false;
        }
    }
}

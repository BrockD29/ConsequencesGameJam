using UnityEngine;

public class Spy : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

    }
}

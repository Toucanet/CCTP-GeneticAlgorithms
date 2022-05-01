using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    float panSpeed = 15.0f;
    float scrollSpeed = 10.0f;
    int scrollAmount = 2;
    [SerializeField] GameObject ranchLoc;
    [SerializeField] GameObject wildLoc;
    [SerializeField] GameObject state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (state.GetComponent<stateHolder>().GetState() == 0)
            {
                if (transform.position.z < 60)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * panSpeed * 2, Space.World);
                }

            }
            else
            {
                if(transform.position.z < 1)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * panSpeed, Space.World);
                }
            }
                
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (state.GetComponent<stateHolder>().GetState() == 0)
            {
                if(transform.position.z > -40)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * -panSpeed * 2, Space.World);
                }

            }
            else
            {
                if(transform.position.z > -75)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * -panSpeed, Space.World);
                }
            }
               
        }
        if (Input.GetKey(KeyCode.D))
        {
            if(state.GetComponent<stateHolder>().GetState() == 0)
            {
                if(transform.position.x < 100)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * panSpeed * 2, Space.World);
                }

            }
            else
            {
                if(transform.position.x < -270)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * panSpeed, Space.World);
                }
                
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (state.GetComponent<stateHolder>().GetState() == 0)
            {
                if( transform.position.x > 20)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * -panSpeed * 2, Space.World);
                }

            }
            else
            {
                if (transform.position.x > -320)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * -panSpeed, Space.World);
                }
                    
            }
            
        }

        if(Input.mouseScrollDelta.y<0)
        {
            //scroll in? out?
            //out!!
            if(scrollAmount < 4)
            {
                transform.Translate(Vector3.forward * -scrollSpeed);
                scrollAmount++;
            }

        }
        else if(Input.mouseScrollDelta.y>0)
        {
            if(scrollAmount > 0)
            {
                transform.Translate(Vector3.forward * scrollSpeed);
                scrollAmount--;
            }

        }
    }


    public void SwapLocation(int i)
    {
        if(i==0)
        {
            //go to ranch
            transform.position = ranchLoc.transform.position;
            scrollAmount = 2;
        }
        else
        {
            //go to wild
            transform.position = wildLoc.transform.position;
            scrollAmount = 2;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    float height;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeHeight(float height)
    {
        transform.localScale = new Vector3( 1, height, 1);
        transform.position = new Vector3(transform.position.x, (height - 0.5f), transform.position.z);
    }

}

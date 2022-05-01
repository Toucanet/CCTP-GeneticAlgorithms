using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateHolder : MonoBehaviour
{
    private int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState(int i)
    {
        state = i;
    }
    public int GetState()
    {
        return state;
    }
}

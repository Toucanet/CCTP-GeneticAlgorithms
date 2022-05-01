using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMover : MonoBehaviour
{

    float speed;
    bool waiting = false;
    Vector3 randomDestination;
    bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        newDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if(!waiting && !paused)
        {
            if (Vector3.Distance(this.transform.position, randomDestination) < 3)
            {
                StartCoroutine(WaitABit());
            }

            transform.position = Vector3.MoveTowards(transform.position, randomDestination, speed * Time.deltaTime);
        }

    }

    void newDestination()
    {
        randomDestination =  new Vector3(UnityEngine.Random.Range(-16, 50), transform.position.y, UnityEngine.Random.Range(-66, 66));
        waiting = false;
    }

    IEnumerator WaitABit()
    {
        waiting = true;
        yield return new WaitForSeconds(1);
        newDestination();
    }

    public void Pause()
    {
        paused = !paused;
    }

    public void OnlyPause()
    {
        paused = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryGeneHolder : MonoBehaviour
{
    //starting with just colour
    public int[] genome;
    public float fitness;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void GenerateGene()
    {
        genome = new int[24];
        for (int i = 0; i < 24; i++)
        {
            //random int between 1 and 20
            int asdf = Random.Range(0, 1);
            genome[i] = asdf;
        }
    }
    public void SetGene(int[] x)
    {
        genome = x;
    }

    public int[] GetGene()
    {
        return genome;
    }

    void SetFitness(float x)
    {
        fitness = x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

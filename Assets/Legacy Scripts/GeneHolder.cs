using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneHolder : MonoBehaviour
{

    //this just exists to hold the genes (right now, 20 ints between 1 and 20

    public int[] genome;
    public int fitness;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateGene()
    {
        genome = new int[20];
        for (int i = 0; i < 20; i++)
        {
            //random int between 1 and 20
            int asdf = Random.Range(1, 21);
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

    void SetFitness(int x)
    {
        fitness = x;
    }
}

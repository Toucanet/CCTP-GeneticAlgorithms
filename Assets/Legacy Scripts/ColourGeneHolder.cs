using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourGeneHolder : MonoBehaviour
{
    //this just exists to hold the genes (right now, 3 floats between 0 and 1)

    public float[] genome;
    public float fitness;
    public float avr, avg, avb, avh;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        avr = (genome[0] + genome[1] + genome[2]) / 3;
        avg = (genome[3] + genome[4] + genome[5]) / 3;
        avb = (genome[6] + genome[7] + genome[8]) / 3;
        avh = (genome[9] + genome[10] + genome[11]) / 3;
    }

    public void GenerateGene()
    {
        genome = new float[12];
        for (int i = 0; i < 9; i++)
        {
            //random int between 1 and 20
            float asdf = Random.Range(0.0f, 1.0f);
            genome[i] = asdf;
        }
        for (int i = 9; i < 12; i++)
        {
            //random int between 1 and 20
            float asdf = Random.Range(0.5f, 10.0f);
            genome[i] = asdf;
        }
    }

    public void SetGene(float[] x)
    {
        genome = x;
    }

    public float[] GetGene()
    {
        return genome;
    }

    void SetFitness(float x)
    {
        fitness = x;
    }
}

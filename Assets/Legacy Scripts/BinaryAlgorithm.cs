using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class BinaryAlgorithm : MonoBehaviour
{
    /*public int num_epochs = 0;
    public int total_pop = 50;
    public float best = 0;
    public GameObject[] genomes;
    public GameObject[] childrenTemp;
    public int[] desired_result;
    //public float desired_height;
    public bool done = false;
    bool beingHandled = false;
    public GameObject env; */
    // Start is called before the first frame update
    void Start()
    {
        /*desired_result = new float[3];
        //for (int i = 0; i < 3; i++)
        //{
        //    desired_result[i] = UnityEngine.Random.Range(0.0f, 1.0f);
        //}


        genomes = new GameObject[total_pop];
        childrenTemp = new GameObject[total_pop];

        //generate (pop number total) of genomes & add to array
        for (int i = 0; i < total_pop; i++)
        {
            GameObject GeneholderTemp = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GeneholderTemp.name = "Binary Geneholder" + i;
            GeneholderTemp.transform.position = new Vector3(transform.position.x + i, transform.position.y, transform.position.z);
            GeneholderTemp.AddComponent<BinaryGeneHolder>();
            //GeneholderTemp.GetComponent<GeneHolder>().GenerateGene();
            genomes[i] = GeneholderTemp;

            GameObject childHolder = new GameObject();
            childHolder.name = "Binary Holder Child" + i;
            childHolder.transform.position = transform.position;
            childHolder.AddComponent<BinaryGeneHolder>();
            childrenTemp[i] = childHolder;
        }
        for (int i = 0; i < total_pop; i++)
        {
            genomes[i].GetComponent<BinaryGeneHolder>().GenerateGene();
            CheckFit(i);
        }
        ChangeColours();
        done = true; */
    }

    // Update is called once per frame
    void Update()
    {
        /*

        desired_result[0] = env.GetComponent<WildEnvironment>().rd2;
        desired_result[1] = env.GetComponent<WildEnvironment>().grn2;
        desired_result[2] = env.GetComponent<WildEnvironment>().bl2;
        //desired_height = env.GetComponent<WildEnvironment>().height;

        //check initial generation is done
        if (done && !beingHandled)
        {
            //check fit, if not perf do next generation
            for (int i = 0; i < total_pop; i++)
            {
                CheckFit(i);
                if (genomes[i].GetComponent<BinaryGeneHolder>().fitness == 0)
                {
                    //we did it, for now set done to false to stop generating which is counterintuitive
                    OrderByFitness();
                    done = false;
                }
            }
            if (done)
            {
                OrderByFitness();
                //create next gen
                NewGeneration();
                num_epochs++;
                StartCoroutine(WaitABit());
            }

        }
        */
    }

    
}

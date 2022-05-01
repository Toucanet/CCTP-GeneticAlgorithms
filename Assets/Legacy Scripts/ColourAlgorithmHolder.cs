using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ColourAlgorithmHolder : MonoBehaviour
{
    /*
    public int num_epochs = 0;
    public int total_pop = 50;
    public float best = 0;
    public GameObject[] genomes;
    public GameObject[] childrenTemp;
    public float[] desired_result;
    //public float desired_height;
    public bool done = false;
    bool beingHandled = false;
    public GameObject env;
    public bool PAUSE;
    // Start is called before the first frame update
    void Start()
    {
        PAUSE = false;
        desired_result = new float[4];

        genomes = new GameObject[total_pop];
        childrenTemp = new GameObject[total_pop];

        //generate (pop number total) of genomes & add to array
        for (int i = 0; i < total_pop; i++)
        {
            GameObject GeneholderTemp = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GeneholderTemp.name = "Colour Geneholder" + i;
            GeneholderTemp.transform.position = new Vector3(UnityEngine.Random.Range(-16, 115), transform.position.y, UnityEngine.Random.Range(-66, 66));
            GeneholderTemp.AddComponent<ColourGeneHolder>();
            //GeneholderTemp.GetComponent<GeneHolder>().GenerateGene();
            genomes[i] = GeneholderTemp;

            GameObject childHolder = new GameObject();
            childHolder.name = "Colour Holder Child" + i;
            childHolder.transform.position = transform.position;
            childHolder.AddComponent<ColourGeneHolder>();
            childrenTemp[i] = childHolder;
        }
        for (int i = 0; i < total_pop; i++)
        {
            genomes[i].GetComponent<ColourGeneHolder>().GenerateGene();
            CheckFit(i);
        }
        ChangeColours();
        done = true;
    }

    // Update is called once per frame
    void Update()
    {


        desired_result[0] = env.GetComponent<WildEnvironment>().rd;
        desired_result[1] = env.GetComponent<WildEnvironment>().grn;
        desired_result[2] = env.GetComponent<WildEnvironment>().bl;
        desired_result[3] = env.GetComponent<WildEnvironment>().height;
        if (Input.GetKeyDown(KeyCode.P))
        {
            PAUSE = !PAUSE;
        }

            //check initial generation is done
            if (done&& !beingHandled && !PAUSE)
        {
            //check fit, if not perf do next generation
            for (int i = 0; i < total_pop; i++)
            {
                CheckFit(i);
                /*if (genomes[i].GetComponent<ColourGeneHolder>().fitness == 0)
                {
                    //we did it, for now set done to false to stop generating which is counterintuitive
                    OrderByFitness();
                    done = false; 
                }
                
            }

                OrderByFitness();
                //create next gen
                NewGeneration();
                num_epochs++;
                StartCoroutine(WaitABit());
            

        }

    }

    void CheckFit(int x)
    {
        float fit = 0;
        for (int i = 0; i < 4; i++)
        {
            //see how close to correct number each gene is
            if (i ==0)
            {
                //r
                float aaa = Mathf.Abs(((genomes[x].GetComponent<ColourGeneHolder>().genome[0] + genomes[x].GetComponent<ColourGeneHolder>().genome[1] + genomes[x].GetComponent<ColourGeneHolder>().genome[2]) / 3) - desired_result[i]);
                fit += aaa;
            }
            else if (i==1)
            {
                float aaa = Mathf.Abs(((genomes[x].GetComponent<ColourGeneHolder>().genome[3] + genomes[x].GetComponent<ColourGeneHolder>().genome[4] + genomes[x].GetComponent<ColourGeneHolder>().genome[5]) / 3) - desired_result[i]);
                fit += aaa;
            }
            else if (i==2)
            {
                float aaa = Mathf.Abs(((genomes[x].GetComponent<ColourGeneHolder>().genome[6] + genomes[x].GetComponent<ColourGeneHolder>().genome[7] + genomes[x].GetComponent<ColourGeneHolder>().genome[8]) / 3) - desired_result[i]);
                fit += aaa;
            }
            else if (i==3)
            {
                float aaa = Mathf.Abs(((genomes[x].GetComponent<ColourGeneHolder>().genome[9] + genomes[x].GetComponent<ColourGeneHolder>().genome[10] + genomes[x].GetComponent<ColourGeneHolder>().genome[11]) / 3) - desired_result[i]);
                float bbb = aaa / 2;
                fit += bbb;
            }

        }
        genomes[x].GetComponent<ColourGeneHolder>().fitness = fit;
    }

    void OrderByFitness()
    {
        genomes = genomes.OrderBy(x => x.GetComponent<ColourGeneHolder>().fitness).ToArray();
        //Array.Reverse(genomes);
        best = genomes[0].GetComponent<ColourGeneHolder>().fitness;
    }

    void NewGeneration()
    {
        int new_gen_number = 0;
        for (int i = 0; i < total_pop; i++)
        {
            //create baby
            //try different parent selectors!
            int Parent1 = RouletteSelection();
            int Parent2 = RouletteSelection();
            Mate(Parent1, Parent2, new_gen_number);
            new_gen_number++;
        }
        //new gen number should now be 50, replace parents with children!!
        for (int i = 0; i < total_pop; i++)
        {
            genomes[i].GetComponent<ColourGeneHolder>().genome = childrenTemp[i].GetComponent<ColourGeneHolder>().genome;
            
        }
        ChangeColours();
        ChangeHeights();
    }

    int RouletteSelection()
    {
        //float random_length_in = 
        float fitness_total = 0;
        for (int i = 0; i < (total_pop / 2); i++)
        {
            fitness_total += genomes[i].GetComponent<ColourGeneHolder>().fitness;
        }

        //choose random float between 0 and fitness total
        float random_length_in = UnityEngine.Random.Range(0, fitness_total);


        //loop through again ig
        fitness_total = 0;
        for (int i = 0; i < (total_pop / 2); i++)
        {
            fitness_total += genomes[i].GetComponent<ColourGeneHolder>().fitness;
            if (fitness_total > random_length_in)
            {
                return i;
            }
        }

        return 0;
    }

    void Mate(int Parent1, int Parent2, int num)
    {
        //Debug.Log(Parent1 + " " + Parent2 + " " + num);
        //v simple method to start
        int len = genomes[Parent1].GetComponent<ColourGeneHolder>().genome.Length;
        float[] tempArray = new float[12];
        //colour
        for (int i = 0; i < 9; i++)
        {
            float chance = UnityEngine.Random.Range(0, 100);
            chance = chance / 100;
            //Debug.Log(chance);
            if (chance < 0.45)
            {
                //parent1
                tempArray[i] = genomes[Parent1].GetComponent<ColourGeneHolder>().genome[i];
            }
            else if (0.45 < chance && chance < 0.9)
            {
                //Parent2
                tempArray[i] = genomes[Parent2].GetComponent<ColourGeneHolder>().genome[i];
            }
            else
            {
                //mutate, chose random
                float asdf = MutateColour(genomes[Parent1].GetComponent<ColourGeneHolder>().genome[i], genomes[Parent2].GetComponent<ColourGeneHolder>().genome[i]);
                tempArray[i] = asdf;
            }
        }
        //height
        for (int i = 9; i < 12; i++)
        {
            float ch = UnityEngine.Random.Range(0, 100);
            ch = ch / 100;
            //Debug.Log(chance);
            if (ch < 0.45)
            {
                //parent1
                tempArray[i] = genomes[Parent1].GetComponent<ColourGeneHolder>().genome[i];
            }
            else if (0.45 < ch && ch < 0.9)
            {
                //Parent2
                tempArray[i] = genomes[Parent2].GetComponent<ColourGeneHolder>().genome[i];
            }
            else
            {
                //mutate, chose random
                float asdf = UnityEngine.Random.Range(0.5f, 10.0f);
                tempArray[i] = asdf;
            }
        }


        //cool, now put the child somewhere
        childrenTemp[num].GetComponent<ColourGeneHolder>().SetGene(tempArray);
    }

    void ChangeColours()
    {
        for(int i = 0; i < total_pop; i++)
        {
            float r = (genomes[i].GetComponent<ColourGeneHolder>().genome[0] + genomes[i].GetComponent<ColourGeneHolder>().genome[1] + genomes[i].GetComponent<ColourGeneHolder>().genome[2]) /3;
            float g = (genomes[i].GetComponent<ColourGeneHolder>().genome[3] + genomes[i].GetComponent<ColourGeneHolder>().genome[4] + genomes[i].GetComponent<ColourGeneHolder>().genome[5]) / 3;
            float b = (genomes[i].GetComponent<ColourGeneHolder>().genome[6] + genomes[i].GetComponent<ColourGeneHolder>().genome[7] + genomes[i].GetComponent<ColourGeneHolder>().genome[8]) / 3;

            genomes[i].GetComponent<Renderer>().material.color = new Color(r, g, b);
        }
    }

    void ChangeHeights()
    {
        for (int i = 0; i < total_pop; i++)
        {
            float h = (genomes[i].GetComponent<ColourGeneHolder>().genome[9] + genomes[i].GetComponent<ColourGeneHolder>().genome[10] + genomes[i].GetComponent<ColourGeneHolder>().genome[11])/3;
            genomes[i].transform.localScale = new Vector3(1, h, 1);
            genomes[i].transform.position = new Vector3(genomes[i].transform.position.x, (h/2) - 0.5f, genomes[i].transform.position.z);
        }
    }

    IEnumerator WaitABit()
    {
        beingHandled = true;
        yield return new WaitForSeconds(0.5f);
        beingHandled = false;
    }

    float MutateColour(float current1, float current2)
    {
        float current = (current1 + current2) / 2;
        float min, max;
        max = current + 0.3f;
        if (max > 1.0f)
        {
            max = 1.0f;
        }
        min = current - 0.3f;
        if (min < 0.0f)
        {
            min = 0.0f;
        }
        float next = UnityEngine.Random.Range(min, max);
        return next;
    }
*/

}

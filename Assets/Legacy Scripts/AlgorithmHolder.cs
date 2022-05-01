using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class AlgorithmHolder : MonoBehaviour
{
    public int num_epochs = 0;
    public int total_pop = 50;
    public int best = 0;
    public GameObject[] genomes;
    public GameObject[] childrenTemp;
    public int[] desired_result;
    bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        desired_result = new int[20];
        for (int i = 0; i < 20; i++)
        {
            desired_result[i] = i + 1;
        }
        genomes = new GameObject[total_pop];
        childrenTemp = new GameObject[total_pop];

        //generate (pop number total) of genomes & add to array
        for (int i = 0; i < total_pop; i++)
        {
            GameObject GeneholderTemp = new GameObject();
            GeneholderTemp.name = "Geneholder" + i;
            GeneholderTemp.transform.position = transform.position;
            GeneholderTemp.AddComponent<GeneHolder>();
            //GeneholderTemp.GetComponent<GeneHolder>().GenerateGene();
            genomes[i] = GeneholderTemp;

            GameObject childHolder = new GameObject();
            childHolder.name = "Child" + i;
            childHolder.transform.position = transform.position;
            childHolder.AddComponent<GeneHolder>();
            childrenTemp[i] = childHolder;
        }
        for (int i = 0; i < total_pop; i++)
        {
            genomes[i].GetComponent<GeneHolder>().GenerateGene();
            CheckFit(i);
        }

        done = true;
    }

    // Update is called once per frame
    void Update()
    {
        //check initial generation is done
        if (done)
        {
            //check fit, if not perf do next generation
            for (int i = 0; i < total_pop; i++)
            {
                CheckFit(i);
                if(genomes[i].GetComponent<GeneHolder>().fitness == 20)
                {
                    //we did it, for now set done to false to stop generating which is counterintuitive
                    OrderByFitness();
                    done = false;
                }
            }
            if(done)
            {
            OrderByFitness();
            //create next gen
            NewGeneration();
            num_epochs++;
            }

        }

    }

    void CheckFit(int x)
    {
        int fit = 0;
        for (int i = 0; i < 20; i++)
        {
            //see how many values are in the right place
            if (genomes[x].GetComponent<GeneHolder>().genome[i] == desired_result[i])
            {
                fit++;
            }

        }
        genomes[x].GetComponent<GeneHolder>().fitness = fit;
    }

    void OrderByFitness()
    {
        genomes = genomes.OrderBy(x => x.GetComponent<GeneHolder>().fitness).ToArray();
        Array.Reverse(genomes);
        best = genomes[0].GetComponent<GeneHolder>().fitness;
    }

    void NewGeneration()
    {
        int new_gen_number = 0;
        for(int i = 0; i < total_pop; i++)
        {
            //create baby
            //try different parent selectors!
            int Parent1 = RouletteSelection();
            int Parent2 = RouletteSelection();
            Mate(Parent1, Parent2, new_gen_number);
            new_gen_number++;
        }
        //new gen number should now be 50, replace parents with children!!
        for(int i = 0; i < total_pop; i++)
        {
            genomes[i].GetComponent<GeneHolder>().genome = childrenTemp[i].GetComponent<GeneHolder>().genome;
        }
    }

    int RouletteSelection()
    {
        //float random_length_in = 
        float fitness_total = 0;
        for(int i = 0; i < (total_pop/2); i++)
        {
            fitness_total += genomes[i].GetComponent<GeneHolder>().fitness;
        }

        //choose random float between 0 and fitness total
        float random_length_in = UnityEngine.Random.Range(0, fitness_total);
        

        //loop through again ig
        fitness_total = 0;
        for (int i = 0; i < (total_pop/2); i++)
        {
            fitness_total += genomes[i].GetComponent<GeneHolder>().fitness;
            if(fitness_total > random_length_in)
            {
                //Debug.Log(random_length_in + " " + fitness_total + " " + i);
                return i;

                
            }
        }

        return 0;
    }

    void Mate(int Parent1, int Parent2, int num)
    {
        //Debug.Log(Parent1 + " " + Parent2 + " " + num);
        //v simple method to start
        int len = genomes[Parent1].GetComponent<GeneHolder>().genome.Length;
        int[] tempArray = new int[20];
        for(int i = 0; i < len; i++)
        {
            float chance = UnityEngine.Random.Range(0, 100);
            chance = chance / 100;
            //Debug.Log(chance);
            if(chance < 0.45)
            {
                //parent1
                tempArray[i] = genomes[Parent1].GetComponent<GeneHolder>().genome[i];
            }
            else if (0.45 < chance && chance < 0.9)
            {
                //Parent2
                tempArray[i] = genomes[Parent2].GetComponent<GeneHolder>().genome[i];
            }
            else
            {
                //mutate, chose random
                int asdf = UnityEngine.Random.Range(1, 21);
                tempArray[i] = asdf;
            }
        }

        //cool, now put the child somewhere
        childrenTemp[num].GetComponent<GeneHolder>().SetGene(tempArray);
    }
}

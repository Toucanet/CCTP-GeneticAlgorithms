using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genome : MonoBehaviour
{
    //holds all the gene data for one animal
    //public GameObject asdf;
    public GameObject[] genes;
    public float fitness;

    void Start()
    {

    }

    public void Init()
    {
        GameObject genePrefab = Resources.Load("Gene", typeof(GameObject)) as GameObject;

        genes = new GameObject[6];
        for(int i = 0; i < 6; i++)
        {
            genes[i] = Instantiate(genePrefab);
            genes[i].transform.parent = gameObject.transform;
        }

        genes[0].GetComponent<Gene>().Init("Colour", 96, false, 0, 0, 0, 0);
        genes[1].GetComponent<Gene>().Init("Height", 32, false, 0, 0, 0, 0);
        genes[2].GetComponent<Gene>().Init("Body", 100, false, 0, 0, 0, 0);
        genes[3].GetComponent<Gene>().Init("Head", 100, false, 0, 0, 0, 0);
        genes[4].GetComponent<Gene>().Init("Leg", 100, false, 0, 0, 0, 0);
        genes[5].GetComponent<Gene>().Init("Arm", 100, false, 0, 0, 0, 0);

        //genes[6].GetComponent<Gene>().Init("Hand", 20, false, 0, 0, 0, 0);
        //genes[7].GetComponent<Gene>().Init("Tail", 20, false, 0, 0, 0, 0);
        //genes[8].GetComponent<Gene>().Init("Horns", 20, false, 0, 0, 0, 0);

    }




    //Getters and Setters
    public void SetGene(int i, int[] x)
    {
        genes[i].GetComponent<Gene>().SetGene(x);
    }

    public void SetFitness(float f)
    {
        fitness = f;
    }

    public float GetFitness()
    {
        return fitness;
    }

    public int GetNumOfGenes()
    {
        return genes.Length;
    }

    public int GetLength(int i)
    {
        return genes[i].GetComponent<Gene>().GetLength();
    }

    public int GetGene(int geneName, int genePos)
    {
        return genes[geneName].GetComponent<Gene>().GetGeneValue(genePos);
    }

    public int GetCrossover(int i)
    {
        return genes[i].GetComponent<Gene>().GetCrossover();
    }

    public int GetMutationType(int i)
    {
        return genes[i].GetComponent<Gene>().GetMutation();
    }

    public int GetHeight()
    {
        int num = 0;

        for(int i = 0; i < 32; i++)
        {
            num += genes[(int)genePositions.Height].GetComponent<Gene>().GetGeneValue(i);
        }

        return num;
    }

    public int GetColour(int i)
    {
        int colour = 0;
        if (i == 0)
        {
            //r, first 32
            for (int j = 0; j < 32; j++)
            {
                colour += genes[(int)genePositions.Colour].GetComponent<Gene>().GetGeneValue(j);
            }

        }
        if(i==1)
        {
            //g
            for (int j = 32; j < 64; j++)
            {
                colour += genes[(int)genePositions.Colour].GetComponent<Gene>().GetGeneValue(j);
            }
        }
        if(i==2)
        {
            //b
            for (int j = 64; j < 96; j++)
            {
                colour += genes[(int)genePositions.Colour].GetComponent<Gene>().GetGeneValue(j);
            }
        }
        colour = colour * 8;
        return colour;
    }

    public int GetBody()
    {
        int bdy = 0;
        int length = genes[(int)genePositions.Body].GetComponent<Gene>().GetLength();
        for (int i = 0; i < length; i++)
        {
            bdy += genes[(int)genePositions.Body].GetComponent<Gene>().GetGeneValue(i);           
        }
        if (bdy < 40)
        {

            return 0;
        }
        else if (40 <= bdy && bdy <50)
        {
            return 1;
        }
        else if (50 <= bdy && bdy < 60)
        {
            return 2;
        }
        return 3;
    }
    public int GetHead()
    {
        int bdy = 0;
        int length = genes[(int)genePositions.Head].GetComponent<Gene>().GetLength();
        for (int i = 0; i < length; i++)
        {
            bdy += genes[(int)genePositions.Head].GetComponent<Gene>().GetGeneValue(i);
        }
        if (bdy < 40)
        {

            return 0;
        }
        else if (40 <= bdy && bdy < 50)
        {
            return 1;
        }
        else if (50 <= bdy && bdy < 60)
        {
            return 2;
        }
        return 3;
    }
    public int GetBleg()
    {
        int bdy = 0;
        int length = genes[(int)genePositions.Leg].GetComponent<Gene>().GetLength();
        for (int i = 0; i < length; i++)
        {
            bdy += genes[(int)genePositions.Leg].GetComponent<Gene>().GetGeneValue(i);
        }
        if (bdy < 40)
        {

            return 0;
        }
        else if (40 <= bdy && bdy < 50)
        {
            return 1;
        }
        else if (50 <= bdy && bdy < 60)
        {
            return 2;
        }
        return 3;
    }
    public int GetFleg()
    {
        int bdy = 0;
        int length = genes[(int)genePositions.Arm].GetComponent<Gene>().GetLength();
        for (int i = 0; i < length; i++)
        {
            bdy += genes[(int)genePositions.Arm].GetComponent<Gene>().GetGeneValue(i);
        }
        if (bdy < 40)
        {

            return 0;
        }
        else if (40 <= bdy && bdy < 50)
        {
            return 1;
        }
        else if (50 <= bdy && bdy < 60)
        {
            return 2;
        }
        return 3;
    }

    public int GetBodyNumber()
    {
        int num = 0;
        int length = genes[(int)genePositions.Body].GetComponent<Gene>().GetLength();
        for (int i = 0; i < length; i++)
        {
            num += genes[(int)genePositions.Body].GetComponent<Gene>().GetGeneValue(i);
        }
        return num;
    }

    public int GetHeadNumber()
    {
        int num = 0;
        int length = genes[(int)genePositions.Head].GetComponent<Gene>().GetLength();
        for (int i = 0; i < length; i++)
        {
            num += genes[(int)genePositions.Head].GetComponent<Gene>().GetGeneValue(i);
        }
        return num;
    }

    public int GetBlegNumber()
    {
        int num = 0;
        int length = genes[(int)genePositions.Leg].GetComponent<Gene>().GetLength();
        for (int i = 0; i < length; i++)
        {
            num += genes[(int)genePositions.Leg].GetComponent<Gene>().GetGeneValue(i);
        }
        return num;
    }

    public int GetFlegNumber()
    {
        int num = 0;
        int length = genes[(int)genePositions.Arm].GetComponent<Gene>().GetLength();
        for (int i = 0; i < length; i++)
        {
            num += genes[(int)genePositions.Arm].GetComponent<Gene>().GetGeneValue(i);
        }
        return num;
    }

    public void Mutate(int geneName, int pos)
    {
        genes[geneName].GetComponent<Gene>().MutateValue(pos);
    }


    
}

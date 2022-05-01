using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene : MonoBehaviour
{
    //each gene has a header and a vector of ints

    
     bool booleanGene; //is this gene an 'on or off' state
     int gender; //0 = both, 1 = m only, 2 = f only
     int age; //0 = child, 1 = adult
     int mutationType;
     int crossoverType;
    
    //public Header header;
    public string geneName;
    public int geneLength;
    public int[] geneData;

    public void Init(string name, int len, bool bol, int gen, int ag, int mtt, int cot)
    {
        geneName = name;
        gameObject.name = geneName;
        geneLength = len;
        geneData = new int[geneLength];
        CreateGene();
        booleanGene = bol;
        gender = gen;
        age = ag;
        mutationType = mtt;
        crossoverType = cot;
    }

    public int GetGender()
    {
        return gender;
    }

    public int GetAge()
    {
        return age;
    }

    public int GetMutation()
    {
        return mutationType;
    }

    public int GetCrossover()
    {
        return crossoverType;
    }

    public void CreateGene()
    {
        for(int i = 0; i < geneLength; i++)
        {
            geneData[i] = Random.Range(0, 2);
            //geneData[i] = 0;
        }
    }

    public void SetGene(int[] x)
    {
        geneData = x;
    }

    public int GetLength()
    {
        return geneLength;
    }

    public int GetGeneValue(int i)
    {
        return geneData[i];
    }

    public void MutateValue(int i)
    {
        if(geneData[i] ==0)
        {
            geneData[i] = 1;
        }
        else if(geneData[i] == 1)
        {
            geneData[i] = 0;
        }
    }


}

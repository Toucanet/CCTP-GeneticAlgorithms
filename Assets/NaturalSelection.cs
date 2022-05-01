using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NaturalSelection : MonoBehaviour
{
    [SerializeField] GameObject min;
    [SerializeField] GameObject max;
    public int generationSize = 2;
    public int numEpochs = 0;
    public GameObject Env;

    float waitSpeed = 1.0f;

    //temp things until environ redone
    Vector3 groundColour;

    bool paused = false;
    bool waiting = false;

    public GameObject[] adults;
    GameObject[] children;
    GameObject[] holder;
    public GameObject[] potentialChildren;
    GameObject AnimalTemplate;

    FitnessDesires fitnessDesires;
    WildEnvironment wildEnv;

    // Start is called before the first frame update
    void Start()
    {
        //temp stuff here
        adults = new GameObject[generationSize];
        children = new GameObject[generationSize];
        holder = new GameObject[generationSize];
        potentialChildren = new GameObject[generationSize];
        //

        fitnessDesires = gameObject.AddComponent<FitnessDesires>();
        fitnessDesires.GenerateSpecies();

        wildEnv = Env.GetComponent<WildEnvironment>();

        AnimalTemplate = Resources.Load("Animal", typeof(GameObject)) as GameObject;

        for (int i = 0; i < generationSize; i++)
        {
            GameObject Animal = Instantiate(AnimalTemplate);
            Animal.name = "Adult " + i;
            Animal.transform.position = new Vector3(UnityEngine.Random.Range(min.transform.position.x, max.transform.position.x), transform.position.y, UnityEngine.Random.Range(min.transform.position.z, max.transform.position.z));
            Animal.AddComponent<Genome>();
            Animal.GetComponent<Genome>().Init();
            Animal.transform.parent = this.gameObject.transform;
            adults[i] = Animal;
            //Debug.Log(adults[i].GetComponent<Genome>().genes[0]);
            //CheckFit(i);

            GameObject Child = Instantiate(AnimalTemplate);
            Child.name = "Child " + i;
            Child.transform.position = new Vector3(UnityEngine.Random.Range(min.transform.position.x, max.transform.position.x), transform.position.y, UnityEngine.Random.Range(min.transform.position.z, max.transform.position.z));
            Child.AddComponent<Genome>();
            Child.GetComponent<Genome>().Init();
            Child.transform.parent = this.gameObject.transform;
            children[i] = Child;

            GameObject childHolder = new GameObject();
            childHolder.name = "Potential Child " + i;
            childHolder.transform.position = transform.position;
            childHolder.AddComponent<Genome>();
            childHolder.GetComponent<Genome>().Init();
            childHolder.transform.parent = this.gameObject.transform;
            potentialChildren[i] = childHolder;
        }
        //OrderByFitness();

    }

    void CheckFit(int i)
    {


        
        groundColour = wildEnv.GetColour();
        float fit = 0;
        float red = 0;
        float green = 0;
        float blue = 0;


        
        
        
        //int length = adults[i].GetComponent<Genome>().GetLength((int)genePositions.Colour);
        for (int j = 0; j < 3; j++)
        {
            red = adults[i].GetComponent<Genome>().GetColour(0);
            green = adults[i].GetComponent<Genome>().GetColour(1);
            blue = adults[i].GetComponent<Genome>().GetColour(2);           
        }
        //if colour desire = camo
        int asdf = fitnessDesires.GetColourDesire();
        if (asdf == 0)
        {
            fit = Mathf.Abs((groundColour.x * 255) - red);
            fit += Mathf.Abs((groundColour.y * 255) - green);
            fit += Mathf.Abs((groundColour.z * 255) - blue);
        }
        //if colour desire = vibrant (white)
        else if (asdf == 1)
        {
            fit = 255 * 3;
            fit -= red;
            fit -= green;
            fit -= blue;
        }
        //if colour desire = vibrnt(one stat)
        else if (asdf == 2)
        {
            if(red >= blue)
            {
                if(green>=blue)
                {
                    //red > green > blue
                    fit = blue + green - red;
                }
                else if(green >= red)
                {
                    //green red blue
                    fit = blue + red - green;
                }
                else
                {
                    //red blue green
                    fit = blue + green - red;
                }

            }
            else //blue bigger than red
            {
                if(green >= blue)
                {
                    //green blue red
                    fit = red + blue - green;
                }
                else if(red>=green)
                {
                    //blue red green
                    fit = red + green - blue;
                }
                else
                {
                    //blue green red
                    fit = red + green - blue;
                }
            }

        }
        //vibrant (2 stats)
        else if (asdf == 3)
        {
            if (red >= blue)
            {
                if (green >= blue)
                {
                    //red > green > blue
                    fit = blue - green - red;
                }
                else if (green >= red)
                {
                    //green red blue
                    fit = blue - red - green;
                }
                else
                {
                    //red blue green
                    fit = blue - green - red;
                }

            }
            else //blue bigger than red
            {
                if (green >= blue)
                {
                    //green blue red
                    fit = red - blue - green;
                }
                else if (red >= green)
                {
                    //blue red green
                    fit = red - green - blue;
                }
                else
                {
                    //blue green red
                    fit = red - green - blue;
                }
            }

        }
        //if colour desire = dull
        else
        {
            fit = red;
            fit += blue;
            fit += green;
        }
        
        
        //higher fitness level = worse
   
        int foodDesire = fitnessDesires.GetFoodDesire();
        int aggro = fitnessDesires.GetAggro();
        int hmm = aggro + foodDesire;
        int bd = adults[i].GetComponent<Genome>().GetBodyNumber();
        int hd = adults[i].GetComponent<Genome>().GetHeadNumber();
        int bleg = adults[i].GetComponent<Genome>().GetBlegNumber();
        int fleg = adults[i].GetComponent<Genome>().GetFlegNumber();
        
        if (hmm < 2)
        {
            //speed - less than 33
            //fit *= 20;
            //fit += 400;
            fit += (float)bd;
            fit += (float)hd;
            fit += (float)fleg;
            fit += (float)bleg;
        }
        
        else if(hmm == 2)
        {
            //normal - av 41.5
            fit += Mathf.Abs((float)bd - 45f) * 2;
            fit += Mathf.Abs((float)hd - 45f) * 2;
            fit += Mathf.Abs((float)fleg - 45f) * 2;
            fit += Mathf.Abs((float)bleg - 45f) * 2;
        }
        else if(hmm==3)
        {
            //bulk - av 58.5
            fit += Mathf.Abs((float)bd - 55f) * 2;
            fit += Mathf.Abs((float)hd - 55f) * 2;
            fit += Mathf.Abs((float)fleg - 55f) * 2;
            fit += Mathf.Abs((float)bleg - 55f) * 2;
        }
        
        else
        {
            fit += 400;
            fit -= (float)bd;
            fit -= (float)hd;
            fit -= (float)fleg;
            fit -= (float)bleg;
        }

        


        if (foodDesire == 0)
        {
            float ah = adults[i].GetComponent<AnimalMaker>().GetHeight();
            float gh = wildEnv.GetComponent<WildEnvironment>().GetGrassHeight();
            if(ah > gh)
            {
                fit += Mathf.Abs((ah - gh)) * 10;
            }
        }
        else if (foodDesire == 1)
        {
            float ah = adults[i].GetComponent<AnimalMaker>().GetHeight();
            float gh = wildEnv.GetComponent<WildEnvironment>().GetTreeHeight();
            if(ah < gh)
            {
                fit += Mathf.Abs(gh - ah) * 10;
            }
        }
        
        adults[i].GetComponent<Genome>().SetFitness(fit);


    }



    // Update is called once per frame
    void Update()
    {
        
        if (!paused && !waiting)
        {

            
            NewGeneration();
            numEpochs++;
            StartCoroutine(WaitABit());
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fitnessDesires.GenerateSpecies();
        }
        */
    }

    void NewGeneration()
    {
        OrderByFitness();
        //store current children so they don't get erased
        holder = children;
        AgeChildren();

        int newGenNumber = 0;
        for (int i = 0; i < generationSize; i++)
        {
            //create baby
            //try different parent selectors!
            int Parent1 = RouletteSelection();
            int Parent2 = RouletteSelection();
            Mate(Parent1, Parent2, newGenNumber);
            newGenNumber++;
        }
        //new gen number should now be 50, replace parents with children!!
        
        for (int i = 0; i < generationSize; i++)
        {
            for (int j = 0; j < adults[1].GetComponent<Genome>().GetNumOfGenes(); j++)
            {
                adults[i].GetComponent<Genome>().SetGene(j, potentialChildren[i].GetComponent<Genome>().genes[j].GetComponent<Gene>().geneData);
            }
                    
        }
        //AgeChildren();
        SetNewChildren();
        ChangeColours();
        //Debug.Log(wildEnv.GetComponent<WildEnvironment>().GetGrassHeight());
        //Debug.Log(wildEnv.GetComponent<WildEnvironment>().GetTreeHeight());
    }

    int RouletteSelection()
    {
        float fitness_total = 0;
        for (int i = 0; i < (generationSize / 2); i++)
        {
            fitness_total += adults[i].GetComponent<Genome>().GetFitness();
        }
        //choose random float between 0 and fitness total
        float random_length_in = UnityEngine.Random.Range(0, fitness_total);

        //loop through again ig
        fitness_total = 0;
        for (int i = 0; i < (generationSize / 2); i++)
        {
            fitness_total += adults[i].GetComponent<Genome>().GetFitness();
            if (fitness_total > random_length_in)
            {
                return i;
            }
        }

        return 0;
    }

    void Mate(int Parent1, int Parent2, int num)
    {
        //mating is now per gene
        for(int i = 0; i < adults[Parent1].GetComponent<Genome>().GetNumOfGenes(); i++)
        {
            if(adults[Parent1].GetComponent<Genome>().GetCrossover(i) == 0)
            {
                //Do normal crossover
                Crossover(Parent1, Parent2, i, num);
                Mutate(Parent1, i, num, adults[Parent1].GetComponent<Genome>().GetMutationType(i));
            }
        }
    }

    void Crossover(int Parent1, int Parent2, int gene, int num)
    {
        int geneLength = adults[Parent1].GetComponent<Genome>().GetLength(gene);
        int randomPoint = Random.Range(0, geneLength);
        int[] tempArray = new int[geneLength];
        for (int i = 0; i < geneLength; i++)
        {
            if(i < randomPoint)
            {
                tempArray[i] = adults[Parent1].GetComponent<Genome>().GetGene(gene, i);
            }
            else
            {
                tempArray[i] = adults[Parent2].GetComponent<Genome>().GetGene(gene, i);
            }
        }
        potentialChildren[num].GetComponent<Genome>().SetGene(gene, tempArray);
    }

    void Mutate(int Parent1, int gene, int num, int mutateType)
    {
        int geneLength = potentialChildren[num].GetComponent<Genome>().GetLength(gene);
        float randNum = 0;
        float percentage;
        if(mutateType == 1)
        {
            percentage = 0.9f;
        }
        else
        {
            percentage = 0.98f;
        }

        
        for(int i = 0; i < geneLength; i++)
        {
            randNum = Random.Range(0.0f, 1.0f);
            if(randNum > percentage)
            {
                potentialChildren[num].GetComponent<Genome>().Mutate(gene, i);
            }
        }
    }

    void OrderByFitness()
    {
        for (int i = 0; i < generationSize; i++)
        {
            CheckFit(i);
        }
        adults = adults.OrderBy(x => x.GetComponent<Genome>().GetFitness()).ToArray();
        //children = children.OrderBy(x => x.GetComponent<Genome>().GetFitness()).ToArray();
    }

    IEnumerator WaitABit()
    {
        waiting = true;
        yield return new WaitForSeconds(waitSpeed);
        waiting = false;
    }


    void ChangeColours()
    {
        for (int i = 0; i < generationSize; i++)
        {
            float r = (float)adults[i].GetComponent<Genome>().GetColour(0) / 255;
            float g = (float)adults[i].GetComponent<Genome>().GetColour(1) / 255;
            float b = (float)adults[i].GetComponent<Genome>().GetColour(2) / 255;
            float ht = (float)adults[i].GetComponent<Genome>().GetHeight();
            int bd = adults[i].GetComponent<Genome>().GetBody();           
            int hd = adults[i].GetComponent<Genome>().GetHead();
            int bleg = adults[i].GetComponent<Genome>().GetBleg();
            int fleg = adults[i].GetComponent<Genome>().GetFleg();

            adults[i].GetComponent<AnimalMaker>().UpdateImage(r, g, b, 0, ht, bd, hd, bleg, fleg);
            float off = adults[i].GetComponent<AnimalMaker>().GetOffset();
            adults[i].transform.position = new Vector3(adults[i].transform.position.x, this.transform.position.y + off, adults[i].transform.position.z);

            r = (float)children[i].GetComponent<Genome>().GetColour(0) / 255;
            g = (float)children[i].GetComponent<Genome>().GetColour(1) / 255;
            b = (float)children[i].GetComponent<Genome>().GetColour(2) / 255;
            ht = (float)children[i].GetComponent<Genome>().GetHeight();
            bd = children[i].GetComponent<Genome>().GetBody();
            hd = children[i].GetComponent<Genome>().GetHead();
            bleg = children[i].GetComponent<Genome>().GetBleg();
            fleg = children[i].GetComponent<Genome>().GetFleg();

            children[i].GetComponent<AnimalMaker>().UpdateImage(r, g, b, 1, ht, bd, hd, bleg, fleg);
            off = children[i].GetComponent<AnimalMaker>().GetOffset();
            children[i].transform.position = new Vector3(children[i].transform.position.x, this.transform.position.y + off, children[i].transform.position.z);
        }
    }

    void CalculatePopulationFitness()
    {

    }
    
    void AgeChildren()
    {
        for (int i = 0; i < generationSize; i++)
        {
            adults[i].transform.position = holder[i].transform.position;
            //float off = children[i].GetComponent<AnimalMaker>().GetOffset();
            //children[i].transform.position = new Vector3(UnityEngine.Random.Range(min.transform.position.x, max.transform.position.x), transform.position.y + off, UnityEngine.Random.Range(min.transform.position.z, max.transform.position.z));
            for (int j = 0; j < adults[1].GetComponent<Genome>().GetNumOfGenes(); j++)
            {
                adults[i].GetComponent<Genome>().SetGene(j, children[i].GetComponent<Genome>().genes[j].GetComponent<Gene>().geneData);
                //children[i].GetComponent<Genome>().SetGene(j, potentialChildren[i].GetComponent<Genome>().genes[j].GetComponent<Gene>().geneData);
            }

        }
        for (int i = 0; i < generationSize; i++)
        {
            CheckFit(i);
        }
        OrderByFitness();
    }

    void SetNewChildren()
    {
        for (int i = 0; i < generationSize; i++)
        {
            float off = children[i].GetComponent<AnimalMaker>().GetOffset();
            children[i].transform.position = new Vector3(UnityEngine.Random.Range(min.transform.position.x, max.transform.position.x), transform.position.y + off, UnityEngine.Random.Range(min.transform.position.z, max.transform.position.z));
            for (int j = 0; j < adults[1].GetComponent<Genome>().GetNumOfGenes(); j++)
            {
                children[i].GetComponent<Genome>().SetGene(j, potentialChildren[i].GetComponent<Genome>().genes[j].GetComponent<Gene>().geneData);
            }
        }
    }


    public void ChangeBreedingSpeed(int f)
    {
        switch (f)
        {
            case 0:
                waitSpeed = 5.0f;
                break;
            case 1:
                waitSpeed = 2.5f;
                break;
            case 2:
                waitSpeed = 1.0f;
                break;
            case 3:
                waitSpeed = 0.5f;
                break;
            case 4:
                waitSpeed = 0.001f;
                break;
            case 10:
                paused = !paused;
                break;
            default:
                //waitSpeed = waitSpeed;
                break;
        }
    }

    public void PauseMovement()
    {
        for (int i = 0; i < generationSize; i++)
        {
            adults[i].GetComponent<AnimalMover>().Pause();
            children[i].GetComponent<AnimalMover>().Pause();
        }
    }

    public void OnlyPause()
    {
        paused = true;
        for (int i = 0; i < generationSize; i++)
        {
            adults[i].GetComponent<AnimalMover>().OnlyPause();
            children[i].GetComponent<AnimalMover>().OnlyPause();
        }
    }

    public bool GetPaused()
    {
        return paused;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranch : MonoBehaviour
{
    [SerializeField] GameObject max;
    [SerializeField] GameObject min;
    [SerializeField] GameObject b1;
    [SerializeField] GameObject b2;
    GameObject AnimalTemplate;
    GameObject TempAnimal;

    GameObject selected1;
    GameObject selected2;

    GameObject childHolder;
    GameObject childHolder2;
    GameObject childHolder3;
    GameObject childHolder4;
    GameObject childHolder5;
    int oddEven = 1;
    int numOfAnimals = 0;
    List<GameObject> animals;
    // Start is called before the first frame update
    void Start()
    {
        AnimalTemplate = Resources.Load("Animal", typeof(GameObject)) as GameObject;
        TempAnimal = Instantiate(AnimalTemplate);
        TempAnimal.GetComponent<AnimalMover>().enabled = false;
        TempAnimal.transform.position = new Vector3(1000, 1000, 1000);
        childHolder = Instantiate(AnimalTemplate);
        childHolder.GetComponent<AnimalMover>().enabled = false;
        childHolder.transform.position = new Vector3(1000, 1000, 1000);
        childHolder2 = Instantiate(AnimalTemplate);
        childHolder2.GetComponent<AnimalMover>().enabled = false;
        childHolder2.transform.position = new Vector3(1000, 1000, 1000);
        childHolder3 = Instantiate(AnimalTemplate);
        childHolder3.GetComponent<AnimalMover>().enabled = false;
        childHolder3.transform.position = new Vector3(1000, 1000, 1000);
        childHolder4 = Instantiate(AnimalTemplate);
        childHolder4.GetComponent<AnimalMover>().enabled = false;
        childHolder4.transform.position = new Vector3(1000, 1000, 1000);
        childHolder5 = Instantiate(AnimalTemplate);
        childHolder5.GetComponent<AnimalMover>().enabled = false;
        childHolder5.transform.position = new Vector3(1000, 1000, 1000);
        animals = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SSendToRanch(GameObject animal)
    {
        GameObject Animal = TempAnimal;
        Animal.name = "Animal number " + numOfAnimals;
        
        Animal.AddComponent<Genome>();
        Animal.GetComponent<Genome>().Init();
        Animal.GetComponent<AnimalMover>().enabled = false;
        Genome scr = Animal.GetComponent<Genome>();
        Genome other = animal.GetComponent<Genome>();

        for (int i = 0; i < scr.GetNumOfGenes(); i++)
        {
            int[] temp = new int[scr.GetLength(i)];
            for(int j = 0; j < scr.GetLength(i); j++)
            {
                temp[j] = other.GetGene(i, j);

            }
            Animal.GetComponent<Genome>().SetGene(i, temp);
            
        }
        Animal.transform.parent = this.gameObject.transform;
        animals.Add(Animal);
        float r = (float)scr.GetColour(0)/255;
        float g = (float)scr.GetColour(1) / 255;
        float b = (float)scr.GetColour(2) / 255;
        float ht = (float)scr.GetHeight();
        int bd = scr.GetBody();
        int hd = scr.GetBody();
        int bl = scr.GetBody();
        int fl = scr.GetBody();
        Animal.GetComponent<AnimalMaker>().UpdateImage(r,g,b, 0, ht, bd, hd, bl, fl);

        Animal.transform.position = new Vector3(UnityEngine.Random.Range(max.transform.position.x, min.transform.position.x), transform.position.y + Animal.GetComponent<AnimalMaker>().GetOffset(), UnityEngine.Random.Range(max.transform.position.z, min.transform.position.z));

        TempAnimal = Instantiate(AnimalTemplate);
        TempAnimal.GetComponent<AnimalMover>().enabled = false;
        TempAnimal.transform.position = new Vector3(1000, 1000, 1000);

    }


    public void Select(GameObject animal)
    {
        if(oddEven == 1)
        {
            if(selected1 != null)
            {
                selected1.transform.position = new Vector3(UnityEngine.Random.Range(max.transform.position.x, min.transform.position.x), transform.position.y + animal.GetComponent<AnimalMaker>().GetOffset(), UnityEngine.Random.Range(max.transform.position.z, min.transform.position.z));
            }
            //move current selection to pen
            if(selected2 != animal)
            {
                selected1 = animal;
                selected1.transform.position = new Vector3(b1.transform.position.x, b1.transform.position.y + animal.GetComponent<AnimalMaker>().GetOffset(), b1.transform.position.z);
                oddEven = 2;
            }

        }
        else if(oddEven == 2)
        {
            if(selected2 != null)
            {
                selected2.transform.position = new Vector3(UnityEngine.Random.Range(max.transform.position.x, min.transform.position.x), transform.position.y + animal.GetComponent<AnimalMaker>().GetOffset(), UnityEngine.Random.Range(max.transform.position.z, min.transform.position.z));
            }
            if(selected1 != animal)
            {
                selected2 = animal;
                selected2.transform.position = new Vector3(b2.transform.position.x, b2.transform.position.y + animal.GetComponent<AnimalMaker>().GetOffset(), b2.transform.position.z);
                oddEven = 1;
            }

        }

    }

    public void Breed()
    {
        if(selected1 != null && selected2 != null)
        {
        //ui box showing potential babbies and 'r u sure'
        if(CanTheyBreed())
            {
                Mate();
            }
        }


        //unselect both

    }

    bool CanTheyBreed()
    {
        if(selected1 == selected2)
        {
            return false;
        }
        return true;
    }

    void Mate()
    {
        int numChildren = Random.Range(1, 6);
        GameObject Child;
        for (int n = 0; n < numChildren; n++)
        {
            switch (n)
            {
                case 0:
                    Child = childHolder;
                    break;
                case 1:
                    Child = childHolder2;
                    break;
                case 2:
                    Child = childHolder3;
                    break;
                case 3:
                    Child = childHolder4;
                    break;
                case 4:
                    Child = childHolder5;
                    break;
                default:
                    Child = childHolder;
                    break;
            }

                


            Child.name = "Animal number " + numOfAnimals;

            Child.AddComponent<Genome>();
            Child.GetComponent<Genome>().Init();
            Child.GetComponent<AnimalMover>().enabled = false;




            for (int i = 0; i < selected1.GetComponent<Genome>().GetNumOfGenes(); i++)
            {
                if (selected1.GetComponent<Genome>().GetCrossover(i) == 0)
                {
                    //Do normal crossover
                    Crossover(i, Child);
                    Mutate(i, Child, selected1.GetComponent<Genome>().GetMutationType(i));
                }
            }

            MakeChild(Child, n);



        }









    }

    void Crossover(int gene, GameObject child)
    {
        int geneLength = selected1.GetComponent<Genome>().GetLength(gene);
        int randomPoint = Random.Range(0, geneLength);
        int[] tempArray = new int[geneLength];
        for (int i = 0; i < geneLength; i++)
        {
            if (i < randomPoint)
            {
                tempArray[i] = selected1.GetComponent<Genome>().GetGene(gene, i);
            }
            else
            {
                tempArray[i] = selected2.GetComponent<Genome>().GetGene(gene, i);
            }
        }
        child.GetComponent<Genome>().SetGene(gene, tempArray);
    }

    void Mutate(int gene, GameObject child ,int mutateType)
    {
        int geneLength = child.GetComponent<Genome>().GetLength(gene);
        float randNum = 0;
        float percentage;
        if (mutateType == 1)
        {
            percentage = 0.9f;
        }
        else
        {
            percentage = 0.98f;
        }


        for (int i = 0; i < geneLength; i++)
        {
            randNum = Random.Range(0.0f, 1.0f);
            if (randNum > percentage)
            {
                child.GetComponent<Genome>().Mutate(gene, i);
            }
        }
    }

    void MakeChild(GameObject child, int i)
    {
        child.transform.parent = this.gameObject.transform;
        animals.Add(child);
        Genome scr = child.GetComponent<Genome>();
        float r = (float)scr.GetColour(0) / 255;
        float g = (float)scr.GetColour(1) / 255;
        float b = (float)scr.GetColour(2) / 255;
        float ht = (float)scr.GetHeight();
        int bd = scr.GetBody();
        int hd = scr.GetBody();
        int bl = scr.GetBody();
        int fl = scr.GetBody();
        child.GetComponent<AnimalMaker>().UpdateImage(r, g, b, 0, ht, bd, hd, bl, fl);

        child.transform.position = new Vector3(UnityEngine.Random.Range(max.transform.position.x, min.transform.position.x), transform.position.y + child.GetComponent<AnimalMaker>().GetOffset(), UnityEngine.Random.Range(max.transform.position.z, min.transform.position.z));


        switch (i)
        {
            case 0:
                childHolder = Instantiate(AnimalTemplate);
                childHolder.GetComponent<AnimalMover>().enabled = false;
                childHolder.transform.position = new Vector3(1000, 1000, 1000);
                break;
            case 1:
                childHolder2 = Instantiate(AnimalTemplate);
                childHolder2.GetComponent<AnimalMover>().enabled = false;
                childHolder2.transform.position = new Vector3(1000, 1000, 1000);
                break;
            case 2:
                childHolder3 = Instantiate(AnimalTemplate);
                childHolder3.GetComponent<AnimalMover>().enabled = false;
                childHolder3.transform.position = new Vector3(1000, 1000, 1000);
                break;
            case 3:
                childHolder4 = Instantiate(AnimalTemplate);
                childHolder4.GetComponent<AnimalMover>().enabled = false;
                childHolder4.transform.position = new Vector3(1000, 1000, 1000);
                break;
            case 4:
                childHolder5 = Instantiate(AnimalTemplate);
                childHolder5.GetComponent<AnimalMover>().enabled = false;
                childHolder5.transform.position = new Vector3(1000, 1000, 1000);
                break;
            default:
                childHolder = Instantiate(AnimalTemplate);
                childHolder.GetComponent<AnimalMover>().enabled = false;
                childHolder.transform.position = new Vector3(1000, 1000, 1000);
                break;
        }
    }

    public void DestroyAnimal(GameObject asdf)
    {
        if(selected1 == asdf)
        {
            selected1 = null;
            oddEven = 1;
        }
        else if(selected2 == asdf)
        {
            selected2 = null;
            oddEven = 2;
        }
    }


    public void Clear()
    {
        selected1 = null;
        selected2 = null;

        foreach(var x in animals)
        {
            Destroy(x);
        }
        animals.Clear();
    }

}

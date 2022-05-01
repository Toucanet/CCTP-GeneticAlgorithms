using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Text colour;
    [SerializeField] Text age;
    [SerializeField] Text diet;
    [SerializeField] Text height;
    [SerializeField] Text aggro;
    [SerializeField] Image colour2;
    [SerializeField] GameObject ranch;
    [SerializeField] GameObject clickedOnAnimal;
    [SerializeField] GameObject wildStuff;
    [SerializeField] GameObject ranchStuff;

    [SerializeField] GameObject panel2;
    [SerializeField] Text colour3;
    [SerializeField] Image colour4;
    [SerializeField] Text age2;
    [SerializeField] Text height2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColour(Color col)
    {
        string colname = ColorUtility.ToHtmlStringRGB(col);
        colour.text = "Colour: #" + colname;
        colour2.color = col;

    }

    public void ChangeAge(bool ad)
    {
        if(ad)
        {
            age.text = "Age: Adult";
        }
        else
        {
            age.text = "Age: Juvenile";
        }
    }

    public void ChangeDiet(int d)
    {
        if (d==0)
        {
            diet.text = "Diet: Herbivore (Grass)";
        }
        else if (d==1)
        {
            diet.text = "Diet: Herbivore (Tree)";
        }
        else
        {
            diet.text = "Diet: Carnivore";
        }
    }

    public void ChangeHeight(float h)
    {
        height.text = "Height: " + h;
    }

    public void ChangeAggro(int a)
    {
        if (a == 0)
        {
            aggro.text = "Agression: Very Low";
        }
        else if (a == 1)
        {
            aggro.text = "Aggression: Low";
        }
        else if (a==2)
        {
            aggro.text = "Aggression: Medium";
        }
        else if (a==3)
        {
            aggro.text = "Aggression: High";
        }
        else
        {
            aggro.text = "Aggression: Very High";
        }
    }

    public void Enable()
    {
        if(!panel.activeSelf)
        {
            panel.SetActive(true);
        }
    }

    public void Disable()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
    }

    public void SetAnimalReference(GameObject aaa)
    {
        clickedOnAnimal = aaa;
    }

    public void SendToRanch()
    {
        ranch.GetComponent<Ranch>().SSendToRanch(clickedOnAnimal);
        clickedOnAnimal.transform.position = new Vector3(1000, 1000, 1000);
    }

    public void MoveToBreedPen()
    {
        ranch.GetComponent<Ranch>().Select(clickedOnAnimal);
    }

    public void SwapLocation(int i)
    {
        if(i==0)
        {
            //to ranch
            wildStuff.SetActive(false);
            ranchStuff.SetActive(true);
        }
        else
        {
            //to wild
            wildStuff.SetActive(true);
            ranchStuff.SetActive(false);
        }
    }




    public void ChangeColour2(Color col)
    {
        string colname = ColorUtility.ToHtmlStringRGB(col);
        colour3.text = "Colour: #" + colname;
        colour4.color = col;

    }

    public void ChangeAge2(bool ad)
    {
        if (ad)
        {
            age2.text = "Age: Adult";
        }
        else
        {
            age2.text = "Age: Juvenile";
        }
    }


    public void ChangeHeight2(float h)
    {
        height2.text = "Height: " + h;
    }



    public void Enable2()
    {
        if (!panel2.activeSelf)
        {
            panel2.SetActive(true);
        }
    }

    public void Disable2()
    {
        if (panel2.activeSelf)
        {
            panel2.SetActive(false);
        }
    }

    public void DestroyAnimal()
    {
        ranch.GetComponent<Ranch>().DestroyAnimal(clickedOnAnimal);
        Destroy(clickedOnAnimal);
    }

    public void ClearList()
    {
        Disable2();
        ranch.GetComponent<Ranch>().Clear();
        clickedOnAnimal = null;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputZone : MonoBehaviour
{
    [SerializeField] GameObject ui;
    [SerializeField] GameObject stateHolder;
    [SerializeField] GameObject natSel1;
    [SerializeField] GameObject natSel2;
    [SerializeField] GameObject natSel3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000000))
            {
                if(hit.collider.gameObject.CompareTag("BodyPart"))
                {
                        ClickedOnAnimal(hit.collider.gameObject.transform.parent.parent.parent.gameObject);
                    
                }
            }
        }
    }

    void ClickedOnAnimal(GameObject animal)
    {
        //pause all nat selections
        natSel1.GetComponent<NaturalSelection>().OnlyPause();
        natSel2.GetComponent<NaturalSelection>().OnlyPause();
        natSel3.GetComponent<NaturalSelection>().OnlyPause();

        UI scr = ui.GetComponent<UI>();

        scr.SetAnimalReference(animal);

        if (stateHolder.GetComponent<stateHolder>().GetState() == 0)
        {
            scr.Disable2();
            scr.Enable();
            //age
            if (animal.name.StartsWith("A"))
            {
                scr.ChangeAge(true);
            }
            else
            {
                scr.ChangeAge(false);
            }

            //height

            scr.ChangeHeight(animal.GetComponent<AnimalMaker>().GetHeight());

            //colour
            float r, g, b;
            r = (float)animal.GetComponent<Genome>().GetColour(0) / 255;
            g = (float)animal.GetComponent<Genome>().GetColour(1) / 255;
            b = (float)animal.GetComponent<Genome>().GetColour(2) / 255;
            //string colname = ColorUtility.ToHtmlStringRGB(new Color(r, g, b));
            scr.ChangeColour(new Color(r, g, b));

            //diet
            scr.ChangeDiet(animal.transform.GetComponentInParent<FitnessDesires>().GetFoodDesire());

            //aggro level
            scr.ChangeAggro(animal.transform.GetComponentInParent<FitnessDesires>().GetAggro());

            //average body type
        }

        else
        {
            scr.Disable();
            scr.Enable2();
            //age
            if (animal.name.StartsWith("A"))
            {
                scr.ChangeAge2(true);
            }
            else
            {
                scr.ChangeAge2(false);
            }

            //height

            scr.ChangeHeight2(animal.GetComponent<AnimalMaker>().GetHeight());

            //colour
            float r, g, b;
            r = (float)animal.GetComponent<Genome>().GetColour(0) / 255;
            g = (float)animal.GetComponent<Genome>().GetColour(1) / 255;
            b = (float)animal.GetComponent<Genome>().GetColour(2) / 255;
            //string colname = ColorUtility.ToHtmlStringRGB(new Color(r, g, b));
            scr.ChangeColour2(new Color(r, g, b));
            //average body type
        }




    }
}

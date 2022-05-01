using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleNatSelectionHolder : MonoBehaviour
{
    //create random number of nat selections
    //deal with pauses/speed changes
    [SerializeField] GameObject natSel1;
    [SerializeField] GameObject natSel2;
    [SerializeField] GameObject natSel3;
    [SerializeField] GameObject natSel4;
    [SerializeField] GameObject natSel5;
    [SerializeField] GameObject natSel6;
    List<GameObject> natSelections;
    // Start is called before the first frame update
    void Start()
    {
        natSelections = new List<GameObject>();
        int randomNum = Random.Range(3, 6);
        for(int i = 0; i < 1; i++)
        {
            if(i==0)
            {
                natSel1.SetActive(true);
                natSelections.Add(natSel1);
            }
            if(i==1)
            {
                natSel2.SetActive(true);
                natSelections.Add(natSel2);
            }
            if(i==2)
            {
                natSel3.SetActive(true);
                natSelections.Add(natSel3);
            }
            if(i==3)
            {
                natSel4.SetActive(true);
                natSelections.Add(natSel4);
            }
            if(i==4)
            {
                natSel5.SetActive(true);
                natSelections.Add(natSel5);
            }
            if(i==5)
            {
                natSel6.SetActive(true);
                natSelections.Add(natSel6);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NatSelecSpeedChange(int s)
    {
        foreach(GameObject x in natSelections)
        {
            x.GetComponent<NaturalSelection>().ChangeBreedingSpeed(s);
        }

    }

    public void NatSelecPause()
    {
        foreach (GameObject x in natSelections)
        {
            x.GetComponent<NaturalSelection>().PauseMovement();
        }
    }
}

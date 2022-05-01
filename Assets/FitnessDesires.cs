using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitnessDesires : MonoBehaviour
{
    //stores wild fitness 'desires', ie what type of colour it wants to be, what food it wants to eat etc

    [SerializeField] int colourDesire;
    [SerializeField] int foodDesire;
    [SerializeField] int aggroLevel;

    //camo wants to be same colour as environment
    //vibrant wants to be high colour values (2 in 2 places, 1 in 1)
    //dull wants to be low colour values
    enum colourTypes
    {
        camo,
        vibrant,
        vibrant2,
        vibrant3,
        dull
    }

    //tree want to be tall enough to eat trees and bulky
    //carnivores want to be 
    //grass want to be small and fast
    enum foodTypes
    {
        grass,
        tree,
        carnivore
    }

    //run wants running feet
    //climb wants climbing hands
    //
    //hide wants smaller than grass
    enum moveType
    {
        run,
        climb,
        creep,
        hide
    }

    //higher agro = bigger horns, strength, size
    enum agressionLevel
    {
        veryHigh,
        high,
        med,
        low,
        veryLow
    }

    public void GenerateSpecies()
    {
        colourDesire = Random.Range(0, 5);
        foodDesire = Random.Range(0, 3);
        aggroLevel = Random.Range(0, 5);
    }

    public int GetColourDesire()
    {
        return colourDesire;
    }

    public int GetFoodDesire()
    {
        return foodDesire;
    }

    public int GetAggro()
    {
        return aggroLevel;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

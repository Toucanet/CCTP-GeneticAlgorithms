using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum genePositions
{
    Colour = 0, //colour for all 'white' bits
    Height = 1,
    Body = 2, //am I bipedal, what body model
    Head = 3, //model, length
    Leg = 4, //model, length
    Arm = 5 //if quadrupedal overwritten by leg type. model, length
    //Hands = 6, //if quadrupedal overwritten by foot type. model, length
    //Tail = 7, //model, tail yes/no, length
    //Horns = 8, //yes/no, model, length
    //Eyes = 9 //colour, type

}

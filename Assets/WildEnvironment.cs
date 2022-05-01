using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WildEnvironment : MonoBehaviour
{
    public float rd, grn, bl;
    //public int[] rd2, grn2, bl2;
    float height;
    GameObject[] trees;
    GameObject[] grass;
    GameObject grassTemplate;
    GameObject treeTemplate;
    int treeNumber = 50;
    int grassNumber = 750;
    [SerializeField] GameObject min;
    [SerializeField] GameObject max;
    // Start is called before the first frame update
    void Start()
    {
        grassTemplate = Resources.Load("Grass", typeof(GameObject)) as GameObject;
        treeTemplate = Resources.Load("Tree", typeof(GameObject)) as GameObject;

        GenerateGrass();
        GenerateColourFl();
        GenerateTrees();
        //treeNumber = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Regenerate();
        }
    }

    void GenerateColourFl()
    {
        int r = UnityEngine.Random.Range(0, 225);
        int g = UnityEngine.Random.Range(0, 225);
        int b = UnityEngine.Random.Range(0, 225);
        rd = (float)r/255;
        grn = (float)g/255;
        bl = (float)b/255;

        GetComponent<Renderer>().material.color = new Color(rd, grn, bl);

        for (int i = 0; i < grassNumber; i++)
        {
            grass[i].GetComponentInChildren<Renderer>().material.color = new Color(rd, grn, bl);
        }
    }

    void GenerateTemperature()
    {

    }

    void GenerateTrees()
    {
        height = UnityEngine.Random.Range(0.1f, 0.3f);
        //height = 0.2f;
        trees = new GameObject[treeNumber];
        for (int i = 0; i < treeNumber; i++)
        {
            trees[i] = Instantiate(treeTemplate);
            trees[i].transform.position = new Vector3(UnityEngine.Random.Range(min.transform.position.x, max.transform.position.x), gameObject.transform.position.y, UnityEngine.Random.Range(min.transform.position.z, max.transform.position.z));
            trees[i].transform.parent = gameObject.transform;
            trees[i].transform.localScale = new Vector3(trees[i].transform.localScale.x, height, trees[i].transform.localScale.z);

        }
    }

    void GenerateGrass()
    {
        height = UnityEngine.Random.Range(0.1f, 0.5f);
        //height = 0.1f;
        grass = new GameObject[grassNumber];
        for(int i = 0; i < grassNumber; i++)
        {
            grass[i] = Instantiate(grassTemplate);
            grass[i].transform.position = new Vector3(UnityEngine.Random.Range(min.transform.position.x, max.transform.position.x), this.transform.position.y, UnityEngine.Random.Range(min.transform.position.z, max.transform.position.z));
            grass[i].transform.parent = gameObject.transform;
            grass[i].transform.localScale = new Vector3(grass[i].transform.localScale.x, height, grass[i].transform.localScale.z);
            
        }
    }

    void ChangeFloraHeight()
    {
        height = UnityEngine.Random.Range(0.1f, 0.35f);
        for (int i = 0; i < treeNumber; i++)
        {
            trees[i].transform.localScale = new Vector3(trees[i].transform.localScale.x, height, trees[i].transform.localScale.z);
        }
        height = UnityEngine.Random.Range(0.1f, 0.5f);
        for(int i = 0; i < grassNumber; i++)
        {
            grass[i].transform.localScale = new Vector3(grass[i].transform.localScale.x, height, grass[i].transform.localScale.z);
        }
    }


    void Regenerate()
    {
        GenerateColourFl();
        ChangeFloraHeight();
    }

    public Vector3 GetColour()
    {
        return new Vector3(rd, grn, bl);
    }

    public float GetGrassHeight()
    {
        float dist = Vector3.Distance(grass[0].transform.position, grass[0].transform.GetChild(1).transform.position);
        return dist;
    }

    public float GetTreeHeight()
    {
        float dist = Vector3.Distance(trees[0].transform.position, trees[0].transform.GetChild(0).transform.position);
        return dist;
    }








}

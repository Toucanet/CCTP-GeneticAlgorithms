using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMaker : MonoBehaviour
{

    [SerializeField] GameObject body;
    [SerializeField] GameObject fLeg;
    [SerializeField] GameObject bLeg;
    [SerializeField] GameObject head;
    [SerializeField] GameObject neck;
    [SerializeField] Material nml;
    [SerializeField] Material pwr;
    [SerializeField] Material spd;
    [SerializeField] Material blk;
    int aggro;
    int diet;
    float offset = 0;
    GameObject groundLevel;
    GameObject holder;
    GameObject top;

    // Start is called before the first frame update
    void Start()
    {
        holder = this.transform.GetChild(0).gameObject;
        holder.transform.position = this.transform.position;
        GameObject asdf = Resources.Load("BodyParts/___TestParts/Body", typeof(GameObject)) as GameObject;
        body = Instantiate(asdf);
        body.transform.parent = holder.transform;
        GameObject asdfg = Resources.Load("BodyParts/___TestParts/FrontLeg", typeof(GameObject)) as GameObject;
        fLeg = Instantiate(asdfg);
        fLeg.transform.parent = holder.transform;

        GameObject asdfgh = Resources.Load("BodyParts/___TestParts/BackLeg", typeof(GameObject)) as GameObject;
        bLeg = Instantiate(asdfgh);
        bLeg.transform.parent = holder.transform;
        
        GameObject asdfghj = Resources.Load("BodyParts/___TestParts/Head", typeof(GameObject)) as GameObject;
        head = Instantiate(asdfghj);
        head.transform.parent = holder.transform;

        GameObject asdfghjk = Resources.Load("BodyParts/___TestParts/Neck", typeof(GameObject)) as GameObject;
        neck = Instantiate(asdfghjk);
        neck.transform.parent = holder.transform;

        body.transform.position = this.transform.position;
        fLeg.transform.position = body.transform.GetChild(2).transform.position;
        bLeg.transform.position = body.transform.GetChild(1).transform.position;
        neck.transform.position = body.transform.GetChild(3).transform.position;

        head.transform.position = neck.transform.GetChild(1).transform.position;

        Vector3 rot = new Vector3(30, 0, 0);
        transform.Rotate(transform.right, 30);
        groundLevel = bLeg.transform.GetChild(1).gameObject;
        top = head.transform.GetChild(1).gameObject;
        UpdateOffset();
    }

    //change this to one update function
    public void ChangeColours(float r, float g, float b)
    {
        Color color = new Color(r, g, b);
        body.transform.GetChild(0).GetComponent<Renderer>().material.color = color;
        fLeg.transform.GetChild(0).GetComponent<Renderer>().material.color = color;
        bLeg.transform.GetChild(0).GetComponent<Renderer>().material.color = color;
        neck.transform.GetChild(0).GetComponent<Renderer>().material.color = color;
        head.transform.GetChild(0).GetComponent<Renderer>().material.color = color;
    }


    public void UpdateImage(float r, float g, float b, int child, float ht, int bd, int hd, int bl, int fl)
    {
        ChangeBody(bd);
        ChangeHead(hd);
        ChangeFleg(fl);
        ChangeBleg(bl);
        ChangeHeight(child, ht);
        ChangeColours(r, g, b);

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeChild()
    {
        //scaler = scale/2
        Vector3 scaler = new Vector3(0.5f, 0.5f, 0.5f);
        body.transform.localScale = scaler;
        fLeg.transform.localScale = scaler;
        bLeg.transform.localScale = scaler;
        head.transform.localScale = scaler;
        neck.transform.localScale = scaler;
        body.transform.position = this.transform.position;
        fLeg.transform.position = body.transform.GetChild(2).transform.position;
        bLeg.transform.position = body.transform.GetChild(1).transform.position;
        neck.transform.position = body.transform.GetChild(3).transform.position;
        head.transform.position = neck.transform.GetChild(1).transform.position;
    }

    void ChangeHeight(int child, float height)
    {
        float heightScale = 1;
        //min height = 0.4f;
        //max height = 10f;
        if(height < 10)
        {
            heightScale = 0.4f;
        }
        else if(height > 24)
        {
            heightScale = 7f;
        }
        else if (height<=16)
        {
            heightScale = 0.4f + (0.1f * (height - 9));
        }
        else
        {
            heightScale = GetScaler(height);
        }
        //heightScale = 6.5f;
        Vector3 scaler = new Vector3(1f, heightScale, 1f);
        if(child == 1)
        {
            scaler = new Vector3(0.5f, heightScale / 2, 0.5f);
            Vector3 other = new Vector3(0.5f, 0.5f, 0.5f);
            body.transform.localScale = other;
            fLeg.transform.localScale = scaler;
            bLeg.transform.localScale = scaler;
            head.transform.localScale = other;
            neck.transform.localScale = scaler;
        }
        else
        {
            fLeg.transform.localScale = scaler;
            bLeg.transform.localScale = scaler;
            neck.transform.localScale = scaler;
        }

        body.transform.position = this.transform.position;
        fLeg.transform.position = body.transform.GetChild(2).transform.position;
        bLeg.transform.position = body.transform.GetChild(1).transform.position;
        neck.transform.position = body.transform.GetChild(3).transform.position;
        head.transform.position = neck.transform.GetChild(1).transform.position;
    }

    void ChangeBody(int x)
    {
        if(x==0)
        {
            body.transform.GetChild(0).GetComponent<Renderer>().material = spd;
        }
        else if (x==1)
        {
            body.transform.GetChild(0).GetComponent<Renderer>().material = nml;
        }
        else if (x==2)
        {
            body.transform.GetChild(0).GetComponent<Renderer>().material = blk;
        }
        else
        {
            body.transform.GetChild(0).GetComponent<Renderer>().material = pwr;
        }
    }

    void ChangeFleg(int x)
    {
        if (x == 0)
        {
            fLeg.transform.GetChild(0).GetComponent<Renderer>().material = spd;
        }
        else if (x == 1)
        {
            fLeg.transform.GetChild(0).GetComponent<Renderer>().material = nml;
        }
        else if (x == 2)
        {
            fLeg.transform.GetChild(0).GetComponent<Renderer>().material = blk;
        }
        else
        {
            fLeg.transform.GetChild(0).GetComponent<Renderer>().material = pwr;
        }
    }

    void ChangeBleg(int x)
    {
        if (x == 0)
        {
            bLeg.transform.GetChild(0).GetComponent<Renderer>().material = spd;
        }
        else if (x == 1)
        {
            bLeg.transform.GetChild(0).GetComponent<Renderer>().material = nml;
        }
        else if (x == 2)
        {
            bLeg.transform.GetChild(0).GetComponent<Renderer>().material = blk;
        }
        else
        {
            bLeg.transform.GetChild(0).GetComponent<Renderer>().material = pwr;
        }
    }

    void ChangeHead(int x)
    {
        if (x == 0)
        {
            head.transform.GetChild(0).GetComponent<Renderer>().material = spd;
        }
        else if (x == 1)
        {
            head.transform.GetChild(0).GetComponent<Renderer>().material = nml;
        }
        else if (x == 2)
        {
            head.transform.GetChild(0).GetComponent<Renderer>().material = blk;
        }
        else
        {
            head.transform.GetChild(0).GetComponent<Renderer>().material = pwr;
        }
    }

    void UpdateOffset()
    {
        offset = Vector3.Distance(transform.position, groundLevel.transform.position);
    }

    public float GetOffset()
    {
        float yOff = transform.position.y - groundLevel.transform.position.y;
        return yOff;
    }

    float GetScaler(float height)
    {
        switch (height)
        {
            case 17:
                return 1.2f;
            case 18:
                return 1.6f;
            case 19:
                return 2f;
            case 20:
                return 2.8f;
            case 21:
                return 3.5f;
            case 22:
                return 4.2f;
            case 23:
                return 5.5f;
            case 24:
                return 6;
            default:
                return 1;
        }
    }

    public float GetHeight()
    {
        float dist = Vector3.Distance(groundLevel.transform.position, top.transform.position);
        return dist;
    }

    public void SetDietAggro(int d, int i)
    {
        diet = d;
        aggro = i;
    }

    public int GetAggro()
    {
        return aggro;
    }

    public int GetDiet()
    {
        return diet;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class plateau : MonoBehaviour
{
    public int nbCase = 4;
    public float sizeCase = 4;

    public GameObject casePatern1;
    public GameObject casePatern2;
    public GameObject pion;
    
    public GameObject[,] cases;
    // Start is called before the first frame update
    void Start()
    {
        cases = new GameObject[nbCase,nbCase];
        for (int i = 0; i < nbCase; i++)
        {
            for (int j = 0; j < nbCase; j++)
            {
                GameObject copy;
                if ((i + j) % 2 == 0)
                {
                    copy = Instantiate(casePatern1, this.transform); 
                }
                else
                {
                    copy = Instantiate(casePatern2, this.transform);
                }

                cases[i,j] = copy;
                copy.transform.position = transform.position;
                copy.transform.Translate(new Vector3(sizeCase * i - sizeCase * (nbCase -1) / 2, 0, sizeCase * j - sizeCase * (nbCase-1) / 2), this.transform);
                copy.name = "case[" + i + "," + j + "]";
            }
        }
        
        casePatern1.SetActive(false);
        casePatern2.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        int test = (int) Time.time % (nbCase * nbCase);
        int line = test % nbCase;
        int col = test / nbCase;

        pion.transform.position = cases[col, line].transform.position;
//        pion.transform;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionCase : MonoBehaviour
{
    public Material couleurB;
    public Material couleurN;
    public Material transparent;
    public Material clique;
    public int currentC;
    public bool select;
    public bool actifs;
    public GameObject pion;
    public int ligne;
    public int colonne;
    public bool isEmpty;
    public List<GameObject> listCase;

    // Start is called before the first frame update
    void Start()
    {
        defineStartColor();
        pion = GameObject.Find("pions");
        actifs = false;
        isEmpty = true;
    }

    public void defineStartColor()
    {
        if (currentC == 0)
        {
            transform.GetComponent<MeshRenderer>().material = couleurB;

        }
        if (currentC == 1)
        {
            transform.GetComponent<MeshRenderer>().material = couleurN;

        }
    }

    public void isSelected(bool status) {
        if (status)
        {
            transform.GetComponent<MeshRenderer>().material = clique;
            foreach (GameObject tempCase in listCase)
            {
                tempCase.GetComponent<interactionCase>().isActive(true);
            }
        }
        else
        {
            defineStartColor();
            foreach (GameObject tempCase in listCase)
            {
                tempCase.GetComponent<interactionCase>().isActive(false);
            }
        }
    }

    public void isActive(bool status)
    {
        if (status)
        {
            transform.GetComponent<MeshRenderer>().material = transparent;

        }
        else
        {
            defineStartColor();
        }
        actifs = status;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Case")
        {
            if (other.transform.GetComponent<interactionCase>().ligne > ligne && other.transform.GetComponent<interactionCase>().isEmpty)
            {
                listCase.Add(other.transform.gameObject);
            }
        }
        if(other.transform.tag =="Player")
        {
            isEmpty = false;
        }
    }

    private void OnMouseDown()
    {
        if (actifs)
        {
            pion.transform.position = transform.position;
            pion.transform.Translate(new Vector3(0f, 0.1f, 0f));
            pion.GetComponent<positionCase>().Selection();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

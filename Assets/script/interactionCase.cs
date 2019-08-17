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
    public List<GameObject> listCase;

    // Start is called before the first frame update
    void Start()
    {
        defineStartColor();
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Case")
        {
            listCase.Add(other.transform.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

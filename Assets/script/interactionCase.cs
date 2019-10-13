using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionCase : MonoBehaviour
{
    public GameObject _manager;
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
        _manager = GameObject.Find("manager");
        
        defineStartColor();
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

    public void isSelected(GameObject tempPion, bool status) {
        pion = tempPion;
        if (status)
        {
            transform.GetComponent<MeshRenderer>().material = clique;
            foreach (GameObject tempCase in listCase)
            {
                if (_manager.GetComponent<manager>().currentPlayer == 0)
                {
                    if (ligne < tempCase.GetComponent<interactionCase>().ligne && tempCase.GetComponent<interactionCase>().isEmpty)
                    {
                        tempCase.GetComponent<interactionCase>().isActive(tempPion, true);
                    }
                }
                else
                {
                    if (ligne > tempCase.GetComponent<interactionCase>().ligne && tempCase.GetComponent<interactionCase>().isEmpty)
                    {
                        tempCase.GetComponent<interactionCase>().isActive(tempPion, true);
                    }
                }
            }
        }
        else
        {
            defineStartColor();
            foreach (GameObject tempCase in listCase)
            {
                tempCase.GetComponent<interactionCase>().isActive(tempPion, false);
            }
        }
    }

    public void isActive(GameObject tempPion, bool status)
    {
        pion = tempPion;
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
            listCase.Add(other.transform.gameObject);
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
            pion.GetComponent<pieceSelection>().Selection();
            _manager.GetComponent<manager>().switchPlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

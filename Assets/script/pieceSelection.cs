using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceSelection : MonoBehaviour
{
    public GameObject currentCase;
    public pieceCaracteristique Pc;
    public bool isSelected;
    public int typePiece;
    public GameObject _manager;
    
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.Find("manager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Case")
        {
            currentCase = other.transform.gameObject;
        }
    }

    private void OnMouseDown()
    {
        if (Pc.player == _manager.GetComponent<manager>().currentPlayer) {
            Selection();
        }
    }

    public void deselectAll()
    {
        GameObject[] arrayPions = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject tempPion in arrayPions)
        {
            tempPion.GetComponent<pieceSelection>().isSelected = false;
        }
        GameObject[] arrayCases = GameObject.FindGameObjectsWithTag("Case");
        foreach (GameObject tempCase in arrayCases)
        {
            tempCase.GetComponent<interactionCase>().isActive(transform.gameObject, false);
        }
    }

    public void Selection()
    {
        if (!isSelected)
        {
            deselectAll();
            currentCase.GetComponent<interactionCase>().isSelected(transform.gameObject, true);
            isSelected = true;
        }
        else
        {
            currentCase.GetComponent<interactionCase>().isSelected(transform.gameObject, false);
            isSelected = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

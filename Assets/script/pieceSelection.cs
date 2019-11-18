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
    private int nbrDeplacement;
    
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.Find("manager");
        calculDeplacement();
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

    public void deselectAll() // deselectionne les cases et pièces
    {
        GameObject[] arrayPions = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject tempPion in arrayPions)
        {
            tempPion.GetComponent<pieceSelection>().isSelected = false;
        }
        GameObject[] arrayCases = GameObject.FindGameObjectsWithTag("Case");
        foreach (GameObject tempCase in arrayCases)
        {
            tempCase.GetComponent<interactionCase>().isActive(transform.gameObject, typePiece, nbrDeplacement, false);
        }
    }

    public void calculDeplacement()
    {
        if(typePiece == 0)
        {
            nbrDeplacement = 1;
        }
        if (typePiece == 1)
        {
            nbrDeplacement = 2;
        }
        if (typePiece == 2)
        {
            nbrDeplacement = 2;
        }
    }

    /* --- Active la case sur laquelle la pièce est placée --- */
    public void Selection()
    {
        calculDeplacement();
        /* --- Selectionne la case --- */
        if (!isSelected)
        {
            deselectAll();
            currentCase.GetComponent<interactionCase>().isSelected(transform.gameObject, typePiece,nbrDeplacement, true);
            isSelected = true;
        }
        else
        /* --- Deselection lors du second clique sur la pièce --- */
        {
            currentCase.GetComponent<interactionCase>().isSelected(transform.gameObject, typePiece,nbrDeplacement, false);
            isSelected = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

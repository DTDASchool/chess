using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionCase : MonoBehaviour
{
    public GameObject currentCase;
    public bool isSelected;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        if(isSelected == false)
        {
            currentCase.GetComponent<interactionCase>().isSelected(true);
            isSelected = true;
        }
        else
        {
            currentCase.GetComponent<interactionCase>().isSelected(false);
            isSelected = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

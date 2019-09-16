using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public GameObject startCase;
    public GameObject pion;
    // Start is called before the first frame update
    void Start()
    {
        pion.transform.position = startCase.transform.position;
        pion.transform.Translate(new Vector3(0f, 0.1f, 0f));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

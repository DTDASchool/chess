using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public GameObject startCase;
    public GameObject pion;
    public int currentPlayer;
    public GameObject _camera;
    // Start is called before the first frame update
    void Start()
    {
        pion.transform.position = startCase.transform.position;
        pion.transform.Translate(new Vector3(0f, 0.1f, 0f));
        currentPlayer = 0;

    }

    public void switchPlayer()
    {
        if (currentPlayer == 0)
        {
            _camera.transform.localRotation = Quaternion.Euler(90, -90, 180);
            currentPlayer = 1;
        }
        else
        {
            currentPlayer = 0;
            _camera.transform.localRotation = Quaternion.Euler(90, 90, 180);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

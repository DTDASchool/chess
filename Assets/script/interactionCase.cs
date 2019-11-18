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
    public GameObject piece;
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
        select = false;
    }

    public void defineStartColor() // definir la couleur
    {
        if (currentC == 0)
        {
            transform.GetComponent<MeshRenderer>().material = couleurB;

        }
        if (currentC == 1)
        {
            transform.GetComponent<MeshRenderer>().material = couleurN;

        }
        select = false;
    }

    /* --- Active les cases jouables --- */
    public void isSelected(GameObject tempPiece, int typePiece, int nbrDeplacement, bool status) {
        piece = tempPiece;
        if (status && nbrDeplacement > 0)
        {
                /* --- activation de la case si non activée --- */
                if (!actifs)
                {
                    transform.GetComponent<MeshRenderer>().material = clique;
                    select = true;
                foreach (GameObject tempCase in listCase)
                {
                    /* --- si piece = Pion alors deplacement vers l'avant --- */
                    if (typePiece == 0)
                    {
                        /* --- si joueur 1 (rouge) --- */
                        if (_manager.GetComponent<manager>().currentPlayer == 0)
                        {

                            if (ligne < tempCase.GetComponent<interactionCase>().ligne && tempCase.GetComponent<interactionCase>().isEmpty)
                            {
                                tempCase.GetComponent<interactionCase>().isActive(tempPiece, typePiece, nbrDeplacement, status);
                            }
                        }

                    }
                    else
                    {
                        /* --- si joueur 2 (bleu) --- */
                        if (ligne > tempCase.GetComponent<interactionCase>().ligne && tempCase.GetComponent<interactionCase>().isEmpty)
                        {
                            tempCase.GetComponent<interactionCase>().isActive(tempPiece, typePiece, nbrDeplacement, status);
                        }
                    }
                    /* --- si piece = Tour alors deplacement en ligne --- */
                    if (typePiece == 1)
                    {
                        if ((ligne == tempCase.GetComponent<interactionCase>().ligne || colonne == tempCase.GetComponent<interactionCase>().colonne) && tempCase.GetComponent<interactionCase>().isEmpty)
                        {
                            tempCase.GetComponent<interactionCase>().isActive(tempPiece, typePiece, nbrDeplacement, status);
                        }
                    }
                    /* --- si piece = fou alors deplacement en ligne --- */
                    if (typePiece == 2)
                    {
                        if ((ligne != tempCase.GetComponent<interactionCase>().ligne && colonne != tempCase.GetComponent<interactionCase>().colonne) && tempCase.GetComponent<interactionCase>().isEmpty)
                        {
                            tempCase.GetComponent<interactionCase>().isActive(tempPiece, typePiece, nbrDeplacement, status);
                        }
                    }
                }
                }
            }
            else
            {
                /* --- Desactivation de la case --- */
                defineStartColor();
                foreach (GameObject tempCase in listCase)
                {
                    tempCase.GetComponent<interactionCase>().isActive(tempPiece, typePiece, nbrDeplacement, status);
                }
            }
    }

    public void isActive(GameObject tempPiece, int typePiece, int nbrDeplacement, bool status) // indique si la case est cliquable
    {
        piece = tempPiece;
        if (status)
        {
            transform.GetComponent<MeshRenderer>().material = transparent;

            /* --- Diffusion aux cases suivantes --- */
            //isSelected(tempPiece, typePiece, nbrDeplacement - 1, status);
        }
        else
        {
            defineStartColor();
        }
        actifs = status;
    }

    private void OnTriggerEnter(Collider other) // permet de détecter quand un collider entre sur une case
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
    private void OnTriggerExit(Collider other) // permet de détecter quand un collider quitte une case
    {
        if (other.transform.tag == "Player")
        {
            isEmpty = true;
        }
    }

    private void OnMouseDown() // selection de la case quand elle est activée
    {
        if (actifs)
        {
            piece.transform.position = transform.position;
            piece.transform.Translate(new Vector3(0f, 0.1f, 0f));
            piece.GetComponent<pieceSelection>().Selection();
            _manager.GetComponent<manager>().switchPlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

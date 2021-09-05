using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public bool isClicked;

    public float moveForward;

    public GameObject Dir1;
    public GameObject Dir2;

    // Start is called before the first frame update
    
    void Start()
    {
        isClicked = false;   
        Dir1.SetActive(false);
        Dir2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        Debug.Log("Table Clicked");
        if(isClicked){
            Dir1.SetActive(false);
            Dir2.SetActive(false);
        }else{
            Dir1.SetActive(true);
            Dir2.SetActive(true);
        }

        isClicked = !isClicked;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{

    public GameObject Table;
    public bool isClicked;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isClicked){    
            if(GetComponent<SpriteRenderer>().flipX) 
                Table.transform.Translate(new Vector2(-1*Table.GetComponent<Table>().moveForward, 0));
            else 
                Table.transform.Translate(new Vector2(Table.GetComponent<Table>().moveForward, 0));
        }
    }


    void OnMouseUp() {
        if(isClicked) return;
        Debug.Log("Dir Btn Clicked");
        isClicked = true;
        Invoke("moveOff", 1f);
    }

    void moveOff(){
        isClicked = false;
    }
}

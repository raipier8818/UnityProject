using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{   
    public GameObject target;
    public float leftBorder;
    public float rightBorder;
    public float maxHeight;
    public float minHeight;

    public float speed;
    Transform trans;
    
    Vector3 CameraPos;
    Vector3 FrontPos;
    public float Front;
    public float Back;

    void Awake(){
        CameraPos.x = target.transform.position.x;
        CameraPos.y = target.transform.position.y;
        CameraPos.z = -10f;
    }

    
    private void FixedUpdate()
    {
        if(target.GetComponent<SpriteRenderer>().flipX == true) 
            FrontPos = new Vector3(Front * -1,0,0);
        else
            FrontPos = new Vector3(Front,0,0);

        if(!Input.GetButton("Horizontal")){
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed/Back);
            
            CameraPos.x = (transform.position.x > rightBorder) ? rightBorder : transform.position.x;
            CameraPos.x = (transform.position.x < leftBorder) ? leftBorder : transform.position.x;
            CameraPos.y = (transform.position.y > maxHeight) ? maxHeight : transform.position.y;
            CameraPos.y = (transform.position.y < minHeight) ? minHeight : transform.position.y;

            transform.position = CameraPos;
        }else{
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed);
            
            CameraPos.x = (transform.position.x > rightBorder) ? rightBorder : transform.position.x;
            CameraPos.x = (transform.position.x < leftBorder) ? leftBorder : transform.position.x;
            CameraPos.y = (transform.position.y > maxHeight) ? maxHeight : transform.position.y;
            CameraPos.y = (transform.position.y < minHeight) ? minHeight : transform.position.y;

            transform.position = CameraPos + FrontPos;
        }


        // transform.position = new Vector3(transform.position.x, (transform.position.y > minHeight ? transform.position.y : maxHeight), -10f);

        // if(transform.position.x > rightBorder)
        // {
        //     transform.position = new Vector3(rightBorder, transform.position.y, transform.position.z);
        // }
        // if(transform.position.x < leftBorder)
        // {
        //     transform.position = new Vector3(leftBorder, transform.position.y, transform.position.z);
        // }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llamaMovement : MonoBehaviour
{

    private Vector3 initPosition = new Vector3(0.0f, 0.7f, 3.0f);
    private Vector3 screenPoint;
    private Vector3 offset;
    private float xLimit = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = initPosition;
    }

    // Update is called once per frame
    //void Update()
    //{
        //this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = new Vector3(worldPosition.x, transform.position.y, transform.position.z);
    //}

    void OnMouseDown()
    {
        //Debug.Log("Inside mouse down");
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        if (cursorPosition.x > xLimit)
            cursorPosition.x = xLimit;
        else if (cursorPosition.x < -xLimit)
            cursorPosition.x = -xLimit;
        transform.position = cursorPosition;
    }
}

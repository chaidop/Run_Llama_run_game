using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other){
        //Debug.Log("Hit!");
        //Debug.Log("Hit at " + transform.position.z);
        GameManagerScript.instance.AppleHit();

        Destroy(gameObject);
    }
}

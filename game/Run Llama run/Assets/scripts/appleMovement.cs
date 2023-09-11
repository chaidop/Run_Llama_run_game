using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleMovement : MonoBehaviour
{
    public float speedZ;
    public float llama_position;
    public static float spawn_pos;
    private Vector3 initPosition = new Vector3(0.0f, 0.7f, 30.0f);

    // Start is called before the first frame update
    void Start()
    {
        llama_position = 2.0f;
        //transform.position = initPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0.7f + 0.1f * Mathf.Cos(transform.position.z), transform.position.z - speedZ * Time.deltaTime);
        if (transform.position.z <= llama_position)
        {
            // Debug.Log("Game Over!");
            GameManagerScript.instance.apple_combo = 0;
            GameManagerScript.instance.scoreMultiplier = 1;
            Destroy(gameObject);
        }
    }
}

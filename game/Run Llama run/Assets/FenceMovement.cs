using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceMovement : MonoBehaviour
{
    FenceSpawn fenceSpawner;
    private int canGenerate = 1;
    public float terrainSpeed, llama_position;
    // Start is called before the first frame update
    public void Start()
    {
        fenceSpawner = GameObject.FindObjectOfType<FenceSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0.0f, 0.0f, terrainSpeed * Time.deltaTime);

        if (transform.position.z <= 30*llama_position && canGenerate == 1)
        {
            fenceSpawner.SpawnFence(transform.GetChild(2).transform.position);
            canGenerate = 0;
        }
        if (transform.position.z <= -15*llama_position)
        {
            Destroy(gameObject);
        }
    }
}

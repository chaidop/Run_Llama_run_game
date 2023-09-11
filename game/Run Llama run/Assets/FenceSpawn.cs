using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceSpawn : MonoBehaviour
{

    public GameObject fence;
    Vector3 nextSpawnPos1;
    // Start is called before the first frame update
    public void SpawnFence(Vector3 nextSpawnPos)
    {
        GameObject temp = Instantiate(fence, nextSpawnPos, Quaternion.identity);
        nextSpawnPos = temp.transform.GetChild(2).transform.position;
    }

    // Update is called once per frame
    private void Start()
    {

        SpawnFence(nextSpawnPos1);
    }
}

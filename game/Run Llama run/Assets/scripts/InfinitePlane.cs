using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Tile
{
    public GameObject theTile;
    public float creationTime;

    public Tile(GameObject t, float ct)
    {
        theTile = t;
        creationTime = ct;
    }
}


public class InfinitePlane : MonoBehaviour
{
    public GameObject plane;
    public GameObject llama;

    int planeSize = 10;
    //int halfTilesX = 10;
    //int halfTilesZ = 10;

    Vector3 startPos;//keep track of where the player is/was

    Hashtable tiles = new Hashtable();
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;
        //for (int x = -halfTilesX; x < halfTilesX; x++)
        //{
        //    for (int z = -halfTilesZ; z < halfTilesZ; z++)
        //    {
                Vector3 pos = new Vector3((1 * planeSize + startPos.x),
                    0,
                    (1 * planeSize + startPos.z));
                GameObject t = (GameObject)Instantiate(plane, pos, Quaternion.identity);

                string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                t.name = tilename;
                Tile tile = new Tile(t, updateTime);
                tiles.Add(tilename, tile);
        //    }
       // }
    }

    // Update is called once per frame
    void Update()
    {
        int xMove = (int)(llama.transform.position.x - startPos.x);
        int zMove = (int)(llama.transform.position.z - startPos.z);

        if (Mathf.Abs(llama.transform.position.z) >= planeSize)
        {
            float updateTime = Time.realtimeSinceStartup;

            int llamaX = (int)(Mathf.Floor(llama.transform.position.x / planeSize) * planeSize);
            int llamaZ = (int)(Mathf.Floor(llama.transform.position.z / planeSize) * planeSize);

            //for (int x = -halfTilesX; x < halfTilesX; x++)
            // {
            //   for (int z = -halfTilesZ; z < halfTilesZ; z++)
            //   {
            //create new coords for new plane 
            Vector3 pos = new Vector3((1 * planeSize/* + llamaX*/),
                0,
                (1 * planeSize /*+ llamaZ*/));

            //name new tile
            string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();

            if (!tiles.ContainsKey(tilename))//check if tile exists in array
            {//create new tile
                GameObject t = (GameObject)Instantiate(plane, pos, Quaternion.identity);
                t.name = tilename;
                Tile tile = new Tile(t, updateTime);
                tiles.Add(tilename, tile);
            }
            else
            {
                (tiles[tilename] as Tile).creationTime = updateTime;
            }


            Hashtable newTerrain = new Hashtable();
            foreach (Tile tls in tiles.Values)
            {
                if (tls.creationTime != updateTime)
                {
                    Destroy(tls.theTile);
                }
                else
                {
                    newTerrain.Add(tls.theTile.name, tls);
                }

            }
            tiles = newTerrain;

        }
            // }
    }
}

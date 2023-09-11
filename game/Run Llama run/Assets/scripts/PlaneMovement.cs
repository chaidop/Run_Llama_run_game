using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
	int canGenerate = 1;
	float startPos;
	int heightScale = 20;
	float detailScale = 2.0f;
	public Transform llama;
	public float terrainSpeed;
	void Start()
    {
		startPos = transform.position.z;
		Mesh mesh = this.GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;

		for(int v = 0; v < vertices.Length; v++)
        {
			vertices[v].y = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x) / detailScale, (vertices[v].z + this.transform.position.z) / detailScale) * heightScale;

        }

		mesh.vertices = vertices;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
		this.gameObject.AddComponent<MeshCollider>();
    }

	void Update()
    {

		transform.position -= new Vector3(0.0f, 0.0f, terrainSpeed * Time.deltaTime);

		if (((transform.position.z*startPos)/100 <= 0.25f*startPos) && (canGenerate == 1))
		{
			
			canGenerate = 0;
			Vector3 rot = transform.rotation.eulerAngles;
			rot = new Vector3(rot.x, rot.y + 180, rot.z);
			Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y, transform.position.z + 200), Quaternion.identity);//Euler(rot));

		}
		if (transform.position.z + 200 <= llama.position.z)
		{

			Debug.Log("Plane destroyed!!!!!");
			canGenerate = 1;
			Destroy(gameObject);
		}
	}
}

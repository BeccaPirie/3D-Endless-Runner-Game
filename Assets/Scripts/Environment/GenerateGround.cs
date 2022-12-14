using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateGround : MonoBehaviour
{
    public Camera characterCamera;
    public Transform startPoint;
    public Ground[] groundTiles;
    public int groundToPreSpawn = 15;
    List<Ground> spawnedGroundTiles = new List<Ground>();
    public static GenerateGround instance;
    private int zPosition = 20;

    void Start()
    {
        instance = this;

        // prespawn set amount of ground prefabs
        for (int i = 0; i < groundToPreSpawn; i++)
        {
            System.Random r = new System.Random();
            int randomNumber = r.Next(0, groundTiles.Length);
            Ground spawnedTile = Instantiate(groundTiles[randomNumber], new Vector3(0, 0, zPosition), Quaternion.identity) as Ground;
            zPosition += 10;
            spawnedTile.transform.SetParent(transform);
            foreach (Transform child in spawnedTile.transform)
            {
                child.gameObject.SetActive(true);
            }
            spawnedGroundTiles.Add(spawnedTile);
        }
    }

    void Update()
    {
        // when ground prefab is out of view, move to the end of the course
        if (characterCamera.WorldToViewportPoint(spawnedGroundTiles[0].endPoint.position).z < 0)
        {
            Ground tileTmp = spawnedGroundTiles[0];
            spawnedGroundTiles.RemoveAt(0);
            tileTmp.transform.position = new Vector3(0, 0, zPosition);
            foreach(Transform child in tileTmp.transform)
            {
                child.gameObject.SetActive(true);
            }
            spawnedGroundTiles.Add(tileTmp);
            zPosition += 10;
        }
    }
}

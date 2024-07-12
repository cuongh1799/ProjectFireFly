using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainObjects;
    public GameObject Player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    PlayerMovement pm;
    public GameObject currentChunk;


    // Start is called before the first frame update
    void Start()
    {
        Player = FindAnyObjectByType<GameObject>();
        pm = FindAnyObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
    }

    void ChunkChecker()
    {
        //int rand = Random.Range(0, terrainObjects.Count);
        //currentChunk = terrainObjects[rand];
        
        if (!currentChunk)
        {
            return;
        }

        if (pm.moveDirection.x > 0 && pm.moveDirection.y == 0) // right
        {
            // If 43 pixel on the right no have chunk
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDirection.x > 0 && pm.moveDirection.y > 0) // right up
        {
            // If 18 pixel up no have chunk
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RightUp").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDirection.x > 0 && pm.moveDirection.y < 0) // right down
        {
            // If 18 pixel up no have chunk
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightDown").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RightDown").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDirection.x < 0 && pm.moveDirection.y == 0) // left
        {
            // If 43 pixel on the left no have chunk
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDirection.x < 0 && pm.moveDirection.y > 0) // left up
        {
            // If 43 pixel on the left no have chunk
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LeftUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("LeftUp").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDirection.x < 0 && pm.moveDirection.y < 0) // left down
        {
            // If 43 pixel on the left no have chunk
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LeftDown").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("LeftDown").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDirection.y > 0 && pm.moveDirection.x == 0) // up
        {
            // If 18 pixel up no have chunk
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDirection.y < 0 && pm.moveDirection.x == 0) // down
        {
            // If 18 pixel down no have chunk
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainObjects.Count);
        Instantiate(terrainObjects[rand], noTerrainPosition, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsRandomizer : MonoBehaviour
{
    public List<GameObject> propSpawnPoint;
    public List<GameObject> propPreFabs;
    // Start is called before the first frame update
    void Start()
    {
        SpawnProps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnProps()
    {
        foreach(GameObject obj in propSpawnPoint)
        {
            int rand = Random.Range(0,propPreFabs.Count); // this will be use for selecting props
            GameObject prop = Instantiate(propPreFabs[rand], obj.transform.position, Quaternion.identity);
            prop.transform.parent = obj.transform;
        }
    }
}

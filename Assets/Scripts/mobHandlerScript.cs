using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobHandlerScript : MonoBehaviour
{
    public GameObject target;
    public List<GameObject> enemy; // List so later can random different mobs
    public List<GameObject> spawnPoint; // List so later can random spawn points

    [HideInInspector]
    bool spawning = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawning)
        {
            return;
        }
        if (!spawning)
        {
            spawning = true;
            spawnEnemy();
            StartCoroutine(spawnEnemy());
        }

    }

    IEnumerator spawnEnemy()
    {
        int randomSpawnPoint = Random.Range(0, spawnPoint.Count);
        int randomEnemy = Random.Range(0, enemy.Count);

        GameObject chosenEnemy = enemy[randomEnemy];
        EnemyScript script = chosenEnemy.GetComponent<EnemyScript>();
        script.player = target;
        Instantiate(enemy[randomEnemy], spawnPoint[randomSpawnPoint].transform.position, spawnPoint[randomSpawnPoint].transform.rotation);
        Debug.Log("Spawning enemy");
        yield return new WaitForSeconds(2f);
        spawning = false;
    }
}

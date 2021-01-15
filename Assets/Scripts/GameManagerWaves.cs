using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManagerWaves : MonoBehaviour
{
    public EnemyWave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 10f;
    private const float countdown = 1f;
    private float countdownRemaining = countdown;
    private GameManagerControler gameManagerControler;
    private List<Transform> pathPoints;

    void Start()
    {
        gameManagerControler = gameObject.GetComponent<GameManagerControler>();

                pathPoints = new List<Transform>();
        // add points
        pathPoints.AddRange(gameManagerControler.getPath().GetComponentsInChildren<Transform>());
        // remove parrent
        pathPoints.RemoveAt(0);
    }

    void Update ()
    {
        if (countdownRemaining <= 0f)
        {
            
            countdownRemaining = countdown;
            SpawnEnemy();
        }

        countdownRemaining -= Time.deltaTime;
    }

    void SpawnEnemy()
    {
        bool didSpawn = false;
        foreach (var wave in waves)
        {
            if(wave.spawned < wave.amount){
                // spawn enemy 
                wave.spawned++;
                var lookRotation = Quaternion.LookRotation((pathPoints[0].position - spawnPoint.position).normalized);
                GameObject enemy = Instantiate(wave.enemy, spawnPoint.position, lookRotation);
                EnemyController enemyController = enemy.GetComponent<EnemyController>();
                enemyController.pathPoints = pathPoints.ToList();
                enemyController.gameManagerControler = gameObject.GetComponent<GameManagerControler>();
                didSpawn = true;
                break;
            }
        }

        if(!didSpawn){
            var count = GameObject.FindObjectsOfType<EnemyController>().Length;
            
            if(count == 0){
                // make next wave
                foreach (var wave in waves) {
                    float nAmount = wave.amount * 1.5f;
                    wave.amount = (int)nAmount;
                    wave.spawned = 0;    
                }
                
                countdownRemaining = timeBetweenWaves;
                gameManagerControler.increaseWave();
            }
        }
    }

}

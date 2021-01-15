using UnityEngine;

public class GameManagerWaves : MonoBehaviour
{
    public EnemyWave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 10f;
    private const float countdown = 1f;
    private float countdownRemaining = countdown;
    private GameManagerControler gameManagerControler;

    void Start()
    {
        gameManagerControler = gameObject.GetComponent<GameManagerControler>();
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
                GameObject enemy = Instantiate(wave.enemy, spawnPoint.position, spawnPoint.rotation);
                EnemyController enemyController = enemy.GetComponent<EnemyController>();
                enemyController.gameManagerControler = gameObject.GetComponent<GameManagerControler>();
                didSpawn = true;
                Debug.Log("Spawned " + wave.enemy.name);
                break;
            }
        }

        if(!didSpawn){
            var count = GameObject.FindObjectsOfType<EnemyController>().Length;
            
            if(count == 0){
                // make next wave
                Debug.Log("Wave over");
                foreach (var wave in waves) {
                    float nAmount = wave.amount * 1.5f;
                    wave.amount = (int)nAmount;
                    Debug.Log("New amount " + wave.amount);
                    wave.spawned = 0;    
                }
                
                countdownRemaining = timeBetweenWaves;
                gameManagerControler.increaseWave();
            }
        }
    }

}

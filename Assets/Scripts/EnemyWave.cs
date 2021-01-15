using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWave
{
    public GameObject enemy;

    public int amount;

    [System.NonSerialized]
    public int spawned = 0;
}

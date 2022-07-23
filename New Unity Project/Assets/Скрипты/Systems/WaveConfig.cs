using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject enemyPrefab1;
    [SerializeField] GameObject pathPrefab;
    [Range(0f,5f)][SerializeField] float timeBeteenSpawns;
    [SerializeField] float spawnRandomFactor;
    [SerializeField] int numberofEnemies = 1;
    [SerializeField] float moveSpeed = 2f;
   
    public GameObject GetEnemyPrefab(float enemychoose) 
    {
        
        if (enemychoose  <= 0.5f)
        { 
            return enemyPrefab;
           
        }
        else 
        { 
            return enemyPrefab1;
            
        } 
    }
    public List<Transform> GetWayPoint() {

        var waveWayPoint = new List<Transform>();
        foreach (Transform child in pathPrefab.transform) 
        {
            waveWayPoint.Add(child);
         
        }
        return waveWayPoint; }

    public float GetTimeBetweenSpawns() { return timeBeteenSpawns; }

    public float GetspawnRandomFactor() { return spawnRandomFactor; }

    public int GetNumberofEnemies() { return numberofEnemies; }

    public float GetMoveSpeed() { return moveSpeed; }


}

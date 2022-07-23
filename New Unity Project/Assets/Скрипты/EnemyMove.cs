using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;
    [SerializeField] List<Transform> waypoints;
    

    int pointIndex = 0;
    void Start()
    {
        waypoints = waveConfig.GetWayPoint();
        transform.position = waypoints[pointIndex].transform.position;
    }


    void Update()
    {
        Move();
    
    }

    public void SetWaveConfig(WaveConfig waveConfig) { 
        this.waveConfig = waveConfig;
    }
        
    public void Move()
    {
        if ( pointIndex <= waypoints.Count - 1)
        {
            
            var target = waypoints[pointIndex].transform.position;
            
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards
                (transform.position, target, movementThisFrame);

            if (transform.position == target)
            {
                pointIndex = pointIndex + 1;
            }

            

        }
        else
        {

            Destroy(gameObject);


        }
    }
}

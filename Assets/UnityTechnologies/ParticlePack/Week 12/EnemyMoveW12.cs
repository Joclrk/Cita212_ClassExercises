using System;
using UnityEngine;

public class EnemyMoveW12 : MonoBehaviour
{
    [SerializeField] EnemyWave DemoEnemy;
    [SerializeField] float DemoEnemySpeed;
    int pointIndex = 0;
    Transform[] DemoPointWave;
    void Start()
    {
       DemoPointWave = DemoEnemy.DemoPoints();
    }

    // Update is called once per frame
    void Update()
    {
        DemoPathWaves();
    }
    public void DemoPathWaves()
    {
        Vector3 DemoTargetPosition = DemoPointWave[pointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, DemoTargetPosition, DemoEnemySpeed * Time.deltaTime);
        if(transform.position == DemoTargetPosition)
        {
            pointIndex++;
            if (pointIndex >= DemoPointWave.Length)
            {
                pointIndex = 0;
            }
        }
        
    }
}

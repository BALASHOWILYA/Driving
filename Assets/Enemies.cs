using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private List<GameObject> _enemy;
    public List<GameObject> CreateEnemies(Vector3 pos)
    {
        int ManyEnemy = 20;
        for (int i = 0; i < ManyEnemy; i++)
        {
            float angle = Random.Range(0, 360);
            _enemy.Add(Instantiate(enemyPrefab, pos, Quaternion.Euler(0,angle,0) ) as GameObject); 
        }
        return _enemy;
    }
}

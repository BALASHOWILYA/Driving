using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;
    public void CreateEnemies(Vector3 pos)
    {
        int ManyEnemy = 20;
        for (int i = 0; i < ManyEnemy; i++)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = pos;
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
            _enemy.tag = "Enemy";

        }
    }
}

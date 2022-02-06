using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    //Сериализованная переменная для связи с объектом-шаблоном 
    [SerializeField] private GameObject enemyPrefab;
    //Закрытая переменная для слежения за экземпляром врага в сцене
    private GameObject _enemy;
    private Vector3 _pos;
    private float _angle;

    public SceneController(GameObject enemy, Vector3 pos, float angle )
    {
        _enemy = enemy;
        _pos = pos;
        _angle = angle;
    }

    public SceneController(Vector3 pos)
    {
        _pos = pos;
    }

    public void CreateEnemies()
    {
        _enemy = Instantiate(enemyPrefab) as GameObject;
        _enemy.transform.position = _pos;
        float angle = Random.Range(0, 360);
        _enemy.transform.Rotate(0, angle, 0);
        
    }

    public void StartEnemy()
    {
      int ManyEnemy = 3;
        //Random.Range(0, 10);
        //Порождаем нового врага, только если враги в сцене отсутствуют
        //if (_enemy != null) { return; }

        //Метод, копирующий объект-шаблон
        for (int i = 0; i < ManyEnemy; i++)
        {
            _enemy.tag = "Enemy";
            Instantiate(_enemy, _pos, Quaternion.identity);
        }
      //  }
    }
}

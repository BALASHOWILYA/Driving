using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    //Сериализованная переменная для связи с объектом-шаблоном 
    [SerializeField] private GameObject enemyPrefab;
    //Закрытая переменная для слежения за экземпляром врага в сцене
    private GameObject _enemy;

    public void StartEnemy(Vector3 pos)
    {
        int ManyEnemy = 1;
        //Random.Range(0, 10);
        //Порождаем нового врага, только если враги в сцене отсутствуют
        //if (_enemy != null) { return; }

        //Метод, копирующий объект-шаблон
        for (int i = 0; i < ManyEnemy; i++)
        {

            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.tag = "Obstacle";
            _enemy.transform.position = pos;
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}

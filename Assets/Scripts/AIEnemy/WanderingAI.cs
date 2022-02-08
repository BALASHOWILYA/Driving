using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    //значение для скорости движения и расстояния, с которого начинается реакция на препятствие
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    // Логичекая переменная для слежения за состоянием персонажа.
    private bool _alive;

    private void Start()
    {
        //Инициализация  этой переменной
        _alive = true;
    }


    void Update()
    {
        //Непрерывно движемся вперед в каждом кадре, несмотря на повороты
        //Движение начинается только в случае живого персонажа
        if (!_alive) { return; }
        transform.Translate(0, 0, speed * Time.deltaTime);
        // Луч находится в том же положении и нацеливается  в том же направлении, что и персонаж
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        // Бросаем луч с описанной вокруг него окружностью 
        if(Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            //Распознование игрока
            if (hitObject.GetComponent<Car>()) {
                if(_fireball != null) { return; }
                
                _fireball = Instantiate(fireballPrefab) as GameObject;
                _fireball.AddComponent<MeshRenderer>().material.color = Color.yellow;
                //Поместим огненый шар перед врагом и нацелим в направлении его движения
                _fireball.transform.position =
                    transform.TransformPoint(Vector3.forward * 1.5f);

                _fireball.transform.rotation = transform.rotation;
             
            } 
            else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    //Открытый метод, позволяющий внешнему коду воздействовать на "живое состояние" 
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    //Объект движется между этими точками
    public float speed = 3.0f;
    public float maxZ = 16.0f;
    public float minZ = -16.0f;

    //В каком направлении объект движется в данным момент 
    private int _direction = 1;

    void Update()
    {
        transform.Translate(0, 0, _direction * speed * Time.deltaTime);

        bool bounced = false;
        if(transform.position.z > maxZ || transform.position.z < minZ)
        {
            //Меняем направление на противоположное 
            _direction = -_direction;
            bounced = true;
        }
        if (bounced)
        {
            // Делаем дополнительное движение в этом кадре, если объект поменял направление
            transform.Translate(0, 0, _direction * speed * Time.deltaTime);
        }

    }
}

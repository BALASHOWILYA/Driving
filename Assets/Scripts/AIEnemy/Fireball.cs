using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    //Эта функция вызывается, когда с триггером сталкивается другой объект
    private void OnTriggerEnter(Collider other)
    {
        Car player = other.GetComponent<Car>();
        //Проверяем, является ли этот другой объект объектом   PlayerCharacter.
        if(player != null) {
            player.Hurt(damage);
         }
        Destroy(this.gameObject);

    }
}

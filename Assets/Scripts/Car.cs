using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private float speedGainPerSecond = 0.3f;
    [SerializeField] private float turnSpeed = 200f;

    private int _max = 20;
    private int _steerValue;
    private int _health;
    private int _cure = 1;
    void Start()
    {
        _health = 5;
    }

    void Update()
    {

        if (_max < speed) {

            transform.Rotate(0f, _steerValue * turnSpeed * Time.deltaTime, 0f);

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            return; }

        speed += speedGainPerSecond * Time.deltaTime;

        transform.Rotate(0f, _steerValue * turnSpeed * Time.deltaTime, 0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime );
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) { SceneManager.LoadScene(0); }
        if (other.CompareTag("Enemy")) {
            Cure(_cure);
            other.gameObject.SetActive(false);
        }
    }

    public void Steer(int value)
    {
        _steerValue = value;
    }
    public void Cure(int cure)
    {
        _health += cure;
        Debug.Log("Health:" + _health);
    }
    public void Hurt(int damage)
    {
        
        _health -= damage;
        Debug.Log("Health:" + _health);
    }
}

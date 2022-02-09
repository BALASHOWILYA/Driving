using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private float speedGainPerSecond = 1f;
    [SerializeField] private float turnSpeed = 200f;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private TMP_Text healthText;

    private int _max = 15;
    private int _steerValue;
    private int _health;
    private int _cure = 1;
    void Start()
    {
        _health = 5;
        healthText.text ="Health " + Mathf.FloorToInt(5).ToString();
    }

    void Update()
    {

        if (_max < speed) {

            if (_health <= 0)
            {
                SceneManager.LoadScene(0);
            }

            transform.Rotate(0f, _steerValue * turnSpeed * Time.deltaTime, 0f);

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            return; }

        if(_health <= 0)
        {
            SceneManager.LoadScene(0);
        }

        speed += speedGainPerSecond * Time.deltaTime;

        transform.Rotate(0f, _steerValue * turnSpeed * Time.deltaTime, 0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) { SceneManager.LoadScene(0); }
        if (other.CompareTag("Enemy")) {
            Cure(_cure);
            //Makes the GameObject "other" the parent of the GameObject "enemy".
            ParticleSystem EnemyParticle = Instantiate(particleSystem, other.transform.position, Quaternion.identity);
            other.transform.parent = EnemyParticle.transform;
            other.gameObject.SetActive(false);
            StartCoroutine(StopParticle(EnemyParticle));
             

        }
    }

    public IEnumerator StopParticle(ParticleSystem particle)
    {
        yield return new WaitForSeconds(0.65f);
        particle.gameObject.SetActive(false);

    }

    public void Steer(int value)
    {
        _steerValue = value;
    }
    public void Cure(int cure)
    {
        _health += cure;
        healthText.text = "Health " + Mathf.FloorToInt(_health).ToString();
    }
    public void Hurt(int damage)
    {
        
        _health -= damage;
        healthText.text = "Health " + Mathf.FloorToInt(_health).ToString();
    }
}

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

    
    private void OnTriggerEnter(Collider other)
    {
       

        Car player = other.GetComponent<Car>();
        
        if(player != null) {
            player.Hurt(damage);
            
        }
       
        StartCoroutine(Fade());
     

    }

    

    IEnumerator Fade()
    {
        Color c = this.gameObject.GetComponent<MeshRenderer>().material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.3f)
        {
            c.a = alpha;
           this.gameObject.GetComponent<MeshRenderer>().material.color = c;
            yield return new WaitForSeconds(.0001f);
        }
        Destroy(this.gameObject); 
    }

}

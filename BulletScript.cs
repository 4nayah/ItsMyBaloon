using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    // private ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
      // particles = particles.GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

      if (other.gameObject.tag == "Env")
      {
        gameObject.GetComponent<Renderer>().enabled = false;
        Destroy(gameObject);
      }



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class DogController : MonoBehaviour
{
    float movespeed = 10f;
    public GameObject Bullet;
    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;
    public GameObject Character4;
    private GameObject target;
    private float smooth = 2f;
    public bool hunting = false;
    private float closest;
    public NavMeshAgent agent;
    private Vector3 destination;

    CharacterController1 CharacterScript1;
    CharacterController2 CharacterScript2;
    CharacterController3 CharacterScript3;
    CharacterController4 CharacterScript4;

    // Start is called before the first frame update
    void Start()
    {
      CharacterScript1 = Character1.GetComponent<CharacterController1>();
      CharacterScript2 = Character2.GetComponent<CharacterController2>();
      CharacterScript3 = Character3.GetComponent<CharacterController3>();
      CharacterScript4 = Character4.GetComponent<CharacterController4>();
    }

    // Update is called once per frame
    void Update()
    {

      if(hunting == true){

        transform.position = Vector3.Lerp (transform.position, target.transform.position,Time.deltaTime * smooth * 0.4f);
        transform.GetComponent<NavMeshAgent>().destination = target.transform.position;
        destination = target.transform.position;
        transform.LookAt(target.transform);
        agent.SetDestination(destination);
      }else{
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
      }

    }

    private void OnTriggerEnter(Collider other)
    {

      if(other.gameObject.name ==  Character1.name && hunting==true){
        CharacterScript1.isDead =true;
      }
      if(other.gameObject.name ==  Character2.name && hunting==true){
        CharacterScript2.isDead =true;
      }
      if(other.gameObject.name ==  Character3.name && hunting==true){
        CharacterScript3.isDead =true;
      }
      if(other.gameObject.name ==  Character4.name && hunting==true){
        CharacterScript4.isDead =true;
      }


        if (other.gameObject.tag == "Bullet")
        {
            hunting = true;

            // var Character1 = GameObject.Find("Character1");
            // var Character2 = GameObject.Find("Character2");
            // var Character3 = GameObject.Find("Character3");
            // var Character4 = GameObject.Find("Character4");

            float dist1 = Vector3.Distance(Character1.transform.position, transform.position);
            float dist2 = Vector3.Distance(Character2.transform.position, transform.position);
            float dist3 = Vector3.Distance(Character3.transform.position, transform.position);
            float dist4 = Vector3.Distance(Character4.transform.position, transform.position);

            // Debug.Log(dist);
             closest = Mathf.Min(dist1, dist2, dist3, dist4);

            if(closest == dist1){
              transform.LookAt(Character1.transform);
              target = Character1;
            }else if(closest == dist2){
              transform.LookAt(Character2.transform);
              target = Character2;
            }else if(closest == dist3){
              transform.LookAt(Character3.transform);
              target = Character3;
            }else if(closest == dist4){
              transform.LookAt(Character4.transform);
              target = Character4;
            }
        }else if (other.gameObject == target)
        {
            hunting = false;

        }



    }

}

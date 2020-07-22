using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RespawnCollider : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Camera;
    private float smooth = 5.0f;
    private int respawnPoint = 0;
    public List<GameObject> TouchingObjects;
    private int randomRespawn;

    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;
    public GameObject Character4;

    CharacterController1 CharacterScript1;
    CharacterController2 CharacterScript2;
    CharacterController3 CharacterScript3;
    CharacterController4 CharacterScript4;

    public string randomName;
    public GameObject[] respawns;
    public Vector3 respawnLocation;


    void Start()
    {
      // var Character = GameObject.Find("Character");
      // var Character2 = GameObject.Find("Character2");
      // var Character3 = GameObject.Find("Character3");
      // var Character4 = GameObject.Find("Character4");

      TouchingObjects = new List<GameObject>();
      CharacterScript1 = Character1.GetComponent<CharacterController1>();
      CharacterScript2 = Character2.GetComponent<CharacterController2>();
      CharacterScript3 = Character3.GetComponent<CharacterController3>();
      CharacterScript4 = Character4.GetComponent<CharacterController4>();
      respawns = GameObject.FindGameObjectsWithTag("RespawnPoint");



    }

    // Update is called once per frame
    void Update()
    {
      Camera.transform.position = Vector3.Lerp (transform.position, Camera.transform.position,Time.deltaTime * smooth);

    }


    private void OnTriggerEnter(Collider other)
    {
      if (other.tag == "RespawnPoint")
      {
        if (!TouchingObjects.Contains(other.gameObject))
        {
            TouchingObjects.Add(other.gameObject);
        }
      }
    }

    private void OnTriggerExit(Collider other)
    {
      if (other.tag == "RespawnPoint")
      {
        if (TouchingObjects.Contains(other.gameObject))
        {
          TouchingObjects.Remove(other.gameObject);
        }
      }
    }

    public void RespawnLocation1(){
      randomRespawn = Random.Range (0,TouchingObjects.Count);
      respawnLocation = TouchingObjects[randomRespawn].transform.position;
      CharacterScript1.isDead = false;

    }

    public void RespawnLocation2(){
      randomRespawn = Random.Range (0,TouchingObjects.Count);
      respawnLocation = TouchingObjects[randomRespawn].transform.position;
      CharacterScript2.isDead = false;
    }

    public void RespawnLocation3(){
      randomRespawn = Random.Range (0,TouchingObjects.Count);
      respawnLocation = TouchingObjects[randomRespawn].transform.position;
      CharacterScript3.isDead = false;
    }

    public void RespawnLocation4(){
      randomRespawn = Random.Range (0,TouchingObjects.Count);
      respawnLocation = TouchingObjects[randomRespawn].transform.position;
      CharacterScript4.isDead = false;
    }
}

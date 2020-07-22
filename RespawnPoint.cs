﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    // public GameObject[] RespawnPoints;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.name == "RespawnCollider")
      {
        gameObject.GetComponent<Renderer> ().material.color = Color.green;
      }

    }


    private void OnTriggerExit(Collider other)
    {
      if (other.name == "RespawnCollider")
      {
        gameObject.GetComponent<Renderer> ().material.color = Color.red;
      }
    }


}

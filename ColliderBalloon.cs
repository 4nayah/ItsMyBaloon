using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBalloon : MonoBehaviour
{



    public float movementSpeed = 2;
    private float smooth = 5.0f;

    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;
    public GameObject Character4;

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

      // var Character1 = GameObject.Find("Character");
      // var Character2 = GameObject.Find("Character2");
      // var Character3 = GameObject.Find("Character3");
      // var Character4 = GameObject.Find("Character4");


      if(CharacterScript1.isFollowing == true){
        transform.position = Vector3.Lerp (transform.position, Character1.transform.position,Time.deltaTime * smooth);
      }
      if(CharacterScript2.isFollowing == true){
        transform.position = Vector3.Lerp (transform.position, Character2.transform.position,Time.deltaTime * smooth);
      }
      if(CharacterScript3.isFollowing == true){
        transform.position = Vector3.Lerp (transform.position, Character3.transform.position,Time.deltaTime * smooth);
      }
      if(CharacterScript4.isFollowing == true){
        transform.position = Vector3.Lerp (transform.position, Character4.transform.position,Time.deltaTime * smooth);
      }



    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Character1" && CharacterScript2.isFollowing == false && CharacterScript3.isFollowing == false && CharacterScript4.isFollowing ==false)
        {
            CharacterScript1.isFollowing = true;
            CharacterScript2.isFollowing = false;
            CharacterScript3.isFollowing = false;
            CharacterScript4.isFollowing = false;

        }
        else if (other.gameObject.name == "Character2" && CharacterScript1.isFollowing == false && CharacterScript3.isFollowing == false && CharacterScript4.isFollowing==false)
        {
          CharacterScript1.isFollowing = false;
          CharacterScript2.isFollowing = true;
          CharacterScript3.isFollowing = false;
          CharacterScript4.isFollowing = false;

        }
        else if (other.gameObject.name == "Character3" && CharacterScript2.isFollowing == false && CharacterScript1.isFollowing == false && CharacterScript4.isFollowing ==false)
        {
          CharacterScript1.isFollowing = false;
          CharacterScript2.isFollowing = false;
          CharacterScript3.isFollowing = true;
          CharacterScript4.isFollowing = false;

        }
        else if (other.gameObject.name == "Character4" && CharacterScript2.isFollowing == false && CharacterScript3.isFollowing == false && CharacterScript1.isFollowing ==false)
        {
          CharacterScript1.isFollowing = false;
          CharacterScript2.isFollowing = false;
          CharacterScript3.isFollowing = false;
          CharacterScript4.isFollowing = true;

        }

    }




}

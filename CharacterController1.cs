using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CHARACTER CONTROLLER 1

public class CharacterController1 : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject Collider;
    public GameObject CharacterMod;
    private Rigidbody rb;
    public GameObject ScoringScript; //public GameObject Character1;
    Scoring Scoring; //CharacterController1 CharacterScript1;
    public float movespeed =3f;
    float bulletSpeed = 15f;
    float slideDuration = 0;
    bool charge = false;
    public bool canShoot = true;
    bool canStrafe = true;
    public bool isFollowing = false;
    int life = 2;
    public int deathCounter = 0;
    public bool isDead = false;
    RespawnCollider RespawnLocation;
    public GameObject RespawnCollider;
    DogController DogController;
    public GameObject Dog;
    private int RespawnCooldown = 100;
    private Vector3 moveVector;
    private float moveHorizontal;
    private float moveVertical;

    void Start()
    {

        Scoring = ScoringScript.GetComponent<Scoring>();
        rb = GetComponent<Rigidbody>();
        RespawnLocation = RespawnCollider.GetComponent<RespawnCollider>();
        DogController = Dog.GetComponent<DogController>();

        CharacterMod = MainController.J1Character;
    }

    void FixedUpdate()
    {



        // MOUVEMENT


          moveHorizontal = Input.GetAxis ("J1_MainHorizontal");
          moveVertical = Input.GetAxis ("J1_MainVertical");
          moveVector = new Vector3(moveHorizontal,0,moveVertical) * movespeed * 5000 * Time.deltaTime;
          rb.AddForce(moveVector, ForceMode.Acceleration);



          Vector3 moveDirection = new Vector3(Input.GetAxis("J1_MainHorizontal"), 0, Input.GetAxis("J1_MainVertical"));
          Vector3 moveSecDirection = new Vector3(Input.GetAxis("J1_SecHorizontal"), 0, Input.GetAxis("J1_SecVertical"));

          if (moveSecDirection != Vector3.zero)
          {Quaternion newRotation = Quaternion.LookRotation(moveSecDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
          }else{
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
              transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
          }




        // ROTATION









        // INPUT LEAVE BALLOON
        if (Input.GetButtonDown("J1_A_Button")){
            canShoot = true;
            canStrafe = true;
            isFollowing =false;
        }

        // SYSTEME DE STRAFE JUMP
        if (Input.GetButtonDown("J1_B_Button") && canStrafe == true)
        {
          slideDuration = 0f;
        }

        if (Input.GetButtonDown("J1_Y_Button"))
        {
          isDead = true;
        }

        if (slideDuration >= 0)
        {
          Vector3 moveSlideDirection = new Vector3(Input.GetAxis("J1_MainHorizontal"), 0, Input.GetAxis("J1_MainVertical"));
            if (moveSlideDirection != Vector3.zero)
            {
                Quaternion newRotation = Quaternion.LookRotation(moveSlideDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 00);
                transform.position += transform.forward /100 ;
            }
        }else
        {
          rb.velocity = Vector3.zero;
        }
        slideDuration--;

         if (Input.GetAxis("J1_RTrigger") > 0.5 && canShoot == true && isDead == false)
        {
          charge = true;
          movespeed = 1f;
          canShoot = true;

        }
        else if(Input.GetAxis("J1_RTrigger") < 0.5 && charge == true )
        {
          movespeed = 3f;
          charge = false;
            Fire();
        }



        if(isDead == true){
          RespawnCooldown--;
          movespeed =0f;
          gameObject.GetComponent<Renderer>().enabled = false;
          CharacterMod.GetComponent<Renderer>().enabled = false;
          rb.detectCollisions = false;
          isFollowing = false;
        }

        if(isDead == true && Input.GetButtonDown("J1_A_Button") || RespawnCooldown < 0  )
        {
          Respawn();
        }
        //
        if(isFollowing==true){
          canShoot=false;
        }

    }

    private void Respawn(){

      CharacterMod.GetComponent<Renderer>().enabled = true;
      RespawnLocation.RespawnLocation1();
      life =2;
      movespeed =3f;
      deathCounter++;
      rb.detectCollisions = true;
      rb.position = RespawnLocation.respawnLocation;
      RespawnCooldown = 100;
    }

    private void OnTriggerEnter(Collider other)
    {

      if (other.gameObject.name != "C1Bullet" && other.gameObject.tag == "Bullet")
      {
        life--;

        if(life <= 0){
          isDead = true;
        }

      }

    }


    // SYSTEME DE TIR
    void Fire()
    {
      var bullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
      bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
      bullet.tag = "Bullet";
      bullet.name = "C1Bullet";
      Destroy(bullet, 2.0f);
    }
}

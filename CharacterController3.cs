using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CHARACTER CONTROLLER 3

public class CharacterController3 : MonoBehaviour
{

  public GameObject bulletPrefab;
  public GameObject Collider;
  private Rigidbody rb;
    public float movespeed =4f;
    float bulletSpeed = 15f;
    float slideDuration = 0;
    bool charge = false;
    public bool canShoot = true;
    bool canStrafe = true;
    public bool isFollowing = false;
    int life = 2;
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
        rb = GetComponent<Rigidbody>();
        RespawnLocation = RespawnCollider.GetComponent<RespawnCollider>();
        DogController = Dog.GetComponent<DogController>();
    }

    void FixedUpdate()
    {
        // MOUVEMENT
        moveHorizontal = Input.GetAxis ("J3_MainHorizontal");
        moveVertical = Input.GetAxis ("J3_MainVertical");

        moveVector = new Vector3(moveHorizontal,0,moveVertical) * movespeed * 5000 * Time.deltaTime;
        rb.AddForce(moveVector, ForceMode.Acceleration);


        // ROTATION
        Vector3 moveDirection = new Vector3(Input.GetAxis("J3_SecHorizontal"), 0, Input.GetAxis("J3_SecVertical"));
        if (moveDirection != Vector3.zero)
        {Quaternion newRotation = Quaternion.LookRotation(moveDirection);
          transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
        }

        // INPUT LEAVE BALLOON
        if (Input.GetButtonDown("J3_A_Button")){
            canShoot = true;
            canStrafe = true;
            isFollowing =false;
        }

        // SYSTEME DE STRAFE JUMP
        if (Input.GetButtonDown("J3_B_Button") && canStrafe == true)
        {
          slideDuration = 0f;
        }

        if (Input.GetButtonDown("J3_Y_Button"))
        {
          isDead = true;
        }

        if (slideDuration >= 0)
        {
          Vector3 moveSlideDirection = new Vector3(Input.GetAxis("J3_MainHorizontal"), 0, Input.GetAxis("J3_MainVertical"));
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

         if (Input.GetAxis("J3_RTrigger") > 0.5 && canShoot == true && isDead == false)
        {
          charge = true;
          movespeed = 1f;
          canShoot = true;

        }
        else if(Input.GetAxis("J3_RTrigger") < 0.5 && charge == true )
        {
          movespeed = 4f;
          charge = false;
            Fire();
        }

      

        if(isDead == true){
          RespawnCooldown--;
          movespeed =0f;
          gameObject.GetComponent<Renderer>().enabled = false;
          rb.detectCollisions = false;
          isFollowing = false;
        }
        //
        if(isDead == true && Input.GetButtonDown("J3_A_Button") || RespawnCooldown < 0)
        {
          Respawn();
        }

        if(isFollowing==true){
          canShoot=false;
        }
        // // Debug.Log(isFollowing);
        // // isFollowing = false;
    }

    private void Respawn(){

      gameObject.GetComponent<Renderer>().enabled = true;
      RespawnLocation.RespawnLocation3();
      life =2;
      movespeed =4f;
      rb.detectCollisions = true;
      rb.position = RespawnLocation.respawnLocation;
      RespawnCooldown = 100;
    }

    private void OnTriggerEnter(Collider other)
    {

      if (other.gameObject.name != "C3Bullet" && other.gameObject.tag == "Bullet")
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
      bullet.name = "C3Bullet";
      Destroy(bullet, 2.0f);
    }
}

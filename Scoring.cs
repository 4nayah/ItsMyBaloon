using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Balloon;
    ColliderBalloon ColliderBalloon;

    public int scoring1 = 0;
    public int scoring2 = 0;
    public int scoring3 = 0;
    public int scoring4 = 0;
    public bool isPlaying = false;
    private int limitationScore = 3600;  //Default 3600
    public Text J1Score;
    public Text J2Score;
    public Text J3Score;
    public Text J4Score;
    public Slider J1Progress;
    public Slider J2Progress;
    public Slider J3Progress;
    public Slider J4Progress;
    public Text EndGame;
    public Text CountdownStartText;
    public bool TimeUp = false;
    private int CountdownStart = 180;// Default 180

    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;
    public GameObject Character4;

    CharacterController1 CharacterScript1;
    CharacterController2 CharacterScript2;
    CharacterController3 CharacterScript3;
    CharacterController4 CharacterScript4;

    public RawImage Bouton1A;
    public RawImage Bouton1B;
    public RawImage Bouton1X;
    public RawImage Bouton1Y;
    public RawImage Bouton2A;
    public RawImage Bouton2B;
    public RawImage Bouton2X;
    public RawImage Bouton2Y;
    public RawImage Bouton3A;
    public RawImage Bouton3B;
    public RawImage Bouton3X;
    public RawImage Bouton3Y;
    public RawImage Bouton4A;
    public RawImage Bouton4B;
    public RawImage Bouton4X;
    public RawImage Bouton4Y;

    public Text Action1;
    public Text Action2;
    public Text Action3;
    public Text Action4;

    void Start()
    {





      ColliderBalloon = Balloon.GetComponent<ColliderBalloon>();
      EndGame.GetComponent<Text>().enabled = false;
      CharacterScript1 = Character1.GetComponent<CharacterController1>();
      CharacterScript2 = Character2.GetComponent<CharacterController2>();
      CharacterScript3 = Character3.GetComponent<CharacterController3>();
      CharacterScript4 = Character4.GetComponent<CharacterController4>();

      CharacterScript1.movespeed = 0;
      CharacterScript2.movespeed = 0;
      CharacterScript3.movespeed = 0;
      CharacterScript4.movespeed = 0;
      CharacterScript1.canShoot = false;
      CharacterScript2.canShoot = false;
      CharacterScript3.canShoot = false;
      CharacterScript4.canShoot = false;



      if(MenuStart.J2Ready == true){
        J2Score.gameObject.SetActive(true);
      }else{
        J2Score.gameObject.SetActive(false);
      }
      if(MenuStart.J3Ready == true){
        J3Score.gameObject.SetActive(true);
      }else{
        J3Score.gameObject.SetActive(false);
      }
      if(MenuStart.J4Ready == true){
        J4Score.gameObject.SetActive(true);
      }else{
        J4Score.gameObject.SetActive(false);
      }






    }

    // Update is called once per frame
    void Update()
    {

      if(Input.GetButtonDown("StartGame1") && isPlaying == false){
        Time.timeScale=1;

      }else if(Input.GetButtonDown("StartGame1") && isPlaying == true){
        Time.timeScale=0;
      }




      Bouton1A.enabled = false;
      Bouton1B.enabled = false;
      Bouton1X.enabled = false;
      Bouton1Y.enabled = false;
      Bouton2A.enabled = false;
      Bouton2B.enabled = false;
      Bouton2X.enabled = false;
      Bouton2Y.enabled = false;
      Bouton3A.enabled = false;
      Bouton3B.enabled = false;
      Bouton3X.enabled = false;
      Bouton3Y.enabled = false;
      Bouton4A.enabled = false;
      Bouton4B.enabled = false;
      Bouton4X.enabled = false;
      Bouton4Y.enabled = false;

      Action1.text = ("");
      Action2.text = ("");
      Action3.text = ("");
      Action4.text = ("");

      if(CountdownStart > 0){
        CharacterScript1.movespeed = 0;
        CharacterScript2.movespeed = 0;
        CharacterScript3.movespeed = 0;
        CharacterScript4.movespeed = 0;
        CharacterScript1.canShoot = false;
        CharacterScript2.canShoot = false;
        CharacterScript3.canShoot = false;
        CharacterScript4.canShoot = false;
      }
      //AFFICHAGE DES SCORES SUR L'UI
      J1Score.text = ("Joueur 1").ToString();
      J2Score.text = ("Joueur 2").ToString();
      J3Score.text = ("Joueur 3").ToString();
      J4Score.text = ("Joueur 4").ToString();

      J1Progress.value = scoring1;
      J2Progress.value = scoring2;
      J3Progress.value = scoring3;
      J4Progress.value = scoring4;


      CountdownStart--;
      if(CountdownStart <= 180){
        CountdownStartText.text = "3";
      }
      if(CountdownStart <= 120){
        CountdownStartText.text = "2";
      }
      if(CountdownStart <= 60){
        CountdownStartText.text = "1";
      }
      if(CountdownStart <= 0){
        CountdownStartText.text = "Go";
        CharacterScript1.movespeed = 3f;
        CharacterScript2.movespeed = 3f;
        CharacterScript3.movespeed = 3f;
        CharacterScript4.movespeed = 3f;



      }
      if(CountdownStart == 0){
        CharacterScript1.canShoot = true;
        CharacterScript2.canShoot = true;
        CharacterScript3.canShoot = true;
        CharacterScript4.canShoot = true;
        isPlaying = true;
      }
      if(CountdownStart <= -15){
        CountdownStartText.text = "";
      }

      //3600 frame = 1minute
      if(CharacterScript1.isFollowing == true){
        scoring1++;
      }
      else if(CharacterScript2.isFollowing == true ){
        scoring2++;
      }
      else if(CharacterScript3.isFollowing == true){
        scoring3++;
      }
      else if(CharacterScript4.isFollowing == true){
        scoring4++;
      }

      if(TimeUp == true){
        isPlaying = false;
        CharacterScript1.movespeed = 0;
        CharacterScript2.movespeed = 0;
        CharacterScript3.movespeed = 0;
        CharacterScript4.movespeed = 0;
        CharacterScript1.canShoot = false;
        CharacterScript2.canShoot = false;
        CharacterScript3.canShoot = false;
        CharacterScript4.canShoot = false;
        SceneManager.LoadScene("HighScores");
      }

      if(scoring1 == limitationScore || scoring2 == limitationScore || scoring3 == limitationScore || scoring4 == limitationScore){
        // UN DES JOUEURS ATTEINT A FINI

        EndGame.GetComponent<Text>().enabled = true;
        TimeUp = true;

      }

      if(CharacterScript1.isDead == true){
        Action1.text = ("Respawn");
        Bouton1A.enabled = true;
      }
      if(CharacterScript2.isDead == true){
        Action2.text = ("Respawn");
        Bouton2A.enabled = true;
      }
      if(CharacterScript3.isDead == true){
        Action3.text = ("Respawn");
        Bouton3A.enabled = true;
      }
      if(CharacterScript4.isDead == true){
        Action4.text = ("Respawn");
        Bouton4A.enabled = true;
      }
    }
}

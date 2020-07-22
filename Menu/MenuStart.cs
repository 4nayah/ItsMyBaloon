using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{

    public GameObject CharacterSelection;

    public List<Sprite> Characters;
    public bool dontDestroy;


    public GameObject J1CharacterConfirm;
    public GameObject J2CharacterConfirm;
    public GameObject J3CharacterConfirm;
    public GameObject J4CharacterConfirm;
    public GameObject CharacterPreview1;
    public GameObject CharacterPreview2;
    public GameObject CharacterPreview3;
    public GameObject CharacterPreview4;
    public static int i = 0;
    public static int j = 0;
    public static int k = 0;
    public static int l = 0;
    public static bool J1Ready = false;
    public static bool J2Ready = false;
    public static bool J3Ready = false;
    public static bool J4Ready = false;
    private bool J2connected = false;
    private bool J3connected = false;
    private bool J4connected = false;
    private bool J1spamBlockRight =false;
    private bool J2spamBlockRight =false;
    private bool J3spamBlockRight =false;
    private bool J4spamBlockRight =false;
    private bool J1spamBlockLeft =false;
    private bool J2spamBlockLeft =false;
    private bool J3spamBlockLeft =false;
    private bool J4spamBlockLeft =false;

    public static int connected = 1;
    public static int ready = 0;
    public static string J1Playable;


    // Update is called once per frame




    void Start(){
      J2CharacterConfirm.SetActive(false);
      J3CharacterConfirm.SetActive(false);
      J4CharacterConfirm.SetActive(false);

      if(dontDestroy){
        DontDestroyOnLoad(this.gameObject);
      }

    }
    void Update()
    {

      J1Playable = CharacterPreview1.GetComponent<Image> ().sprite.ToString();

      if(connected >= 2 && ready >= 2 && connected == ready){
        SceneManager.LoadScene("baseScene");
      }

      if(CharacterSelection.activeInHierarchy){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(J1CharacterConfirm);
      }


      if(Input.GetButtonDown("StartGame2")){
        J2CharacterConfirm.SetActive(true);
        connected++;
        J2connected =true;
      }
      if(Input.GetButtonDown("StartGame3")){
        J3CharacterConfirm.SetActive(true);
        connected++;
        J3connected =true;
      }
      if(Input.GetButtonDown("StartGame4")){
        J4CharacterConfirm.SetActive(true);
        connected++;
        J4connected =true;
      }


      if (Input.GetButtonDown("J1_A_Button")){
        J1CharacterConfirm.GetComponentInChildren<Text>().text = "READY";
        J1CharacterConfirm.GetComponentInChildren<Text>().GetComponentInChildren<Image>().enabled=false;
        J1Ready=true;
        ready++;
      }else if (Input.GetButtonDown("J1_B_Button")){
        J1CharacterConfirm.GetComponentInChildren<Text>().text = "PRESS            TO SELECT";
        J1CharacterConfirm.GetComponentInChildren<Text>().GetComponentInChildren<Image>().enabled=true;
        J1Ready=false;
        ready--;
      }

      if (Input.GetButtonDown("J2_A_Button") && J2connected == true){
        J2CharacterConfirm.GetComponentInChildren<Text>().text = "READY";
        J2CharacterConfirm.GetComponentInChildren<Text>().GetComponentInChildren<Image>().enabled=false;
        J2Ready=true;
        ready++;
      }else if (Input.GetButtonDown("J2_B_Button") && J2connected == true){
        J2CharacterConfirm.GetComponentInChildren<Text>().text = "PRESS            TO SELECT";
        J2CharacterConfirm.GetComponentInChildren<Text>().GetComponentInChildren<Image>().enabled=true;
        J2Ready=false;
        ready--;
      }

      if (Input.GetButtonDown("J3_A_Button") && J3connected == true){
        J3CharacterConfirm.GetComponentInChildren<Text>().text = "READY";
        J3CharacterConfirm.GetComponentInChildren<Text>().GetComponentInChildren<Image>().enabled=false;
        J3Ready=true;
        ready++;
      }else if (Input.GetButtonDown("J3_B_Button") && J3connected == true){
        J3CharacterConfirm.GetComponentInChildren<Text>().text = "PRESS            TO SELECT";
        J3CharacterConfirm.GetComponentInChildren<Text>().GetComponentInChildren<Image>().enabled=true;
        J3Ready=false;
        ready--;
      }
      if (Input.GetButtonDown("J4_A_Button") && J4connected == true){
        J4CharacterConfirm.GetComponentInChildren<Text>().text = "READY";
        J4CharacterConfirm.GetComponentInChildren<Text>().GetComponentInChildren<Image>().enabled=false;
        J4Ready=true;
        ready++;
      }else if (Input.GetButtonDown("J4_B_Button") && J4connected == true){
        J4CharacterConfirm.GetComponentInChildren<Text>().text = "PRESS            TO SELECT";
        J4CharacterConfirm.GetComponentInChildren<Text>().GetComponentInChildren<Image>().enabled=true;
        J4Ready=false;
        ready--;
      }









      if(Input.GetAxis ("J1_MainHorizontal") >0.9){
        J1spamBlockRight = true;
      }
      else if(Input.GetAxis ("J1_MainHorizontal") <0.9 && J1spamBlockRight == true && J1Ready==false){
        if(i < Characters.Count-1){
          i++;
          J1spamBlockRight = false;
        }else{
          i = 0;
          J1spamBlockRight = false;
        }
      }

      CharacterPreview1.GetComponent<Image> ().sprite = Characters[i];
      if(Input.GetAxis ("J1_MainHorizontal") < -0.9){
        J1spamBlockLeft = true;
      }
      else if(Input.GetAxis ("J1_MainHorizontal") > -0.9 && J1spamBlockLeft == true && J1Ready==false){
        if(i == 0){
          i = Characters.Count-1;
          J1spamBlockLeft = false;
        }else{
          i--;
          J1spamBlockLeft = false;
        }
      }






      if(Input.GetAxis ("J2_MainHorizontal") >0.9){
        J2spamBlockRight = true;
      }
      else if(Input.GetAxis ("J2_MainHorizontal") <0.9 && J2spamBlockRight == true && J2Ready==false){
        if(j < Characters.Count-1){
          j++;
          J2spamBlockRight = false;
        }else{
          j = 0;
          J2spamBlockRight = false;
        }
      }

      CharacterPreview2.GetComponent<Image> ().sprite = Characters[j];
      if(Input.GetAxis ("J2_MainHorizontal") < -0.9){
        J2spamBlockLeft = true;
      }
      else if(Input.GetAxis ("J2_MainHorizontal") > -0.9 && J2spamBlockLeft == true && J2Ready==false){
        if(j == 0){
          j = Characters.Count-1;
          J2spamBlockLeft = false;
        }else{
          j--;
          J2spamBlockLeft = false;
        }
      }




      if(Input.GetAxis ("J3_MainHorizontal") >0.9){
        J3spamBlockRight = true;
      }
      else if(Input.GetAxis ("J3_MainHorizontal") <0.9 && J3spamBlockRight == true && J3Ready==false){
        if(k < Characters.Count-1){
          k++;
          J3spamBlockRight = false;
        }else{
          k = 0;
          J3spamBlockRight = false;
        }
      }

      CharacterPreview3.GetComponent<Image> ().sprite = Characters[k];
      if(Input.GetAxis ("J3_MainHorizontal") < -0.9){
        J3spamBlockLeft = true;
      }
      else if(Input.GetAxis ("J3_MainHorizontal") > -0.9 && J3spamBlockLeft == true && J3Ready==false){
        if(k == 0){
          k = Characters.Count-1;
          J3spamBlockLeft = false;
        }else{
          k--;
          J3spamBlockLeft = false;
        }
      }




      if(Input.GetAxis ("J4_MainHorizontal") >0.9){
        J4spamBlockRight = true;
      }
      else if(Input.GetAxis ("J4_MainHorizontal") <0.9 && J4spamBlockRight == true && J4Ready==false){
        if(l < Characters.Count-1){
          l++;
          J4spamBlockRight = false;
        }else{
          l = 0;
          J4spamBlockRight = false;
        }
      }

      CharacterPreview4.GetComponent<Image> ().sprite = Characters[l];
      if(Input.GetAxis ("J4_MainHorizontal") < -0.9){
        J4spamBlockLeft = true;
      }
      else if(Input.GetAxis ("J4_MainHorizontal") > -0.9 && J4spamBlockLeft == true && J4Ready==false){
        if(l == 0){
          l = Characters.Count-1;
          J4spamBlockLeft = false;
        }else{
          l--;
          J4spamBlockLeft = false;
        }
      }

    }//END UPDATE

}//END SCRIPT

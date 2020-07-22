using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{

    public List<GameObject> CharacterList;
    public GameObject Player1Holder;
    public GameObject Player2Holder;
    public GameObject Player3Holder;
    public GameObject Player4Holder;

    static public GameObject J1Character;
    static public GameObject J2Character;
    static public GameObject J3Character;
    static public GameObject J4Character;

    private GameObject J1Player;
    private GameObject J2Player;
    private GameObject J3Player;
    private GameObject J4Player;

    // Start is called before the first frame update
    void Start()
    {

        // MenuStart.J2Playable

        // Debug.Log(J1Player);

        J1Player = Instantiate (CharacterList[MenuStart.i], new Vector3(Player1Holder.transform.position.x,1.184f, Player1Holder.transform.position.z) , Quaternion.identity);
        J1Player.transform.localScale = new Vector3(0.63f,0.63f,0.63f);
        J1Player.transform.parent = Player1Holder.transform;
        J1Character = J1Player;

        if(MenuStart.J2Ready == true){
          J2Player = Instantiate (CharacterList[MenuStart.j], new Vector3(Player2Holder.transform.position.x,1.184f, Player2Holder.transform.position.z) , Quaternion.identity);
          J2Player.transform.localScale = new Vector3(0.63f,0.63f,0.63f);
          J2Player.transform.parent = Player2Holder.transform;
          J2Character = J2Player;
        }else{
          Player2Holder.SetActive(false);
        }

        if(MenuStart.J3Ready == true){
          J3Player = Instantiate (CharacterList[MenuStart.k], new Vector3(Player3Holder.transform.position.x,1.184f, Player3Holder.transform.position.z) , Quaternion.identity);
          J3Player.transform.localScale = new Vector3(0.63f,0.63f,0.63f);
          J3Player.transform.parent = Player3Holder.transform;
          J3Character = J3Player;
        }else{
          Player3Holder.SetActive(false);
        }
        if(MenuStart.J4Ready == true){
          J4Player = Instantiate (CharacterList[MenuStart.l], new Vector3(Player4Holder.transform.position.x,1.184f, Player4Holder.transform.position.z) , Quaternion.identity);
          J4Player.transform.localScale = new Vector3(0.63f,0.63f,0.63f);
          J4Player.transform.parent = Player4Holder.transform;
          J4Character = J4Player;
        }else{
          Player4Holder.SetActive(false);
        }


        // Instanciate()
        // Instantiate(Character, new Vector3(0, 0,-4), Quaternion.identity);
        // Instantiate(Character2, new Vector3(0, 0,4), Quaternion.identity);
        // Instantiate(Character3, new Vector3(-4, 0,0), Quaternion.identity);
        // Instantiate(Character4, new Vector3(4, 0,0), Quaternion.identity);
        // Instantiate(Collider, new Vector3(0, 0,0), Quaternion.identity);
        // Instantiate(Dog, new Vector3(1, 0,-9), Quaternion.identity);

        // myCharacterScript = Character.GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {

      // var Character1 = GameObject.Find("Character(Clone)");
      // var Character2 = GameObject.Find("Character2(Clone)");
      // var Character3 = GameObject.Find("Character3(Clone)");
      // var Character4 = GameObject.Find("Character4(Clone)");

      // feedback = myCharacterScript.life;
      //
      // Debug.Log(feedback);






    }
}

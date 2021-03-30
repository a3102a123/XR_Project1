using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScene4 : MonoBehaviour
{
    public GameObject father;
    public GameObject mother;
    public GameObject choice;
    public GameObject choice1;
    
    private void Awake()
    {
      if(GameManager.GM.get_state() == GameState.SCENE4){
          Debug.Log("change4");
          father.SetActive(true);
          mother.SetActive(false);
          choice.SetActive(true);
          choice1.SetActive(true);
          this.enabled = false;
      }
    }
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }
}

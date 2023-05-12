using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    // Start is called before the first frame update


    //bool gameHasEnded = false;   //  tellss program that by defult game has not ended
    public float restartdelay = 1;  // adds a small amout of dely to the restart anamation

    public GameObject completeLevelUI;

    public void completelevel()
    {
        completeLevelUI.SetActive(true);      // activates the level ui so player knows the level is completed
    }


}

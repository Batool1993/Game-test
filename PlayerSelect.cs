using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
public void PlayGame(){
    SceneManager.LoadScene("GamePlay");
}   
}

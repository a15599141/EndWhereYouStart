using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public GameObject settingMenu;


   public void NextScene(){
      SceneManager.LoadScene(1);
   }

   public void OpenSettingMenu(){
      settingMenu.SetActive(true);

   }

   public void CloseSettingMenu(){
      settingMenu.SetActive(false);
   }

   public void Quit(){
      Application.Quit();
   }
}

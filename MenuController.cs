using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // fields to store values inputted by user in dropdown
    public static int feet = 6;
    public static int inches = 0;
    // references to the dropdowns
    public TMP_Dropdown feetDrop, inchesDrop;

    // set value of dropdowns so we save user height if a user inputs a height, starts a game, then returns to main menu
    public void Start() {
        feetDrop.value = feet;
        inchesDrop.value = inches;
    }

    // called when the apple picking game button is pressed
    public void AppleBtn() {
        SceneManager.LoadScene("Apple");
    }

    // called when the boxing game button is pressed
    public void BoxingBtn() {
        SceneManager.LoadScene("Boxing");
    }

    // function called by dropdown when its value changes
    public void updateFeet(TMP_Dropdown dropdown) {
        feet = dropdown.value;
    }

    // function called by dropdown when its value changes
    public void updateInches(TMP_Dropdown dropdown) {
        inches = dropdown.value;
    }
}

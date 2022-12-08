using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignController : MonoBehaviour
{
    // return to main menun when trigger (hands) enter the gameobject this script is attached to
    public void OnTriggerEnter(Collider col) {
        SceneManager.LoadScene("Menu");
    }
}

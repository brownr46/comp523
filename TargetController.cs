using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetController : MonoBehaviour
{
    // keep track of whether this plate has spawned a new plate or not
    private bool spawned;
    // keep track of number of frames since this plate was spawned
    private int timer;
    // reference to score counter so we can increment it
    public TextMeshProUGUI scoreText;

    void Start()
    {
        spawned = false;
        timer = 0;
    }

    // called once per frame
    void Update()
    {
        if (timer < 50) {
            timer++;
        }
    }

    // called when glove touches plate
    public void OnTriggerEnter(Collider col) {
        // if we haven't spawned a new plate yet and the plate has been spawned for at least 50 frames
        if (!spawned && timer == 50) {
            scoreText.text = int.Parse(scoreText.text) + 1 + "";

            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().AddForce(transform.up * -600F); // add force to throw the plate backwards because trigger collision does not transfer any force

            // spawn a new plate
            Instantiate(this.gameObject, new Vector3(Random.Range(-.25F, .25F), Random.Range(1F, 1.5F), 0.5F), transform.rotation);
            spawned = true;

            StartCoroutine(Coroutine());
        }
    }
    
    // change the plate's collision layer half a second after it is punched
    // this is to prevent punched plates from colliding with newly spawned plates (since they spawn on the same plane)
    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(.5F);

        gameObject.layer = LayerMask.NameToLayer("collide");
    }
}

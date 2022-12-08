    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.XR.Interaction.Toolkit;
    using TMPro;

    public class AppleController : MonoBehaviour
    {
        // keep track of whether this instance of the apple has spawned a new apple
        public bool spawned;
        // keeps track of whether the apple is currently inside the basket
        public bool inBasket;
        // reference to score object so we can increment score
        public TextMeshProUGUI scoreText;

        // initialize starting state and move apple to correct location based on inputted user height
        void Start()
        {
            spawned = false;
            inBasket = false;
            transform.position = new Vector3(
                -5.16F, 
                -0.2858F + feetToMeters(MenuController.feet) + inchesToMeters(MenuController.inches), 
                -3.115F
            );
        }

        public void OnCollisionEnter(Collision col) {
            // if we are colliding with basket
            if (col.gameObject.tag == "basket") {
                // check that we are inside the basket and not colliding with the exterior 
                if (inBasket) {
                    // if we haven't already spawned a new apple need to increment the score and spawn a new one
                    if (!spawned) {
                        scoreText.text = int.Parse(scoreText.text) + 1 + "";
                        clone();
                    }
                    // prevent users from grabbing this apple out of the basket
                    Destroy(GetComponent<XRGrabInteractable>());
                }
            // else we are colliding with the terrain or something else, in this case the user has thrown the apple away
            // want to destroy the current apple and respawn a new one on the tree
            } else {
                if (!spawned) {
                    clone();
                }
                Destroy(this.gameObject);
            }
        }

        public void OnTriggerEnter(Collider other) {
            // the hands are triggers but we want to excldue them here
            if (other.tag != "hand") {
                // if the user is not currently in control of the apple (i.e. it is falling from above the basket)
                // we want to destroy this apple and spawn a new one because users should only be able to place apples into the basket
                if (!GetComponent<XRGrabInteractable>().isSelected) {
                    clone();
                    Destroy(this.gameObject);
                    return;
                } else {
                    inBasket = true;
                }
            }
        }

        public void OnTriggerExit(Collider other) {
            if (other.tag != "target") {
                inBasket = false;
            }
        }

        // spawn a new copy of the apple on the tree
        private void clone() {
            GameObject apple = Instantiate(
                this.gameObject, 
                new Vector3(-5.16F, -0.2858F + feetToMeters(MenuController.feet) + inchesToMeters(MenuController.inches), -3.115F), 
                new Quaternion(.707F, 0, 0, -.707F)
            );
            apple.GetComponent<Rigidbody>().useGravity = false;
            spawned = true; 
        }

        private float feetToMeters(int feet) {
            return (float) feet * 0.3048F;
        }

        private float inchesToMeters(int inches) {
            return (float) inches * 0.3048F / 12F;
        }
    }

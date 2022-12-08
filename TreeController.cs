using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    // initial offset for tree height
    public float treePos = -.217F;

    void Start()
    {
        // adjust tree height based on user's inputted heights
        treePos = treePos - 1.8288F + feetToMeters(MenuController.feet) + inchesToMeters(MenuController.inches);
        transform.position = new Vector3(-4.39F, treePos, -3.3291F);
    }

    private float feetToMeters(int feet) {
        return (float) feet * 0.3048F;
    }

    private float inchesToMeters(int inches) {
        return (float) inches * 0.3048F / 12F;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    // Store the object that the user is or just pointed at
    Highlightable pointingAt;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        // Send out a raycast from position in forward direction. Store hit info in RaycastHit object, travel 500 units
        if(Physics.Raycast(transform.position, transform.forward, out hit, 500)){

            // Checks that the hit object is the correct type
            if(hit.collider.tag == "Highlightable"){
                // Incase we switch from previous object to a new object in one frame
                if(pointingAt && hit.collider.GetComponent<Highlightable>() != pointingAt){
                    pointingAt.Unhighlight();
                }

                // Update the pointingAt var and highlight it
                pointingAt = hit.collider.GetComponent<Highlightable>();
                pointingAt.Highlight();
            } else{
                // If the object we hit is not highlightable, unhighlight the last object we highlighted
                if(pointingAt){
                    pointingAt.Unhighlight();
                    pointingAt = null;
                }
            }
        } else{
            // If no object is hit, unhighlight the last object we highlighted
            if(pointingAt){
                pointingAt.Unhighlight();
                pointingAt = null;
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class MyThrusterScript : MonoBehaviour
{
    public float thrusterStrength;
    public float thrusterDistance;
    public Transform[] thrusters;

    void FixedUpdate()
    {
        RaycastHit hit;

        foreach (Transform thruster in thrusters)
        {
            Vector3 downwardForce;
            float distancePercentage;

            if (Physics.Raycast(thruster.position, thruster.up * -1, out hit, thrusterDistance))
            {
                // The thruster is within thrusterDistance to the ground. How far away?
                distancePercentage = 1 - (hit.distance / thrusterDistance);

                // Calculate how much force to push:
                downwardForce = transform.up * thrusterStrength * distancePercentage;
                // Correct the force for the mass of the car and deltaTime:
                downwardForce *= Time.deltaTime * GetComponent<Rigidbody>().mass;

                // Apply the force where the thruster is:
                GetComponent<Rigidbody>().AddForceAtPosition(downwardForce, thruster.position);
            }
        }
    }
}


using UnityEngine;
using System.Collections;

public class ThrusterScript : MonoBehaviour
{
    public float thrusterStrength;
    public float thrusterDistance;
    public Transform[] thrusters;
    public Rigidbody rb;
    private void FixedUpdate()
    {
        RaycastHit hit;
        foreach (Transform thruster in thrusters)
        {
            Vector3 downForce;
            float distancePercentage;
            if (Physics.Raycast(thruster.position, thruster.up * -1,out hit, thrusterDistance))
            {
                distancePercentage = 1 - (hit.distance/thrusterDistance);
                downForce =  transform.up * thrusterStrength * distancePercentage;
                downForce = downForce * Time.deltaTime * rb.mass;
                rb.AddForceAtPosition(downForce,thruster.position);
            }
        }

    }
}

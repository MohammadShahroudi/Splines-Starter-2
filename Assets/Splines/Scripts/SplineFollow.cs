using Unity.Mathematics;
using UnityEngine;

/*
 * SplineFollow rides a SplinePath. Each frame it moves along the path,
 * finds u, places itself on the curve, and faces the target or the tangent.
 */

public class SplineFollow : MonoBehaviour
{
    public SplinePath path;
    public Transform target;
    public float speed = 2.5f; // Positive world units per second in the completed exercise.
    public bool travelByDistance = true;
    public bool faceTarget = true;

    float _distance;
    float _u;

    void Update()
    {
        // Debug.Log("Total Length: " + path.TotalLength);
        if (travelByDistance)
        {
            // TODO: Advance distance by speed over the frame and look up u for that distance.
            // Stop at TotalLength.
            _distance += speed * Time.deltaTime;
            if (_distance >= path.TotalLength)
            {
                // Debug.Log("STOP");
                // Debug.Log("Speed: " + speed);
                speed = 0f;
                _distance = path.TotalLength;
            }
            // Debug.Log("Current Distance: " + _distance);
            // Debug.Log("Speed: " + speed);
            // Debug.Log(path.ParameterAtDistance(_distance));
            _u = path.ParameterAtDistance(_distance);
        }
        else
        {
            // TODO: Advance u in equal steps, paced so the trip takes as long as the distance
            // trip at the same speed. Stop at SegmentCount.
            _u += speed * Time.deltaTime;
            // Debug.Log("HI");
            // Debug.Log("U: " + _u);
            /*if ()
            {
                
            }*/
        }

        // TODO: Place this object at the path point for u. Replay should return it to the start.

        // TODO: Look at the target if faceTarget is on, otherwise along the path tangent.
        // Use world up so the horizon stays level.
    }

    public void Restart()
    {
        _distance = 0f;
        _u = 0f;
    }
}

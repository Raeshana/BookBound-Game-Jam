using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference: https://www.youtube.com/watch?v=UlEE6wjWuCY&list=PLrnPJCHvNZuCVTz6lvhR81nnaf1a-b67U&index=9

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int curWaypointIndex = 0;
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoints[curWaypointIndex].transform.position, transform.position) < 0.1f) // if the moving platform is touching the curWaypoint
        {
            curWaypointIndex++;
            if (curWaypointIndex >= waypoints.Length)
            {
                curWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[curWaypointIndex].transform.position, Time.deltaTime * speed); //if the frame rate of the device is higher, deltaTime will be smaller, vice versa. So the platform can always move 2f (speed) per second.
    }
}

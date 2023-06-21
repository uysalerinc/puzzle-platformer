using System;
using UnityEngine;

namespace DEMO.Core{
    
    public class MovingPlatform : MonoBehaviour {
        [SerializeField] Transform[] waypoints; 
        Transform currentWaypoint;
        Transform targetWaypoint;
        float platformSpeed = 5f;
        float timeSinceReachWaypoint = 0;
        float wayponitWaitTime = 1.5f;
        private float distanceTolerance = 0.1f;

        private void Awake() {
            currentWaypoint = waypoints[1];
            targetWaypoint = waypoints[0];
        }
        private void Update() {
            MoveAroundWaypoints();
            UpdateTimers();
        }

        private void MoveAroundWaypoints(){
             if (AtWaypoint()){
                timeSinceReachWaypoint = 0;
                SwapWaypoints();
            } 
            if (timeSinceReachWaypoint > wayponitWaitTime){
                transform.Translate((targetWaypoint.position - transform.position).normalized * platformSpeed * Time.deltaTime);
            }

        }

        private void SwapWaypoints()
        {
            (currentWaypoint, targetWaypoint) = (targetWaypoint, currentWaypoint);
        }

        private bool AtWaypoint()
        {
            float distanceToWaypoint = Vector2.Distance(transform.position, targetWaypoint.position);
            return distanceToWaypoint < distanceTolerance;
        }

        private void UpdateTimers()
        {
            timeSinceReachWaypoint += Time.deltaTime;
        }

        private void OnCollisionEnter2D(Collision2D other) {
            other.transform.SetParent(transform);
        }
        private void OnCollisionExit2D(Collision2D other) {
            other.transform.SetParent(null);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPSGame
{
    public class TPSEnvironmentScanner : MonoBehaviour
    {
        [SerializeField] private Vector3 forwardRayOffset = new Vector3(0, .25f, 0);
        [SerializeField] private float forwardRayLength = .8f;
        [SerializeField] private LayerMask obstacleLayer;
        internal ObsctableHitData ObstacleCheck()
        {
            var hitData = new ObsctableHitData();    
            var forwardOrigin = forwardRayOffset + transform.position;
            hitData.forwardHitFound = Physics.Raycast(forwardOrigin, transform.forward, 
                out hitData.forwardHit, forwardRayLength, obstacleLayer);

            Debug.DrawRay(forwardOrigin, transform.forward * forwardRayLength, (hitData.forwardHitFound)? Color.red : Color.white );

            if(hitData.forwardHitFound)
            {
                Debug.Log("hit found");
            }
            return hitData;
        }
    }
}
public struct ObsctableHitData
{
    public bool forwardHitFound;
    public RaycastHit forwardHit;
}

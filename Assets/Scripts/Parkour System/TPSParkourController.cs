using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPSGame
{
    public class TPSParkourController : MonoBehaviour
    {
        [SerializeField] private TPSEnvironmentScanner scanner;
        [SerializeField] private TPSPlayerController playerController;

        private void Awake()
        {
            scanner = GetComponent<TPSEnvironmentScanner>();
        }

        private void Update()
        {
            var hitData = scanner.ObstacleCheck();
            if(hitData.forwardHitFound)
            {
                //Parkour action
                Debug.Log("Obstcale Found" + hitData.forwardHit.transform.name);
                if (hitData.forwardHit.transform.gameObject.tag == "Ladder")
                {
                    //Implement Crounching
                    playerController.CrounchingAnimation();

                }
            }
            
        }
    }
}

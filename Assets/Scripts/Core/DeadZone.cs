using UnityEngine;

namespace DEMO.Core{
    
    public class DeadZone : MonoBehaviour {
    [SerializeField] Transform respawnPoint;
        private void OnCollisionEnter2D(Collision2D other) {
            GameObject player = other.gameObject;
            player.transform.position = respawnPoint.position;
        }
        
    }
}
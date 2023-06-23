using UnityEngine;

namespace DEMO.Core{
    
    public class Flag : MonoBehaviour {
        GameManager gameManager;
        private void Awake() {
            gameManager = FindObjectOfType<GameManager>();
        }
        
        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("Player")){
                gameManager.StopGame();
            }
        }
        
    }
}
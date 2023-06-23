using UnityEngine;

namespace DEMO.Core{
    
    public class BouncePad : MonoBehaviour {
        Animator animator;
        GameObject bounceObject;
        Rigidbody2D bounceObjectRB;
        [SerializeField] float bounceForce = 20f;
        private void Awake() {
            animator = GetComponent<Animator>();
        }
        
        private void OnCollisionEnter2D(Collision2D other) {
            bounceObjectRB = other.gameObject.GetComponent<Rigidbody2D>();
            if (bounceObjectRB == null) return;
            animator.SetTrigger("bounce");

        }
        // Triggered By Animation
        public void Bounce(){
            bounceObjectRB.velocity = Vector2.up*bounceForce;
        }
        
    }
}
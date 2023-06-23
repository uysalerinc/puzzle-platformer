using UnityEngine;
using DEMO.Control;

namespace DEMO.Core{
    
    public class Chest : MonoBehaviour {
        Animator animator;
        PlayerControl player;
        bool isChestOpen = false;
        bool canInteractWithPlayer = false;
        private void Awake() {
            animator = GetComponent<Animator>();
        }
        private void Update() {
            InteractWithPlayer();
        }
        private void OnTriggerEnter2D(Collider2D other){

            if (other.gameObject.tag != "Player") return;
            player = other.GetComponent<PlayerControl>();
            canInteractWithPlayer = true;
        }
        private void OnTriggerExit2D(Collider2D other) {
            if (other.gameObject.tag != "Player") return;
            player = null;
            if (isChestOpen) {
                CloseChest();
            }
            canInteractWithPlayer = false;
            
        }

        private void InteractWithPlayer()
        {
            if (!canInteractWithPlayer || player == null) return;

            if (player.hasKey && Input.GetKeyDown(KeyCode.E) && !isChestOpen){
                OpenChest();
            }else if (isChestOpen && Input.GetKeyDown(KeyCode.Escape)){
                CloseChest();
            }
        }

        private void OpenChest()
        {
            animator.SetTrigger("openChest");
            isChestOpen = true;
        }

        private void CloseChest()
        {
            animator.SetTrigger("closeChest");
            isChestOpen = false;
        }
    }
}
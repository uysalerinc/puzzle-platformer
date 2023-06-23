using UnityEngine;
using DEMO.Control;

namespace DEMO.Core{
   public class Collectable : MonoBehaviour {
    public enum Collectables{
        Coin,
        Key
    }
        public Collectables collectableType;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player"){
                PlayerControl player = other.GetComponent<PlayerControl>();
                if (this.collectableType == Collectables.Coin){
                    player.coins++;
                    Destroy(gameObject);
                } else if (this.collectableType == Collectables.Key){
                    player.hasKey = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}
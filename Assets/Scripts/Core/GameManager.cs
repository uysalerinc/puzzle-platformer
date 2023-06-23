using UnityEngine;
using TMPro;
using DEMO.Control;

namespace DEMO.Core{
    
    public class GameManager : MonoBehaviour {
        [SerializeField] GameObject coinTextGameObject;
        private TextMeshProUGUI coinText;
        [SerializeField] GameObject playerPrefab;
        [SerializeField] Transform spawnPoint;
        PlayerControl player;
        [HideInInspector] public bool isGameEnded = false;
        private void Awake() {
            player =  Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity).GetComponent<PlayerControl>();
            coinText = coinTextGameObject.GetComponent<TextMeshProUGUI>();
            coinText.color = Color.yellow;
        }
        private void Update() {
           coinText.text = "Coins: " + player.coins.ToString();

        }

        public void StopGame(){
            isGameEnded = true;
            Time.timeScale = 0;
        }
        
    }
}
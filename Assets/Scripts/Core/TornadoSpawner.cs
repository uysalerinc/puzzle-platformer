using UnityEngine;
using System.Collections;

namespace DEMO.Core{
    
    public class TornadoSpawner : MonoBehaviour {
        [SerializeField] GameObject tornadoPrefab;
        [SerializeField] Transform[] path;
        private GameManager gameManager;
        private GameObject spawnedTornado;
        [SerializeField] float spawnInterval = 2f;
        private void Awake() {
            gameManager = GameObject.FindObjectOfType<GameManager>();
        }

        private void Start() {
            StartCoroutine(SpawnTornados());
            
        }
        private IEnumerator SpawnTornados(){
            while (!gameManager.isGameEnded){
                spawnedTornado = Instantiate(tornadoPrefab, path[0].position, Quaternion.identity);
                spawnedTornado.GetComponent<Tornado>().targetTransform = path[1];
                yield return new WaitForSeconds(spawnInterval);
            }
            

        }


        
    }
}
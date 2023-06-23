using UnityEngine;

namespace DEMO.Core{
    
    public class Tornado : MonoBehaviour {
        [HideInInspector] public Transform targetTransform;
        [SerializeField] float tornadoSpeed = 5f;
        Vector3 distanceVector;
        float distanceTolerance = 0.1f;
        private void Update(){
            distanceVector = targetTransform.position - transform.position;
            if (distanceVector.magnitude <= distanceTolerance){
                Destroy(gameObject);
            }
            transform.Translate(distanceVector.normalized * tornadoSpeed * Time.deltaTime);
        }

    }
}
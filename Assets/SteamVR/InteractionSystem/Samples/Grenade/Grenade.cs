using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
    public class Grenade : MonoBehaviour
    {
        public GameObject spawnPartPrefab;

        public float minMagnitudeToSpawnTree = 1f;

        private Interactable interactable;

        public bool SpawnHere;

        private void Start()
        {
            interactable = this.GetComponent<Interactable>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("SpawnHere" + SpawnHere);
            if (interactable != null && interactable.attachedToHand != null)
            { //don't explode in hand
                SpawnHere = true;
                Debug.Log("SpawnHere" + SpawnHere);
                return;
            }
            if (collision.impulse.magnitude > minMagnitudeToSpawnTree && SpawnHere == true) {

                Debug.Log("SpawnHereActivated" + SpawnHere);
                GameObject explodePart = (GameObject)GameObject.Instantiate(spawnPartPrefab, this.transform.position, Quaternion.identity);
                //explodePart.transform.Rotate(this.transform.up);
                //explodePart.GetComponentInChildren<MeshRenderer>().material.SetColor("_TintColor", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
                Destroy(this.gameObject);
            }
        }
    }
}
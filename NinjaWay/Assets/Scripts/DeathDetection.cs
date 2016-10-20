using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class DeathDetection : MonoBehaviour {

        public FirstPersonController fpc;
        public GameObject deathText;

        void OnControllerColliderHit(ControllerColliderHit hit) {
            if (hit.gameObject.tag.Equals("KillZone"))
            {
                deathText.SetActive(true);
                fpc.moveCommand = "";
                fpc.isDead = true;
            }
        }
    }
}
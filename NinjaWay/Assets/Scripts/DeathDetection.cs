using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class DeathDetection : MonoBehaviour {

        public FirstPersonController fpc;
        public GameObject deathText;
		public AudioClip deathSound;
		private AudioSource audioSource;

        void OnControllerColliderHit(ControllerColliderHit hit) {
            if (hit.gameObject.tag.Equals("KillZone") && !fpc.isDead)
            {
                deathText.SetActive(true);
                if (!fpc.jumpCommand.Equals("")) {
                    fpc.jumpCommand = "";
                }
                fpc.moveCommand = "";
                fpc.isDead = true;
				PlayerPrefs.SetInt("highestScore", (int)transform.position.x);
				audioSource = GetComponent<AudioSource>();
				audioSource.clip = deathSound;
				audioSource.Play ();
            }
        }
    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrashScript : MonoBehaviour {

	public AudioClip sound;
	AudioSource audio;
	private static List<GameObject> invincibles = new List<GameObject>();

	void Start() {
		audio = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && !invincibles.Contains(other.gameObject))
		{
			audio.PlayOneShot(audio.clip, 1.0f);
		}
	}
}

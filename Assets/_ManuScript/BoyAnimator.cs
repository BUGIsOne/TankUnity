using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BoyAnimator : MonoBehaviour {
	private Animator anim;
	private Transform m_transform;
	// Use this for initialization
	void Start () {
		m_transform = this.transform;
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float h = CrossPlatformInputManager.GetAxis ("Horizontal");
		float v = CrossPlatformInputManager.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (h, 0, v);
		this.m_transform.Translate (movement * 6.0f * Time.deltaTime, Space.World);
		if (h != 0 || v != 0) {
			anim.SetFloat ("AniFlag", 1.0f);
		}
	}
}

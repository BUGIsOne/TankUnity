﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour {
	private float m_speed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.up * Time.deltaTime*m_speed);
	}
}

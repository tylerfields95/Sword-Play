﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneMusic : MonoBehaviour
{
	public AudioSource music;
	// Use this for initialization
	void Start ()
	{
		music = GetComponent<AudioSource>();
		music.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

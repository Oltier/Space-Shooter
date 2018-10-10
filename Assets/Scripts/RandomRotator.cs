﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
	public float Tumble;

	private void Start()
	{
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.angularVelocity = Random.insideUnitSphere * Tumble;
	}
}

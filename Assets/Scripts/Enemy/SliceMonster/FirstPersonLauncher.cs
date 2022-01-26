using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonLauncher : MonoBehaviour
{
	[SerializeField] private GameObject prefab;
	[SerializeField] private float power = 2;

    void Update()
	{

		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			GameObject projectile = GameObject.Instantiate(prefab, ray.origin, Quaternion.identity);
			Rigidbody rb = projectile.GetComponent<Rigidbody>();

			if (rb != null)
			{
				rb.velocity = ray.direction * power;
			}
		}
	}
}

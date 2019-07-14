using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilkaRuch : MonoBehaviour
{
	[SerializeField] private Vector2 wstepnaPredkosc;

	private Rigidbody2D rb;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();

		rb.AddForce(wstepnaPredkosc, ForceMode2D.Impulse);
	}
}

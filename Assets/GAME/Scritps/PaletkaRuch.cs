using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletkaRuch : MonoBehaviour
{
	[SerializeField] private float poziomPaletki = -4.5f; 

	void Update()
	{
		Vector2 pozycjaMyszki = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pozycjaMyszki.y = poziomPaletki;
		transform.position = pozycjaMyszki;
	}
}

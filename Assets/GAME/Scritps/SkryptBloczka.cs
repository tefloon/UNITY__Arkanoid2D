using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkryptBloczka : MonoBehaviour
{
	[SerializeField] int liczbaZyc = 3;

	int obecneZycia;
	SpriteRenderer sr;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Ball"))
		{
			obecneZycia--;
			UaktualnijKolor();

			if (obecneZycia <= 0)
			{
				Destroy(gameObject);
			}
		}
	}

	private void UaktualnijKolor()
	{
		float a = ((float)obecneZycia / (float)liczbaZyc);
		sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, a);
	}


	// Start is called before the first frame update
	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		obecneZycia = liczbaZyc;
	}


}

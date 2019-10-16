using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TworzenieMapy : MonoBehaviour
{
	[Header("Obiekty")]
	[SerializeField] GameObject prefabBloczka;
	[SerializeField] Transform start;
	[SerializeField] Transform rodzicBloczkow;

	[Header("Ustawienia")]
	[SerializeField] int liczbaKolumn = 20;
	[SerializeField] int liczbaRzedow = 5;

	[SerializeField] float odstepX;
	[SerializeField] float odstepY;

	void Start()
	{
		float szerBloczka = prefabBloczka.transform.localScale.x;
		float wysBloczka = prefabBloczka.transform.localScale.y;

		for (int y = 0; y < liczbaRzedow; y++)
		{
			for (int x = 0; x < liczbaKolumn; x++)
			{
				Vector2 miejsceBloczka = new Vector2(x * (szerBloczka + odstepX), -y * (wysBloczka + odstepY)) + (Vector2)start.position;

				Instantiate(prefabBloczka, miejsceBloczka, Quaternion.identity, rodzicBloczkow);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletkaOdbicie : MonoBehaviour
{
	[SerializeField] AnimationCurve mapowanieMiejsce_Kierunek;

	float polSzerokosciPaletki;
	Rigidbody2D rbPileczki;


	void Start()
	{
		polSzerokosciPaletki = transform.localScale.x / 2;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Sprawdzamy czy to piłka w nas wpadła
		if (collision.transform.CompareTag("Ball"))
		{
			// Dostajemy się do komponentu Rigidbody2D piłeczki
			rbPileczki = collision.gameObject.GetComponent<Rigidbody2D>();

			// Obliczamy odległość punktu odbicia od środka paletki
			// jako procent połowy jej długości. Czyli:
			// środek		= 0%
			// lewy brzeg	= -100%
			// prawy brzeg	= 100%
			float odlegloscSrodek = collision.contacts[0].point.x - transform.position.x;
			float procentOdSrodka = (odlegloscSrodek / polSzerokosciPaletki) * 100;

			// Wywołujemy funkcję zmieniającą kierunek odbicia w zależności odd tych procentów
			ZmianaKierunku(procentOdSrodka);
		}
	}

	private void ZmianaKierunku(float procentOdSrodka)
	{
		// Zapisujemy jak szybko leciała piłeczka przed odbiciem
		float staraWartoscPredkosci = rbPileczki.velocity.magnitude;

		// Zerujemy prędkość piłeczki
		rbPileczki.velocity = Vector2.zero;

		// Obliczamy pod jakim kątem powinna się odbić w zależności
		// od tego, jak daleko od środka paletki padła
		//float oIleObrocic = Pomocnicze.Mapuj(procentOdSrodka, -1, 1, -80, 80);
		float oIleObrocic = mapowanieMiejsce_Kierunek.Evaluate(procentOdSrodka);


		// Tworzymy nowy kierunek, poprzez wzięcie wektora jednostkowego do góry
		// i jego obrót zgodnie ze wskazówkami zegara (stąd obrót wokół -Vector3.forward)
		Vector2 nowyKierunek = Quaternion.AngleAxis(oIleObrocic, -Vector3.forward) * Vector2.up;

		// Mnożymy nowy kierunek przez starą prędkość, aby piłeczka po odbiciu
		// już w nową stronę miała taką samą prędkość liniową jak przed odbiciem
		rbPileczki.velocity = nowyKierunek * staraWartoscPredkosci;
	}

}

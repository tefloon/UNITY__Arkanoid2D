using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMapy : MonoBehaviour
{
	[SerializeField] private GameObject pileczkaGameObject;
	[SerializeField] private Transform miejscePoczatkowePileczki;
	[SerializeField] private Vector2 predkoscPoczatkowaPileczki;
	[SerializeField] private GameObject pileczkaPrefab;

	[SerializeField] private int liczbaPileczekMultiball = 3;

	public int obecnaLiczbaPileczek = 1;

	private void ResetPileczki(GameObject pileczka)
	{
		pileczka.transform.position = miejscePoczatkowePileczki.position;
		pileczka.GetComponent<Rigidbody2D>().velocity = predkoscPoczatkowaPileczki;
		pileczkaGameObject = pileczka;
	}


	private void StartMultiball()
	{
		for (int i = 0; i < liczbaPileczekMultiball; i++)
		{
			// Losujemy przesunięcie
			Vector2 przesuniecie = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));

			// Tworzymy piłeczkę
			var go = Instantiate(pileczkaPrefab, pileczkaGameObject.transform.position + (Vector3)przesuniecie, Quaternion.identity);


			// Losujemy kierunek prędkości
			Quaternion randomRotation = Random.rotation;

			// Rotujemy prędkość począkową zgodnie z wylosowanym kierunkiem
			go.GetComponent<Rigidbody2D>().velocity = randomRotation * predkoscPoczatkowaPileczki;

			obecnaLiczbaPileczek++;
		}
	}


	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			ResetPileczki(pileczkaGameObject);
		}

		if (Input.GetKeyDown(KeyCode.M))
		{
			StartMultiball();
		}
	}


	public void PileczkaWypadla(GameObject pileczka)
	{
		ResetPileczki(pileczka);
	}
}

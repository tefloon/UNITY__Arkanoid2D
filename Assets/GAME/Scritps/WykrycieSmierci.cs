using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WykrycieSmierci : MonoBehaviour
{
	[SerializeField] ManagerMapy managerMapy;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Ball"))
		{
			if (managerMapy.obecnaLiczbaPileczek > 1)
			{
				managerMapy.obecnaLiczbaPileczek--;
				Destroy(other.gameObject);
			}
			else
			{
				managerMapy.PileczkaWypadla(other.gameObject);
			}
		}
	}
}

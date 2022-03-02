using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	private void OnEnable()
	{
		transform.localScale = new Vector3(0.1f, 0.1f, 1f);
		InvokeRepeating("ScaleUp", 0.3f, 0.3f);
	}

	private void ScaleUp()
	{
		if (transform.localScale == Vector3.one)
		{
			ExplosionPool.Instance.ExplodeEnded(this.gameObject);
			CancelInvoke("ScaleUp");
		}
		transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, 1);
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy"))
		{
			GameController.Instance.IncreaseScore();
			collision.gameObject.GetComponent<Missile>().TimeToExplode();
			return;
		}
		else if (collision.CompareTag("Building") || collision.CompareTag("Tower"))
		{
			collision.gameObject.SetActive(false);
			GameController.Instance.DecreaseScore();
		}

		if (collision.CompareTag("Dot"))
			collision.gameObject.SetActive(false);
	}
}

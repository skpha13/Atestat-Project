using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
	//[SerializeField] float _launchForce = 500;
	[SerializeField] float _maxDragDistance = 5;

	int i=3;
	Vector2 _startPosition;
	Rigidbody2D _rigidbody2D;
	SpriteRenderer _spriteRenderer;
	public Text lifeText;

	void Update()
    {
		gameObject.SetActive(true);
		lifeText.text = i.ToString() + " VIETI";
		if (i==0 && _rigidbody2D.position==_startPosition)
			SceneManager.LoadScene("GameOver");
    }

    void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();	
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Start is called before the first frame update
	void Start()
    {
		_startPosition = transform.position;
        _rigidbody2D.isKinematic = true;
    }

	void OnMouseDown()
	{
		_spriteRenderer.color = Color.red;
	}

	void OnMouseUp()
	{
		float _power = 0;
		Vector2 currentPosition = _rigidbody2D.position;
		Vector2 direction = _startPosition - currentPosition;

		Debug.Log("power = " + _power);
		_power = Vector2.SqrMagnitude(direction);

		direction.Normalize();

		Debug.Log("power = " + _power);

		_rigidbody2D.isKinematic = false;
		_rigidbody2D.AddForce(direction * _power * 100);

		_spriteRenderer.color = Color.white;	
		i--;
	}

	void OnMouseDrag()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 desiredPosition = mousePosition;

		float distance = Vector2.Distance(desiredPosition, _startPosition);
		if(distance > _maxDragDistance)
		{
			Vector2 direction = desiredPosition - _startPosition;
			direction.Normalize();
			desiredPosition = _startPosition + (direction * _maxDragDistance);
		}

		if(desiredPosition.x > _startPosition.x)
			desiredPosition.x = _startPosition.x;

		_rigidbody2D.position = desiredPosition;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		StartCoroutine(ResetAfterDelay());
	}
	IEnumerator ResetAfterDelay()
	{
		yield return new WaitForSeconds(2);
		_rigidbody2D.position = _startPosition;
		_rigidbody2D.isKinematic = true;
		_rigidbody2D.velocity = Vector2.zero;
	}
}

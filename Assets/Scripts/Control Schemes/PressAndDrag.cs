using UnityEngine;
using System.Collections;

public class PressAndDrag : MonoBehaviour {
	private Vector3 startPosition = Vector3.zero;
	private Vector3 currentPosition;
	private bool active;
    private Vector2 angle;
    private float power;
    private float maxForce = 15f;
    private Vector3 cameraPos;

	public LineRenderer greenLine;
    public LineRenderer redLine;
    public Rigidbody2D rigidBody;

    void Start()
    {
        greenLine.material = new Material(Shader.Find("UI/Default"));
        greenLine.SetWidth(.2f, .2f);
        redLine.material = new Material(Shader.Find("UI/Default"));
        redLine.SetWidth(.2f, .2f);
        greenLine.sortingOrder = 10;
        redLine.sortingOrder = 10;
    }

	void Update () {
        if (rigidBody != null)
        {
            if (startPosition != Vector3.zero)
            {
                startPosition += Camera.main.transform.position - cameraPos;
                currentPosition += Camera.main.transform.position - cameraPos;
            }
            cameraPos = Camera.main.transform.position;

            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    startPosition = Input.GetTouch(0).position;
                    startPosition = Camera.main.ScreenToWorldPoint(startPosition);
                }
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    currentPosition = Input.GetTouch(0).position;
                    currentPosition = Camera.main.ScreenToWorldPoint(currentPosition);
                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    applyForce();
                    startPosition = Vector3.zero;
                    currentPosition = Vector3.zero;
                }
            }

            if (currentPosition != Vector3.zero)
            {
                greenLine.SetPosition(0, new Vector3(startPosition.x, startPosition.y, 90f));
                greenLine.SetPosition(1, new Vector3(currentPosition.x, currentPosition.y, 90f));
                redLine.SetPosition(0, new Vector3(startPosition.x, startPosition.y, 90f));
                redLine.SetPosition(1, new Vector3(currentPosition.x, currentPosition.y, 90f));
                angle = startPosition - currentPosition;
                angle.Normalize();
                setLineColor();
            }
            else
            {
                greenLine.SetPosition(0, Vector3.zero);
                greenLine.SetPosition(1, Vector3.zero);
                redLine.SetPosition(0, Vector3.zero);
                redLine.SetPosition(1, Vector3.zero);
                angle = Vector2.zero;
            }
        }
        else
        {
            greenLine.SetPosition(0, Vector3.zero);
            greenLine.SetPosition(1, Vector3.zero);
            redLine.SetPosition(0, Vector3.zero);
            redLine.SetPosition(1, Vector3.zero);
            startPosition = Vector3.zero;
            currentPosition = Vector3.zero;
        }
    }

    void setLineColor()
    {
        float distance = Vector3.Distance(startPosition, currentPosition);
        float percentage = distance / 8f;

        if(percentage <= 1)
        {
            Color green = Color.green;
            green.a = 1 - percentage;
            greenLine.SetColors(green, green);
            Color red = Color.red;
            red.a = percentage;
            redLine.SetColors(red, red);
            power = percentage;
        }
        else
        {
            Color green = Color.green;
            green.a = 0;
            greenLine.SetColors(green, green);
            Color red = Color.red;
            red.a = 1;
            redLine.SetColors(red, red);
            power = 1;
        }
    }

    void applyForce()
    {
        if (rigidBody.isKinematic == true)
        {
            rigidBody.isKinematic = false;
            float force = power * maxForce;
            rigidBody.AddForce(angle * force, ForceMode2D.Impulse);
        }
    }

	Vector3 StartPosition {
		get {
			return this.startPosition;
		}
		set {
			startPosition = value;
		}
	}

	Vector3 CurrentPosition {
		get {
			return this.currentPosition;
		}
		set {
			currentPosition = value;
		}
	}

	bool Active {
		get {
			return this.active;
		}
		set {
			active = value;
		}
	}

    public float Power
    {
        get
        {
            return power;
        }

        set
        {
            power = value;
        }
    }

    public Vector2 Angle
    {
        get
        {
            return angle;
        }

        set
        {
            angle = value;
        }
    }
}

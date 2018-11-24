using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPController : MonoBehaviour {

    public float speed = 1f;

    private Transform cam;
    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    private float mouseSensitivity = 100f;
    private float verticalLookRotation;

    private int count;
    public Text countText;
    public Text winText;
    public Text objText;
    private float tiempoStart = 0.0f;
    private float tiempoFinal = 0.0f;
    private int opc;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        count = 0;
        SetCountText();
        winText.text = "";
        objText.text = "";
        opc = 0;
    }

    void Update()
    {
        cam = Camera.main.transform;

        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");
        float zMov = Input.GetAxisRaw("Jump");

        Vector3 movHor = transform.right * xMov;    //(1,0,0)
        Vector3 movVer = transform.forward * yMov;  //(0,0,1)
        Vector3 movUp = transform.up * zMov;    //(0,1,0)
        velocity = (movHor + movVer + movUp).normalized * speed;

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity);
        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        cam.localEulerAngles = Vector3.left * verticalLookRotation;

        tiempoStart += Time.deltaTime;

        //Debug.Log("delta" + Time.deltaTime);
        if (tiempoStart >= tiempoFinal) {
            objText.text = "";
        }

        if (tiempoStart >= tiempoFinal && count >= 70)
        {
            Application.LoadLevel("creditos");
        }

    }

    private void FixedUpdate()
    {

        if (velocity != Vector3.zero)
        {

            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {

            other.gameObject.SetActive(false);

            encontrarOpc(other.gameObject.name);
            nombreObj();

            count = count + 10;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Puntos: " + count.ToString();
        if (count >= 70)
        {
            winText.text = "¡Encontraste todas tus cosas!";

        }
    }

    void encontrarOpc(string objeto)
    {
        if (objeto == "pickUp_1")
        {
            opc = 1;
            

        }
        else if (objeto == "pickUp_2")
        {
            opc = 2;
        }
        else if (objeto == "pickUp_3")
        {
            opc = 3;
        } else if (objeto == "pickUp_4")
        {
            opc = 4;
        }
        else if (objeto == "pickUp_5")
        {
            opc = 5;
        }
        else if (objeto == "pickUp_6")
        {
            opc = 6;
        }
        else if (objeto == "pickUp_7")
        {
            opc = 7;
        }

    }

    void nombreObj() {
        switch (opc) {
            case 1:
                objText.text = "¡Encontraste tu cuaderno!";
                tiempoFinal = tiempoStart + 4;
                break;
            case 2:
                objText.text = "¡Encontraste tu cartera!";
                tiempoFinal = tiempoStart + 4;
                break;
            case 3:
                objText.text = "¡Encontraste tu celular!";
                tiempoFinal = tiempoStart + 4;
                break;
            case 4:
                objText.text = "¡Encontraste tu dinero!";
                tiempoFinal = tiempoStart + 4;
                break;
            case 5:
                objText.text = "¡Encontraste tu lapiz!";
                tiempoFinal = tiempoStart + 4;
                break;
            case 6:
                objText.text = "¡Encontraste tu mochila!";
                tiempoFinal = tiempoStart + 4;
                break;
            case 7:
                objText.text = "¡Encontraste tu laptop!";
                tiempoFinal = tiempoStart + 2;
                break;
        }
    }
}


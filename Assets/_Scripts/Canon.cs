using UnityEngine;
using UnityEngine.InputSystem;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject BalaPrefab;
    private GameObject puntaCanon;
    private float rotacion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puntaCanon = transform.Find("PuntaCanon").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard teclado = Keyboard.current;
        if (teclado == null) return;

        float horizontal = 0f;
        if (teclado.dKey.isPressed || teclado.rightArrowKey.isPressed) horizontal += 1f;
        if (teclado.aKey.isPressed || teclado.leftArrowKey.isPressed) horizontal -= 1f;

        rotacion += horizontal * AdministradorJuego.VelocidadRotacion;
        if(rotacion <= 90 && rotacion >= 0)
        {
            transform.eulerAngles = new Vector3(rotacion, 90, 0.0f);
        }

        if(rotacion > 90) rotacion = 90;
        if(rotacion < 0) rotacion = 0;

        if (teclado.spaceKey.wasPressedThisFrame)
        {
            GameObject temp = Instantiate(BalaPrefab, puntaCanon.transform.position, transform.rotation);
            Rigidbody tempRB = temp.GetComponent<Rigidbody>();
            Vector3 direccionDisparo = transform.rotation.eulerAngles;
            direccionDisparo.y = 90 - direccionDisparo.x;
            tempRB.linearVelocity = direccionDisparo.normalized * AdministradorJuego.velocidadBala;
        }



    }
}

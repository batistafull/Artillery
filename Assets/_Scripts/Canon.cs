using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Canon : MonoBehaviour
{

    public static bool Bloqueado;

    public AudioClip clipDisparo;
    private GameObject SonidoDisparo;
    private AudioSource SourceDisparo;

    [SerializeField] private GameObject BalaPrefab;
    public GameObject particulaDisparo;
    private GameObject puntaCanon;
    private float rotacion;
    
    public CanonControls canonControls;
    private InputAction apuntar;
    private InputAction modificarFuerza;
    private InputAction disparar;

    public GameObject canvasPausa;

    private void Awake()
    {
        canonControls = new CanonControls();
    }

    private void OnEnable()
    {
        apuntar = canonControls.Canon.Apuntar;
        modificarFuerza = canonControls.Canon.ModificarFuerza;
        disparar = canonControls.Canon.Disparar;
        apuntar.Enable();
        modificarFuerza.Enable();
        disparar.Enable();
        disparar.performed += Disparar;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puntaCanon = transform.Find("PuntaCanon").gameObject;
        SonidoDisparo = GameObject.Find("SonidoDisparo");
        SourceDisparo = SonidoDisparo.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0) return;

        rotacion += apuntar.ReadValue<float>() * AdministradorJuego.VelocidadRotacion;
        if(rotacion <= 90 && rotacion >= 0)
        {
            transform.eulerAngles = new Vector3(rotacion, 90, 0.0f);
        }

        if(rotacion > 90) rotacion = 90;
        if(rotacion < 0) rotacion = 0;

    }

    private void Disparar(InputAction.CallbackContext context)
    {
        if(AdministradorJuego.DisparosPorJuego > 0 && !canvasPausa.activeSelf){
            GameObject temp = Instantiate(BalaPrefab, puntaCanon.transform.position, transform.rotation);
            Rigidbody tempRB = temp.GetComponent<Rigidbody>();
            SeguirCamara.objetivo = temp;
            Vector3 direccionDisparo = transform.rotation.eulerAngles;
            direccionDisparo.y = 90 - direccionDisparo.x;
            Vector3 direccionParticulas = new Vector3(-90 + direccionDisparo.x, 90, 0);
            GameObject Particulas = Instantiate(particulaDisparo, puntaCanon.transform.position, Quaternion.Euler(direccionParticulas), transform);
            tempRB.linearVelocity = direccionDisparo.normalized * AdministradorJuego.velocidadBala;
            SourceDisparo.PlayOneShot(clipDisparo);
            Bloqueado = true;
            AdministradorJuego.DisparosPorJuego--;
        }

    }

}

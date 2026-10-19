using UnityEngine;

public class AdministradorJuego : MonoBehaviour
{
    public static AdministradorJuego SingletonAdministradorJuego;

    private static int _velocidadBala;
    private static int _disparoPorJuego;
    private static float _velocidadRotacion;

    public GameObject CanvasGanar;
    public GameObject CanvasPerder;

    private void Awake()
    {
        if(SingletonAdministradorJuego == null)
        {
            SingletonAdministradorJuego = this;
            _velocidadBala = 30;
            _disparoPorJuego = 5;
            _velocidadRotacion = 1;
        }
        else
        {
            Debug.LogError("Ya existe una instancia de esta clase");
        }
    }

    private void Update()
    {
        if(DisparosPorJuego < 0)
        {
            PerderJuego();
        }
    }

    public void GanarJuego()
    {
        CanvasGanar.SetActive(true);
    }

    public void PerderJuego()
    {
        CanvasPerder.SetActive(true);
    }

    public static int velocidadBala
    {
        get => _velocidadBala;
        set => _velocidadBala = value;
    }

    public static int DisparosPorJuego
    {
        get => _disparoPorJuego;
        set => _disparoPorJuego = value;
    }

    public static float VelocidadRotacion
    {
        get => _velocidadRotacion;
        set => _velocidadRotacion = value;
    }

    
}

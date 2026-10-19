using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvaGame : MonoBehaviour
{
    public GameObject Canvasgame;
    public Button buttonPause;
    public TMP_Text balaText;

    public Slider velocidadBala;

    private void Start()
    {
        velocidadBala.value = AdministradorJuego.velocidadBala;
        velocidadBala.onValueChanged.AddListener(CambiarVelocidadBala);
    }

    public void CambiarVelocidadBala(float valor)
    {
        AdministradorJuego.velocidadBala = Mathf.RoundToInt(valor);
    }

    public void Update()
    {
        balaText.text = AdministradorJuego.DisparosPorJuego.ToString();
    }

    public void PauseGame()
    {
        buttonPause.gameObject.SetActive(false);
        Canvasgame.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitPause()
    {
        buttonPause.gameObject.SetActive(true);
        Canvasgame.SetActive(false);
        Time.timeScale = 1;
    }

}

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("GAME OVER UI")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public Button reiniciarButton;
    public Button menuButton;

    [Header("GAME WIN UI")]
    public GameObject gameWinPanel;
    public TextMeshProUGUI gameWinText;
    public Button menuWinButton;

    private bool gameOverActivo = false;
    private bool gameWinActivo = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        // Ocultar paneles iniciales
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (gameWinPanel != null) gameWinPanel.SetActive(false);

        // Botones Game Over
        if (reiniciarButton != null)
            reiniciarButton.onClick.AddListener(ReiniciarEscena);

        if (menuButton != null)
            menuButton.onClick.AddListener(IrAlMenu);

        // Botones Game Win
        if (menuWinButton != null)
            menuWinButton.onClick.AddListener(IrAlMenu);
    }

    // ---------------- GAME OVER ----------------
    public void GameOver()
    {
        if (gameOverActivo || gameWinActivo) return;

        gameOverActivo = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (gameOverText != null)
            gameOverText.text = 
                "GAME OVER\n\nR - Reiniciar\nESC / M - Menu Principal";
    }

    // ---------------- GAME WIN ----------------
    public void GameWin()
    {
        if (gameWinActivo || gameOverActivo) return;

        gameWinActivo = true;

        if (gameWinPanel != null)
            gameWinPanel.SetActive(true);

        if (gameWinText != null)
            gameWinText.text =
                "VICTORIA\n\n¡Has completado el nivel!";
    }

    // ---------------- MÉTODOS GLOBALES ----------------
    public void ReiniciarEscena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}

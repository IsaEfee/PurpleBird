using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("Skor Ayarları")]
    public int score = 0;
    public TextMeshProUGUI scoreText; // Oyun içindeki skor

    [Header("Game Over Paneli Ayarları")]
    public GameObject gameOverPanel;        // Senin hazırladığın hazır panel
    public TextMeshProUGUI finalScoreText;   // Paneldeki skor yazısı

    [Header("Ses Ayarları")]
    public AudioClip flapSound;   // Uçuş sesi (fly)
    public AudioClip scoreSound;  // Puan sesi (clam)
    public AudioClip crashSound;  // Çarpma sesi
    private AudioSource audioSource;

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        // Oyun her açıldığında veya yeniden başladığında zamanı akıt
        Time.timeScale = 1f; 
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        PlaySound(scoreSound); // Puan sesini çal
    }

    public void GameOver()
    {
        if (gameOverPanel.activeSelf) return; // Panel zaten açıksa tekrar çalışma

        PlaySound(crashSound); // Çarpma sesini çal
        gameOverPanel.SetActive(true); 
        finalScoreText.text = score.ToString();
        scoreText.gameObject.SetActive(false);
        
        Time.timeScale = 0f; // Oyunu durdur
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Zamanı normale döndür
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
{
    Debug.Log("Closing Game..."); // Unity içinde çalışıp çalışmadığını anlamak için
    Application.Quit(); // Gerçek oyun dosyasında oyunu kapatır
}

    public void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
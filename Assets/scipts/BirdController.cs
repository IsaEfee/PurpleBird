using UnityEngine;
using UnityEngine.InputSystem; 
using UnityEngine.SceneManagement; 

public class BirdController : MonoBehaviour
{
    // DİĞER SCRIPTLERİN HATASINI DÜZELTEN SATIR:
    public static BirdController instance;

    public float jumpForce = 5f; 
    private Rigidbody2D rb; 
    
    public bool isDead = false; 

    void Awake()
    {
        // Kendini sisteme tanıtıyor
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isDead = false; 
        Time.timeScale = 1f; // Zamanın aktığından emin olalım
    }

    void Update()
{
    bool actionPressed = false;

    if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
    {
        actionPressed = true;
    }
    if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
    {
        actionPressed = true;
    }

    // EĞER ÖLDÜYSE BURADA HİÇBİR ŞEY YAPMA (Sahne yükleme kodunu sildik)
    if (isDead) return; 

    if (actionPressed)
    {
        rb.linearVelocity = Vector2.up * jumpForce;
    }
}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true; 
        if (GameManager.instance != null)
        {
            GameManager.instance.GameOver();
        }
    }
}
using UnityEngine;

public class ScoreSensor : MonoBehaviour
{
    // Bir obje bu sensörün (Trigger) içine girdiğinde otomatik çalışır
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eğer içinden geçen objenin adı "Bird" ise (Kuş objesinin adının tam olarak böyle olduğundan emin ol)
        if (collision.gameObject.name == "Bird")
        {
            // GameManager'daki puan artırma fonksiyonunu çalıştır
            GameManager.instance.AddScore();
        }
    }
}
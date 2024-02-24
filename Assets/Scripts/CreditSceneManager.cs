using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSceneManager : MonoBehaviour
{
    public GameObject Credit; // Objek bola yang ingin dipantau
    public float maxHeight = 400f; // Batas maksimum posisi Y

    void Update()
    {
        // Periksa posisi Y dari objek bola setiap frame
        if (Credit.transform.position.y >= maxHeight)
        {
            // Jika posisi Y melewati batas, hentikan permainan
            EndGame();
        }
    }

    void EndGame()
    {
        // Menutup permainan
        Application.Quit();
    }
}
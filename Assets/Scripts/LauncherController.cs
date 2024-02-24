using System.Collections;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider bola;
    public KeyCode input;
    public Renderer launcherRenderer; // Komponen Renderer dari objek Launcher
    public Color holdColor = Color.red; // Warna yang diinginkan ketika tombol ditekan
    private Color originalColor; // Warna asli objek Launcher

    public float maxTimeHold;
    public float maxforce;

    private bool isHold = false;

    private void Start()
    {
        // Simpan warna asli objek Launcher
        originalColor = launcherRenderer.material.color;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
            ReadInput(bola);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input))
        {
            StartCoroutine(StartHold(collider));
            // Ubah warna objek Launcher saat tombol ditekan
            launcherRenderer.material.color = holdColor;
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxforce, timeHold / maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * maxforce);
        isHold = false;

        // Kembalikan warna objek Launcher ke warna aslinya
        launcherRenderer.material.color = originalColor;
    }
}

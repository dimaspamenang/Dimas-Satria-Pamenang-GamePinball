using System.Collections;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    public Collider bola;
    public Material offMaterial;
    public Material onMaterial;
    public GameObject soundPrefab; // Prefab gameobject untuk efek suara
    public GameObject vfxPrefab; // Prefab gameobject untuk efek visual

    private SwitchState state;
    private Renderer switchRenderer;

    public ScoreManager scoreManager;
    public float score;

    private void Start()
    {
        switchRenderer = GetComponent<Renderer>();

        Set(false);

        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola && bola != null)
        {
            Toggle();
            PlaySound(); // Panggil fungsi untuk memainkan efek suara
            PlayVFX(); // Panggil fungsi untuk memainkan efek visual
        }
    }

    private void Set(bool active)
    {
        if (active)
        {
            state = SwitchState.On;
            switchRenderer.material = onMaterial;
        }
        else
        {
            state = SwitchState.Off;
            switchRenderer.material = offMaterial;
        }
    }

    private void Toggle()
    {
        Set(state != SwitchState.On);
        scoreManager.AddScore(score);
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            switchRenderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            switchRenderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.On;
        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }

    private void PlaySound()
    {
        // Memainkan suara menggunakan prefab gameobject
        GameObject soundInstance = Instantiate(soundPrefab, transform.position, Quaternion.identity);
        AudioSource audioSource = soundInstance.GetComponent<AudioSource>();
        audioSource.Play();

        // Hancurkan prefab gameobject suara setelah 3 detik
        Destroy(soundInstance, 3f);
    }

    private void PlayVFX()
    {
        // Memainkan efek visual menggunakan prefab gameobject
        Instantiate(vfxPrefab, transform.position, Quaternion.identity);
    }
}

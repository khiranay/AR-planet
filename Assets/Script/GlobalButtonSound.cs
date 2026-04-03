using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Penting untuk deteksi pindah scene

public class GlobalButtonSound : MonoBehaviour
{
    public static GlobalButtonSound instance;
    private AudioSource audioSource;

    void Awake()
    {
        // SISTEM SINGLETON: Memastikan hanya ada 1 Sound Manager di seluruh game
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Objek ini TIDAK AKAN HANCUR saat pindah scene
        }
        else
        {
            Destroy(gameObject); // Jika ada duplikat di scene lain, hapus yang baru
            return;
        }
    }

    void OnEnable()
    {
        // Mendaftarkan fungsi OnSceneLoaded agar jalan setiap kali scene berubah
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Membersihkan pendaftaran saat objek dinonaktifkan
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        CariDanPasangSuaraKeSemuaButton();
    }

    // Fungsi ini otomatis terpanggil setiap kali kamu pindah scene
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CariDanPasangSuaraKeSemuaButton();
    }

    public void CariDanPasangSuaraKeSemuaButton()
    {
        // Mencari semua Button di scene (termasuk yang sedang tidak aktif/hidden)
        Button[] allButtons = Resources.FindObjectsOfTypeAll<Button>();

        foreach (Button btn in allButtons)
        {
            // Pastikan Button tersebut memang ada di dalam Scene (bukan di folder Project/Prefab)
            if (btn.gameObject.scene.name != null)
            {
                // Hapus listener lama supaya suara tidak double kalau script terpanggil lagi
                btn.onClick.RemoveListener(PlayClickSound);
                // Pasang fungsi PlayClickSound ke tombol
                btn.onClick.AddListener(PlayClickSound);
            }
        }
    }

    void PlayClickSound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            // PlayOneShot membuat suara bisa bertumpuk jika diklik sangat cepat (tidak terpotong)
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
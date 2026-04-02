using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class InteractiveARObject : MonoBehaviour
{
    [Header("Auto Animation")]
    public float rotationSpeed = 50f;
    public float floatAmplitude = 0.05f; // Kecilkan sedikit agar tidak liar
    public float floatFrequency = 1f;

    private float timer;

    void Update()
    {
        // 1. Animasi Rotasi Otomatis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);

        // 2. Animasi Melayang yang Halus
        // Kita gunakan sin untuk menggerakkan objek secara relatif
        timer += Time.deltaTime * floatFrequency;
        float moveAmount = Mathf.Sin(timer) * floatAmplitude;
        
        // Menggerakkan objek ke atas/bawah tanpa menimpa posisi dari Lean Drag
        transform.Translate(Vector3.up * moveAmount * Time.deltaTime, Space.World);
    }
}

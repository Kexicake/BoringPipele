using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Технические поля")]
    [SerializeField]
    private float size = 2.5f;

    [Header("Объект для следования")]
    [SerializeField]
    private Transform target;

    [Header("Скорость следования")]
    [SerializeField]
    private float speed = 10f;

    private Camera cachedCamera;

    private void Start()
    {
        transform.position = target.position + Vector3.back * 10;

        cachedCamera = GetComponent<Camera>();
        if (cachedCamera != null)
            cachedCamera.orthographicSize = target.localScale.x * size;
    }

    private void FixedUpdate()
    {
        Vector3 targetPlanePosition = transform.position;
        targetPlanePosition.z = 0;

        Vector3 newPosition = Vector3.Lerp(targetPlanePosition, target.position, speed * Time.fixedDeltaTime);
        transform.position = newPosition + Vector3.back * 10;
    }
}

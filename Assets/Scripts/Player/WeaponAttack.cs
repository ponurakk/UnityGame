using System.Collections;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public int weaponDamage;

    public float rotationAmount;
    public float duration;

    private bool isRotating;
    private Quaternion originalRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        isRotating = false;
        originalRotation = transform.rotation;
        targetRotation = Quaternion.Euler(originalRotation.eulerAngles + new Vector3(0, 0, rotationAmount));
        GetComponent<CapsuleCollider2D>().enabled = false;
    }

    private IEnumerator RotateAndReturn()
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            transform.rotation = Quaternion.Slerp(originalRotation, targetRotation, t);

            yield return null;
        }

        transform.rotation = originalRotation;
        GetComponent<CapsuleCollider2D>().enabled = false;
        isRotating = false;
    }

    public void SwichRotation()
    {
        if (!isRotating)
        {
            rotationAmount = -rotationAmount;
            targetRotation = Quaternion.Euler(originalRotation.eulerAngles + new Vector3(0, 0, rotationAmount));
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isRotating == false)
        {
            GetComponent<CapsuleCollider2D>().enabled = true;
            isRotating = true;
            StartCoroutine(RotateAndReturn());
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            collider.gameObject.GetComponent<EnemyManager>().TakeDamage(weaponDamage);
        }
    }
}

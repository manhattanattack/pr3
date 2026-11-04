using System.Collections;
using UnityEngine;

public class MeleeAnimator : MonoBehaviour
{
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private float swingAngle = 60f;
    [SerializeField] private float swingSpeed = 12f;

    private bool isSwinging = false;
    private Quaternion initialRotation;

    private void Start()
    {
        if (weaponHolder != null)
            initialRotation = weaponHolder.localRotation;
    }

    public void PlaySwing()
    {
        if (!isSwinging && weaponHolder != null)
            StartCoroutine(SwingRoutine());
    }

    private IEnumerator SwingRoutine()
    {
        isSwinging = true;
        Quaternion forwardRotation = initialRotation *
            Quaternion.Euler(swingAngle, 0f, -swingAngle / 2f);

        float progress = 0f;
        while (progress < 1f)
        {
            progress += Time.deltaTime * swingSpeed;
            weaponHolder.localRotation =
                Quaternion.Slerp(initialRotation, forwardRotation, progress);
            yield return null;
        }

        progress = 0f;
        while (progress < 1f)
        {
            progress += Time.deltaTime * (swingSpeed * 0.7f);
            weaponHolder.localRotation =
                Quaternion.Slerp(forwardRotation, initialRotation, progress);
            yield return null;
        }

        weaponHolder.localRotation = initialRotation;
        isSwinging = false;
    }
}

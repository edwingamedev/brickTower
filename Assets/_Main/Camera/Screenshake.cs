using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour
{
    //shake
    public Transform shakePivot;
    public float startingShakeDistance; // Set in the inspector
    public float decreasePercentage; // Set in the inspector
    public float shakeSpeed; // Set in the inspector
    public int nbrOfShakes; // Set in the inspector
    private float shakeCounter;
    private float distanceCounter;
    float originalPosition;

    private void Start()
    {
        originalPosition = shakePivot.localPosition.x;
    }

    public void Shake()
    {
        StartCoroutine(Shaking());
    }

    private IEnumerator Shaking()
    {
        //CAMERA SHAKE
        float hitTime = Time.time;

        shakeCounter = nbrOfShakes;
        distanceCounter = startingShakeDistance;

        while (shakeCounter > 0)
        {
            float timer = (Time.time - hitTime) * shakeSpeed;

            shakePivot.localPosition = new Vector3(originalPosition + Mathf.Sin(timer) * distanceCounter, shakePivot.localPosition.y, shakePivot.localPosition.z);

            if (timer > Mathf.PI * 2)
            {
                hitTime = Time.time;
                distanceCounter *= decreasePercentage;
                shakeCounter--;
            }

            yield return null;
        }

        shakePivot.localPosition = new Vector3(originalPosition, shakePivot.localPosition.y, shakePivot.localPosition.z);


        yield return null;
    }
}

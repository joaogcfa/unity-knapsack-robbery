using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardRotation : MonoBehaviour
{
    public float rotation;
    public float initialRotation;
    public int hasRotated;
    public bool stopRotation;
    public bool initialState;

    public bool clockwise;
    public bool canRotate;
    float rotateCtrl = 0;

    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.eulerAngles.z;
        initialRotation = transform.eulerAngles.z;
        clockwise = false;
        canRotate = true;
        stopRotation = false;
        initialState = true;
        hasRotated = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(canRotate)
        {
            rotation = transform.eulerAngles.z;
            if(rotation > initialRotation + 90) {
                rotation -= 180;
            }

            if(hasRotated == 2 && rotation > initialRotation - 5 && rotation < initialRotation + 5) {
                hasRotated = 0;
                stopRotation = true;
                if(initialState) {
                    transform.eulerAngles = new Vector3(0f, 0f, initialRotation);
                    initialState = false;
                    rotateCtrl = 0;
                    StartCoroutine(Rotate_180());
                } else {
                    transform.eulerAngles = new Vector3(0f, 0f, -initialRotation);
                    initialState = true;
                    rotateCtrl = 0;
                    StartCoroutine(Rotate_180());
                }
            }

            if(rotation > initialRotation + 85) {
                clockwise = true;
                hasRotated++;
            } else if (rotation  < initialRotation - 85) {
                clockwise = false;
                hasRotated++;
            }

            if(rotation < initialRotation + 85 && !clockwise && !stopRotation) {
                transform.Rotate(0.0f, 0.0f, 0.25f); 
            } else if (rotation > initialRotation - 90 && rotation <= initialRotation + 89 && clockwise && !stopRotation) {
                transform.Rotate(0.0f, 0.0f, -0.25f);
            }
        }

        IEnumerator Rotate_180() {
            if(rotateCtrl == 180) {
                hasRotated = 0;
                yield break;
            }
            
            rotateCtrl++;
            transform.Rotate(0f, 0f, 1f);
            yield return new WaitForSeconds(0.0000125f); 
            StartCoroutine(Rotate_180());
        }
    }
}

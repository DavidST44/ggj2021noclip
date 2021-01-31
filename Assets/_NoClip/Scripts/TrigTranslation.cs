using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigTranslation : MonoBehaviour
{
    Vector3 initPos;
   public Vector3 magnitude = Vector2.one;
   public Vector3 frequency = Vector3.one;
   public Vector3 phase = Vector3.zero;
    float myTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;

        transform.localPosition = initPos +
            new Vector3(
                Mathf.Sin(myTime * frequency.x * Mathf.PI + phase.x * Mathf.PI) * magnitude.x,
                Mathf.Sin(myTime * frequency.y * Mathf.PI + phase.y * Mathf.PI) * magnitude.y,
                Mathf.Sin(myTime * frequency.z * Mathf.PI + phase.z * Mathf.PI) * magnitude.z);
    }
}

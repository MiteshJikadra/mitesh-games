using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float currentVelocity;
    private float currentrotation;
    private float offset;
    public float smoothTime = 0.5f;
    public float smoothrotationTime = 0.5f;
    private float m_curpos;
    public float distance = 0.01f;
    public float x_offsetSpeed = 100;
    public Material tube;
    public Transform PlayerTransform;
    // Start is called before the first frame update
    void Start()
    {
        this.offset = base.transform.position.z - PlayerTransform.position.z;
        m_curpos = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        float zpos = transform.position.z;
        if (zpos - m_curpos > distance)
        {
            Vector2 offset = tube.GetTextureOffset("_MainTex");
            offset.x -= x_offsetSpeed * Time.deltaTime;
            tube.SetTextureOffset("_MainTex", offset);
            m_curpos = zpos;
        }
    }
    private void FixedUpdate()
    {
        this.UpdateFollow(Time.deltaTime);
    }
    private void UpdateFollow(float deltaTime)
    {
        if (PlayerTransform != null)
        {
            Vector3 vector = PlayerTransform.position;
            Vector3 position = base.transform.position;
            position.z = Mathf.SmoothDamp(position.z - this.offset, vector.z, ref this.currentVelocity, this.smoothTime, float.PositiveInfinity, deltaTime) + this.offset;
            base.transform.position = position;
        }
    }
    void OnDestroy()
    {
        tube.SetTextureOffset("_MainTex", Vector2.zero);
    }
}

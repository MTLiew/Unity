using System.Collections;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CameraControl : MonoBehaviour
{
    public CinemachineFreeLook iCamera;
    public PlayerController player;
    [SerializeField] public UnityEvent RecenterFinish = new UnityEvent();

    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            iCamera.m_YAxis.m_InputAxisName = "Mouse Y";
            iCamera.m_XAxis.m_InputAxisName = "Mouse X";

            iCamera.m_YAxisRecentering.m_enabled = false;
            iCamera.m_RecenterToTargetHeading.m_enabled = false;
        }

        else
        {
            iCamera.m_YAxis.m_InputAxisName = "";
            iCamera.m_XAxis.m_InputAxisName = "";
        }

        if (Input.mouseScrollDelta.y > Vector2.zero.y)
        {
            if (iCamera.m_Orbits[0].m_Radius > 1)
                iCamera.m_Orbits[0].m_Radius -= 1;

            if (iCamera.m_Orbits[1].m_Radius > 1)
                iCamera.m_Orbits[1].m_Radius -= 1;

            if (iCamera.m_Orbits[2].m_Radius > 1)
                iCamera.m_Orbits[2].m_Radius -= 1;

        }

        if (Input.mouseScrollDelta.y < Vector2.zero.y)
        {
            if (iCamera.m_Orbits[0].m_Radius >= 1)
                iCamera.m_Orbits[0].m_Radius += 1;

            if (iCamera.m_Orbits[1].m_Radius >= 1)
                iCamera.m_Orbits[1].m_Radius += 1;

            if (iCamera.m_Orbits[2].m_Radius >= 1)
                iCamera.m_Orbits[2].m_Radius += 1;

        }
    }
}
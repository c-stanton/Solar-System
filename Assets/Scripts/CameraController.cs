using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    [Header("Dropdown Settings")]
    public Transform[] allTargets;
    private Transform currentTarget;
    private Transform currentAnchor;
    private bool isZoomed = false;
    private bool topView = false;
    private float currentDistance = 10f;

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            topView = !topView;
            isZoomed = false;
        }

        ApplyCameraView();
    }

    public void OnPlanetChanged(int index)
    {
        if (index == 0) 
        {
            currentTarget = null;
            isZoomed = false;
            topView = false;
        }

        else if (index >= 0 && index < allTargets.Length)
        {
            currentTarget = allTargets[index];
            isZoomed = true;
            topView = false;

            if (currentTarget != null)
            {
                Renderer rend = currentTarget.GetComponentInChildren<Renderer>();
                float radius = 1f;
                if (rend != null) 
                {
                    radius = rend.bounds.extents.magnitude;
                }
    
                currentDistance = (radius / Mathf.Sin(Mathf.Deg2Rad * 30f)) * 1.2f;
            }
        }
    }

    void ApplyCameraView()
    {
        if (isZoomed && currentTarget != null)
        {
            Vector3 offsetDir = (Vector3.back + Vector3.up * 0.5f).normalized;
            transform.position = currentTarget.position + (offsetDir * currentDistance);
            transform.LookAt(currentTarget);
        }

        else if (topView)
        {
            transform.position = new Vector3(0f, 400f, 0f);
            transform.rotation = Quaternion.AngleAxis(90f, Vector3.right);
        }

        else
        {
            transform.position = new Vector3(0f, 1f, -290f); 
            transform.rotation = Quaternion.identity;
        }
    }
}
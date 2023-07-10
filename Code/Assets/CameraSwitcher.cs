using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;
    private int currentCameraIndex = 0; // Index of the current active camera

    private void Start()
    {
            camera2.gameObject.SetActive(false);

    }

    private void Update()
    {
        // Check for input to switch cameras
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (currentCameraIndex == 0) {
                camera1.gameObject.SetActive(false);
                camera2.gameObject.SetActive(true);
                currentCameraIndex++;
            } else {
                camera1.gameObject.SetActive(true);
                camera2.gameObject.SetActive(false);
                currentCameraIndex--;
            }
        }
    }
}
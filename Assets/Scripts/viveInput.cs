using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class viveInput : MonoBehaviour
{
    public SteamVR_Input_Sources HandType;
    public SteamVR_Action_Boolean GrabAction;

    void Update ()
    {
        if (GrabAction.GetState(HandType))
        {
            Debug.Log("aaaaaboiboiboboia");

            Debug.Log(GrabAction.ToString());
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            // 現在のシーンを再読込する
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
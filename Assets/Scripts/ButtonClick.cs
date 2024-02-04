using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public string targetSceneName;
    public void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}

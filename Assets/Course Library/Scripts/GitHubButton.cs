using UnityEngine;

public class GitHubButton : MonoBehaviour
{
    // This method must be public for Unity to recognize it
    public void OpenGitHub()
    {
        Application.OpenURL("https://github.com/BlastPowa/FinalProjectForIMM");
    }
}

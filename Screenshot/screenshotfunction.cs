using UnityEngine;
using System.IO;

public class Screenshottaker : MonoBehaviour
{
    public string screenshotFolder = "Screenshots"; // Folder name where screenshots will be saved.
    public int screenshotCount = 0; // Counter for the number of screenshots taken.

    private string ScreenshotPath => Path.Combine(Application.persistentDataPath, screenshotFolder); // Full path for the screenshot folder.

    private void Start()
    {
        // Check if the screenshot folder exists; if not, create it.
        if (!Directory.Exists(ScreenshotPath))
        {
            Directory.CreateDirectory(ScreenshotPath); // Create the screenshot folder.
        }
    }

    public void OnButtonClick()
    {
        // Generate the filename for the screenshot with a count and timestamp.
        string fileName = $"screenshot_{screenshotCount++}_{System.DateTime.Now:yyyyMMdd_HHmmss}.png";
        string filePath = Path.Combine(ScreenshotPath, fileName); // Full file path for the screenshot.

        // Capture the screenshot and save it to the specified path.
        ScreenCapture.CaptureScreenshot(filePath);

        // Log the file path to the Unity console for confirmation or debugging.
        Debug.Log($"Screenshot saved: {filePath}");
    }
}

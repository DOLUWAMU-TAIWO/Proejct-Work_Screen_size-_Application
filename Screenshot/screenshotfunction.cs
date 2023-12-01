using UnityEngine;
using System.IO;

public class Screenshottaker : MonoBehaviour
{
    public string screenshotFolder = "Screenshots";
    public int screenshotCount = 0;

    private string ScreenshotPath => Path.Combine(Application.persistentDataPath, screenshotFolder);

    private void Start()
    {
        // Create the screenshot folder if it doesn't exist
        if (!Directory.Exists(ScreenshotPath))
        {
            Directory.CreateDirectory(ScreenshotPath);
        }
    }

    public void OnButtonClick()
    {
        // Generate screenshot filename
        string fileName = $"screenshot_{screenshotCount++}_{System.DateTime.Now:yyyyMMdd_HHmmss}.png";
        string filePath = Path.Combine(ScreenshotPath, fileName);

        // Take the screenshot
        ScreenCapture.CaptureScreenshot(filePath);

        Debug.Log($"Screenshot saved: {filePath}");
    }
}

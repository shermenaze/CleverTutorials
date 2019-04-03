using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    public int AverageFPS { get; private set; }
    public int HighestFPS { get; private set; }
    public int LowestFPS { get; private set; }
    public int FrameRange;

    int[] fpsBuffer;
    int fpsBufferIndex;

    void Init()
    {
        if (FrameRange <= 0)
            FrameRange = 1;

        fpsBuffer = new int[FrameRange];
        fpsBufferIndex = 0;
    }

    private void Update()
    {
        if(fpsBuffer == null || fpsBuffer.Length != FrameRange)
        {
            Init();
        }

        UpdateBuffer();
        CalculateFps();
    }

    private void CalculateFps()
    {
        int sum = 0;
        int highest = 0;
        int lowest = int.MaxValue;

        for (int i = 0; i < FrameRange; i++)
        {
            int fps = fpsBuffer[i];
            sum += fps;

            if (fps > highest)
                highest = fps;
            if (fps < lowest)
                lowest = fps;
        }

        AverageFPS = sum / FrameRange;
        HighestFPS = highest;
        LowestFPS = lowest;
    }

    private void UpdateBuffer()
    {
        fpsBuffer[fpsBufferIndex++] = (int)(1.0f / Time.unscaledDeltaTime);
        if (fpsBufferIndex >= FrameRange)
            fpsBufferIndex = 0;
    }
}
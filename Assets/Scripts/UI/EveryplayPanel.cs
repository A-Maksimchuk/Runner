using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EveryplayPanel : MonoBehaviour
{
    public Button btStart;
    public Button btPause;
    public Button btStop;
    public Button btEveryPlay;
    public Button btPlayLast;
    public Button btShare;
    public bool showUploadStatus = true;
    private bool isRecording = false;
    private bool isPaused = false;
    private bool isRecordingFinished = false;
    private GUIText uploadStatusLabel;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (uploadStatusLabel != null)
        {
            Everyplay.UploadDidStart += UploadDidStart;
            Everyplay.UploadDidProgress += UploadDidProgress;
            Everyplay.UploadDidComplete += UploadDidComplete;
        }

        Everyplay.RecordingStarted += RecordingStarted;
        Everyplay.RecordingStopped += RecordingStopped;
    }

    void Destroy()
    {
        if (uploadStatusLabel != null)
        {
            Everyplay.UploadDidStart -= UploadDidStart;
            Everyplay.UploadDidProgress -= UploadDidProgress;
            Everyplay.UploadDidComplete -= UploadDidComplete;
        }

        Everyplay.RecordingStarted -= RecordingStarted;
        Everyplay.RecordingStopped -= RecordingStopped;
    }

    private void RecordingStarted()
    {
        isRecording = true;
        isPaused = false;
        isRecordingFinished = false;
    }

    private void RecordingStopped()
    {
        isRecording = false;
        isRecordingFinished = true;
    }

    private void UploadDidStart(int videoId)
    {
        uploadStatusLabel.text = "Upload " + videoId + " started.";
    }

    private void UploadDidProgress(int videoId, float progress)
    {
        uploadStatusLabel.text = "Upload " + videoId + " is " + Mathf.RoundToInt((float)progress * 100) + "% completed.";
    }

    private void UploadDidComplete(int videoId)
    {
        uploadStatusLabel.text = "Upload " + videoId + " completed.";

        StartCoroutine(ResetUploadStatusAfterDelay(2.0f));
    }

    private IEnumerator ResetUploadStatusAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        uploadStatusLabel.text = "Not uploading";
    }

    public void EveryplayShow()
    {
        Everyplay.Show();
    }

    public void EveryplayStart()
    {
        Everyplay.StartRecording();
    }

    public void EveryplayStop()
    {
        Everyplay.StopRecording();
    }

    public void EveryplayShare()
    {
        Everyplay.ShowSharingModal();
    }

    public void EveryplayPlayLast()
    {
        Everyplay.PlayLastRecording();
    }

    public void EveryplayPause()
    {
        Everyplay.PauseRecording();
    }

    void Update()
    {
        if (Everyplay.IsRecordingSupported())
        {
            btPause.gameObject.SetActive(true);
            btStart.gameObject.SetActive(true);
            btStop.gameObject.SetActive(true);
            if (isRecording)
            {
                btStop.interactable = true;
                btStart.interactable = false;
                btPause.interactable = true;
                if (isPaused)
                {
                    btPause.GetComponentInChildren<Text>().text = "Продолжить";
                }
                else
                {
                    btPause.GetComponentInChildren<Text>().text = "Пауза";
                }
            }
            else
            {
                btStop.interactable = false;
                btStart.interactable = true;
                btPause.interactable = false;
            }

            btPlayLast.gameObject.SetActive(isRecordingFinished);
            btShare.gameObject.SetActive(isRecordingFinished);
        }
        else
        {
            btPause.gameObject.SetActive(false);
            btStart.gameObject.SetActive(false);
            btStop.gameObject.SetActive(false);
            btPlayLast.gameObject.SetActive(false);
            btShare.gameObject.SetActive(false);
        }
    }
}
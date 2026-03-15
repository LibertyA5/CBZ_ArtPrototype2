using UnityEngine;
using TMPro;
using System.Collections;

public class ObjectiveUIManager : MonoBehaviour
{
    public static ObjectiveUIManager Instance;

    private string lastHeaderShown = "";
    private string lastObjectiveShown = "";

    [Header("References")]
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI objectiveText;

    [Header("Timing")]
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private float stayDuration = 2.5f;

    private Coroutine currentRoutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        canvasGroup.alpha = 0f;
    }

    public void ShowObjective(string header, string objective)
    {
        // Check if the objective has already been displayed once
        if (header == lastHeaderShown && objective == lastObjectiveShown)
        // Checks out to prevent spamming the message
            return;

        lastHeaderShown = header;
        lastObjectiveShown = objective;

        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
        }

        currentRoutine = StartCoroutine(ShowObjectiveRoutine(header, objective));
    }

    private IEnumerator ShowObjectiveRoutine(string header, string objective)
    {
        headerText.text = header;
        objectiveText.text = objective;

        canvasGroup.alpha = 0f;

        // Fade in
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, time / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;

        // Stay visible
        yield return new WaitForSeconds(stayDuration);

        //Fade out
        time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, time / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
    }
}

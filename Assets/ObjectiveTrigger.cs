using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    [Header("Objective Text")]

    [SerializeField] private string header;
    [SerializeField] private string objective;


    [Header("Trigger Settings")]

    [SerializeField] private bool triggerOnce = true;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggerOnce && hasTriggered)
            return;

        if (other.CompareTag("Player"))
        {
            ObjectiveUIManager.Instance.ShowObjective(header, objective);

            hasTriggered = true;
        }
    }
}

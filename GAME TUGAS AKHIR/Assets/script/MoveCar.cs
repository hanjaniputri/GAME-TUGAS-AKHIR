using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    [SerializeField] private RambuQuestionManager _rambuQuestionManager;
    

    public float moveSpeed = 5f;
    public List<Transform> rambuList;
    public float stopDistance = 5f;

    private bool isMoving = false;
    private bool isStoppingTemporarily = false;
    private Rigidbody2D rb;
    private HashSet<Transform> rambuYangSudahDilewati = new HashSet<Transform>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D tidak ditemukan!");
        }

        if (rambuList.Count == 0)
        {
            Debug.LogWarning("Tidak ada rambu yang ditetapkan!");
        }
    }

    void FixedUpdate()
    {
        
        if (!isMoving || isStoppingTemporarily || rb == null) return;

        Transform nearestRambu = GetNearestRambu();


        if (nearestRambu != null && !rambuYangSudahDilewati.Contains(nearestRambu))
        {
            float distanceToRambu = Vector2.Distance(transform.position, nearestRambu.position);
            Debug.Log("Jarak ke rambu terdekat: " + distanceToRambu);

            if (distanceToRambu <= stopDistance)
            {
                rambuYangSudahDilewati.Add(nearestRambu);  // Tandai sebagai sudah dilewati
                //StartCoroutine(TemporaryStop());
                _rambuQuestionManager.InitializeQuestion();
                StopMoving();
                return;
            }
           
        }

        // Gerak
        Vector2 newPosition = rb.position + Vector2.right * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    Transform GetNearestRambu()
    {
        Transform nearest = null;
        float minDistance = Mathf.Infinity;

        foreach (Transform rambu in rambuList)
        {
            float distance = Vector2.Distance(transform.position, rambu.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = rambu;
            }
        }

        return nearest;
    }

    IEnumerator TemporaryStop()
    {
        isStoppingTemporarily = true;
        StopMoving();
        yield return new WaitForSeconds(7f);  // berhenti 5 detik
        ResumeMoving();
        isStoppingTemporarily = false;
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    public void StopMoving()
    {
        isStoppingTemporarily = true;
        isMoving = false;
    }

    public void ResumeMoving()
    {
        isStoppingTemporarily = false;
    }
}

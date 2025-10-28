using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int lvlToLoad;               // ฉากที่จะโหลด (ใช้ตามของเดิม)
    public Animator animator;           // อ้างอิง Animator ของประตู
    public float delayBeforeLoad = 1.5f; // หน่วงเวลา (รออนิเมชันเปิดประตู)
    private bool isOpening = false;     // กันไม่ให้เปิดซ้ำ

    private void LoadLevel()
    {
        SceneManager.LoadScene(lvlToLoad);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpening)
        {
            isOpening = true;

            // ปิดการชนซ้ำ
            GetComponent<BoxCollider2D>().enabled = false;

            // สั่งให้ประตูเล่นอนิเมชัน "Open"
            if (animator != null)
            {
                animator.SetTrigger("Open");
            }

            // ปิดการควบคุมผู้เล่นระหว่างรอเปลี่ยนฉาก
            other.GetComponent<GatherInput>().DisableControls();

            // รอให้อนิเมชันเล่นจบก่อนเปลี่ยนฉาก
            Invoke(nameof(LoadLevel), delayBeforeLoad);
        }
    }
}

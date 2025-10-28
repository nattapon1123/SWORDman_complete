using UnityEngine;

public class PlayerAttackControls : MonoBehaviour
{
    private PlayerMoveControls playerMoveControls;
    private GatherInput gatherInput;
    private Animator animator;

    public PolygonCollider2D attackCollider;
    public bool attackStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        playerMoveControls = GetComponent<PlayerMoveControls>();
        gatherInput = GetComponent<GatherInput>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack() 
    { 
        //if player presses the attack button
        if(gatherInput.tryAttack)
        {
            animator.SetBool("Attack", true);
            attackStarted = true; 
        }
    }
    /// <summary>
    /// to reset and stop the attack animation
    /// </summary>
    public void ResetAttack()
    {
        // set the attack animation to false
        animator.SetBool("Attack", false);
        gatherInput.tryAttack = false;
        attackStarted = false;
        attackCollider.enabled = false;
    }
    public void ActivateAttack()
    {
        attackCollider.enabled = true;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
{
    if (!attackStarted) return; // ถ้ายังไม่ได้เริ่มโจมตี ให้ข้าม

    if (collision.CompareTag("Enemy")) // ตรวจด้วย Tag จะง่ายกว่า Layer
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(30f); // โจมตีศัตรู 30 หน่วย
            Debug.Log("โจมตีโดนศัตรู!");
        }
    }
}

}
using System;
using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using GlobalEnums;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroController : MonoBehaviour
{
    private static HeroController _instance;
    public static HeroController instance
    {
	get
	{
            HeroController silentInstance = SilentInstance;
	    if (!silentInstance)
	    {
                Debug.LogError("Couldn't find a Hero, make sure one exists in the scene.");
            }
            return silentInstance;
	}
    }
    public static HeroController SilentInstance
    {
	get
	{
            if(_instance == null)
	    {
                _instance = FindObjectOfType<HeroController>();
                if(_instance && Application.isPlaying)
		{
                    DontDestroyOnLoad(_instance.gameObject);
		}
	    }
            return _instance;
	}
    }
    public static HeroController UnsafeInstance
    {
	get
	{
            return _instance;
	}
    }

    private readonly Vector3 flippedScale = new Vector3(-1, 1, 1);

    private Rigidbody2D rb2d;

    [Header("依赖脚本")]
    [SerializeField] private Animator animator = null;
    [SerializeField] private HeroAudioController audioEffectPlayer = null;
    [SerializeField] private HeroAttack attacker = null;
    [SerializeField] private HeroEffect effecter = null;
    public PlayerData data;    
    [SerializeField] AudioSource audioMusicPlayer = null;
    [SerializeField] GameManager gameManager = null;

    [Header("移动参数")]
    [SerializeField] private float maxSpeed = 0.0f;
    [SerializeField] private float dashSpeed = 0.0f;
    [SerializeField] private float jumpForce = 0.0f;
    [SerializeField] private float wallJumpForce = 0.0f;
    [SerializeField] private float wallReactingForce = 0.0f;
    [SerializeField] private float recoilForce = 0.0f;
    [SerializeField] private float downRecoilForce = 0.0f;
    [SerializeField] private float hurtForce = 0.0f;
    [SerializeField] private float maxGravityVelocity = 10.0f;
    [SerializeField] private float jumpGravityScale = 1.0f;
    [SerializeField] private float fallGravityScale = 1.0f;
    [SerializeField] private float slidingGravityScale = 1.0f;
    [SerializeField] private float groundedGravityScale = 1.0f;

    [Header("层级")]
    [SerializeField] public LayerMask whatIsOnGround;

    private Vector2 vectorInput;
    private bool jumpInput;
    private bool enableGravity;
    private int jumpCount;

    [Header("冲刺参数")]
    [SerializeField] private float dashIntervalTime = 1f;
    private float lastDashTime;

    [Header("战斗参数")]
    [Tooltip("连击时间")]
    [SerializeField] private float maxComboDelay = 0.4f;
    [Tooltip("攻击按键间隔时间")]
    [SerializeField] private float slashIntervalTime = 0.2f;

    [Header("攻击数值参数")]
    public int slashDamage;

    private int slashCount;
    private float lastSlashTime;

    private bool isOnGround;
    private bool isFacingLeft;
    private bool isJumping;
    private bool isDashing;
    private bool isSliding;
    private bool isFalling;

    [Header("其他参数")]
    public bool firstLanding;

    private int animatorFristLandingBool;
    private int animatorGroundedBool;
    private int animatorSlidingBool;
    private int animatorMovementSpeed;
    private int animatorVelocitySpeed;
    private int animatorJumpTrigger;
    private int animatorDoubleJumpTrigger;
    private int animatorSlideJumpTrigger;
    private int animatorTurnTrigger;
    private int animatorRespawnTrigger;

    private float counter;

    public bool canMove { get; set; }

    #region Callback Function

    private void OnEnable()
    {
        InputHandler.InputControl.GamePlayer.Movement.performed += ctx => vectorInput = ctx.ReadValue<Vector2>();
        InputHandler.InputControl.GamePlayer.Jump.started += Jump_started;
        InputHandler.InputControl.GamePlayer.Jump.performed += Jump_performed;
        InputHandler.InputControl.GamePlayer.Jump.canceled += Jump_canceled;
        InputHandler.InputControl.GamePlayer.Attack.started += Attack_started;
        InputHandler.InputControl.GamePlayer.Attack.performed += Attack_performed;
        InputHandler.InputControl.GamePlayer.Attack.canceled += Attack_canceled;
        InputHandler.InputControl.GamePlayer.Dash.started += Dash_started;
        InputHandler.InputControl.GamePlayer.Dash.performed += Dash_performed;
        InputHandler.InputControl.GamePlayer.Dash.canceled += Dash_canceled;
    }

    private void OnDisable()
    {
        InputHandler.InputControl.GamePlayer.Jump.started -= Jump_started;
        InputHandler.InputControl.GamePlayer.Jump.performed -= Jump_performed;
        InputHandler.InputControl.GamePlayer.Jump.canceled -= Jump_canceled;
        InputHandler.InputControl.GamePlayer.Attack.started -= Attack_started;
        InputHandler.InputControl.GamePlayer.Attack.performed -= Attack_performed;
        InputHandler.InputControl.GamePlayer.Attack.canceled -= Attack_canceled;
        InputHandler.InputControl.GamePlayer.Dash.started -= Dash_started;
        InputHandler.InputControl.GamePlayer.Dash.performed -= Dash_performed;
        InputHandler.InputControl.GamePlayer.Dash.canceled -= Dash_canceled;
    }

    private void Awake()
    {
	if(_instance == null)
	{
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        data = GetComponent<PlayerData>();

        animatorGroundedBool = Animator.StringToHash("Grounded");
        animatorSlidingBool = Animator.StringToHash("Sliding");
        animatorMovementSpeed = Animator.StringToHash("Movement");
        animatorVelocitySpeed = Animator.StringToHash("Velocity");
        animatorJumpTrigger = Animator.StringToHash("Jump");
        animatorDoubleJumpTrigger = Animator.StringToHash("DoubleJump");
        animatorSlideJumpTrigger = Animator.StringToHash("SlideJump");
        animatorTurnTrigger = Animator.StringToHash("Turn");
        animatorRespawnTrigger = Animator.StringToHash("Respawn");
        animatorFristLandingBool = Animator.StringToHash("FirstLanded");

        canMove = true;
        enableGravity = true;
        animator.SetBool(animatorFristLandingBool, firstLanding);
        if (firstLanding)
        {
            FindObjectOfType<SoulOrb>().DelayShowOrb(0);
        }
    }

    private void Update()
    {
        ResetComboTimer();
    }

    void FixedUpdate()
    {
        UpdateVelocity();
        UpdateDirection();
        UpdateJump();
        UpdateGravityScale();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        UpdateGrounding(collision, false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        UpdateGrounding(collision, false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        UpdateGrounding(collision, true);
    }

    #endregion

    #region Movement

    private void Jump_started(InputAction.CallbackContext context)
    {
        if (data.GetDeadStatement())
            return;
        if (isSliding && !isOnGround)
        {
            StartCoroutine(GrabWallJump());
        }
        else
        {
            if (!gameManager.IsEnableInput())
                return;
            counter = Time.time;
            if (jumpCount <= 1)
            {
                ++jumpCount;
                if (jumpCount == 1)
                {
                    // Set animator
                    animator.SetTrigger(animatorJumpTrigger);
                    // Play audio
                    audioEffectPlayer.Play(HeroAudioController.AudioType.Jump, true);
                }
                else if (jumpCount == 2)
                {
                    animator.SetTrigger(animatorDoubleJumpTrigger);
                    effecter.DoEffect(HeroEffect.EffectType.DoubleJump, true);
                    // Play audio
                    audioEffectPlayer.Play(HeroAudioController.AudioType.HeroWings, true);
                }
                else
                {
                    return;
                }
                // 跳跃键被按下
                jumpInput = true;
            }
        }
    }

    private void Jump_performed(InputAction.CallbackContext context)
    {
        JumpCancel();
    }

    private void Jump_canceled(InputAction.CallbackContext context)
    {
        JumpCancel();
    }

    private void JumpCancel()
    {
        jumpInput = false;
        isJumping = false;
        if (jumpCount == 1)
        {
            animator.ResetTrigger(animatorJumpTrigger);
        }
        else if (jumpCount == 2)
        {
            animator.ResetTrigger(animatorDoubleJumpTrigger);
        }
    }

    private void UpdateGrounding(Collision2D collision, bool exitState)
    {
        if (exitState)
        {
            if ((collision.gameObject.layer == LayerMask.NameToLayer("Terrain") || collision.gameObject.layer == LayerMask.NameToLayer("Soft Terrain")))
            {
                isOnGround = false;
                isSliding = false;
            }
        }
        else
        {
            // 如果下方碰撞到地形，则跳跃已完成，人物已在地面上
            if ((collision.gameObject.layer == LayerMask.NameToLayer("Terrain") || collision.gameObject.layer == LayerMask.NameToLayer("Soft Terrain"))
                && collision.contacts[0].normal == Vector2.up
                && !isOnGround)
            {
                isOnGround = true;
                // Reset jumping flags
                isJumping = false;
                isFalling = false;
                effecter.DoEffect(HeroEffect.EffectType.FallTrail, true);
            }
            // 如果上方碰撞到地形，则取消长按跳跃
            else if ((collision.gameObject.layer == LayerMask.NameToLayer("Terrain")
                || collision.gameObject.layer == LayerMask.NameToLayer("Soft Terrain"))
                && collision.contacts[0].normal == Vector2.down && isJumping)
            {
                JumpCancel();
            }
        }
        animator.SetBool(animatorGroundedBool, isOnGround);
    }

    private void UpdateVelocity()
    {
        if (!data.GetDeadStatement())
        {
            Vector2 velocity = rb2d.velocity;
            if (isSliding && vectorInput.x != 0)
            {
                velocity.y = Mathf.Clamp(velocity.y, -maxGravityVelocity / 2, maxGravityVelocity / 2);
            }
            else
            {
                velocity.y = Mathf.Clamp(velocity.y, -maxGravityVelocity, maxGravityVelocity);
            }
            animator.SetFloat(animatorVelocitySpeed, rb2d.velocity.y);

            if (canMove && gameManager.IsEnableInput())
            {
                rb2d.velocity = new Vector2(vectorInput.x * maxSpeed, velocity.y);
                animator.SetInteger(animatorMovementSpeed, (int)vectorInput.x);
            }
        }
        else
        {
            Vector2 velocity = rb2d.velocity;
            velocity.x = 0;
            velocity.y = Mathf.Clamp(velocity.y, -maxGravityVelocity, maxGravityVelocity);
            rb2d.velocity = velocity;
        }
    }

    private void UpdateJump()
    {
        // Set falling flag
        if (isJumping && rb2d.velocity.y < 0)
            isFalling = true;

        // Jump
        if (jumpInput && gameManager.IsEnableInput())
        {
            // Jump using impulse force
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            // Set jumping flag
            isJumping = true;

            effecter.DoEffect(HeroEffect.EffectType.FallTrail, false);
        }

        if (isOnGround && !isJumping && jumpCount != 0)
        {
            jumpCount = 0;
            counter = Time.time - counter;
        }
    }

    private void UpdateDirection()
    {
        if (canMove && !data.GetDeadStatement())
        {
            // Use scale to flip character depending on direction
            if (rb2d.velocity.x > 1 && isFacingLeft)
            {
                isFacingLeft = false;
                transform.localScale = flippedScale;
            }
            else if (rb2d.velocity.x < -1 && !isFacingLeft)
            {
                isFacingLeft = true;
                transform.localScale = Vector3.one;
            }
        }
    }

    private void UpdateGravityScale()
    {
        // Use grounded gravity scale by default.
        var gravityScale = groundedGravityScale;

        if (!isOnGround)
        {
            if (isSliding && vectorInput.x != 0)
            {
                gravityScale = slidingGravityScale;
            }
            else if (isDashing)
	    {
                gravityScale = 0f;
	    }
            else
            {
                // If not grounded then set the gravity scale according to upwards (jump) or downwards 
                // (falling) motion.
                gravityScale = rb2d.velocity.y > 0.0f ? jumpGravityScale : fallGravityScale;
            }
        }

        if (!enableGravity)
        {
            gravityScale = 0f;
        }

        rb2d.gravityScale = gravityScale;
    }

    IEnumerator GrabWallJump()
    {
        gameManager.SetEnableInput(false);
        enableGravity = false;
        animator.SetTrigger(animatorSlideJumpTrigger);
        rb2d.velocity = new Vector2(transform.lossyScale.x *
            wallReactingForce, wallJumpForce);
        yield return new WaitForSeconds(0.15f);
        enableGravity = true;
        gameManager.SetEnableInput(true);
        animator.ResetTrigger(animatorSlideJumpTrigger);
    }

    public void StopHorizontalMovement()
    {
        Vector2 velocity = rb2d.velocity;
        velocity.x = 0;
        rb2d.velocity = velocity;
        animator.SetInteger(animatorMovementSpeed, 0);
    }

    public void StopInput()
    {
        gameManager.SetEnableInput(false);
        StopHorizontalMovement();
    }

    public void ResumeInput()
    {
        gameManager.SetEnableInput(true);
    }
    #endregion

    #region Dash

    private void Dash_started(InputAction.CallbackContext context)
    {
        if(gameManager.IsEnableInput() && !data.GetDeadStatement())
	{
            if(Time.time >= lastDashTime + dashIntervalTime)
	    {
                lastDashTime = Time.time;
	    }
	}
    }

    private void Dash_performed(InputAction.CallbackContext context)
    {

    }

    private void Dash_canceled(InputAction.CallbackContext context)
    {

    }

    #endregion

    #region Combat

    private void Attack_started(InputAction.CallbackContext context)
    {
        if (gameManager.IsEnableInput() && !data.GetDeadStatement())
            if (Time.time >= lastSlashTime + slashIntervalTime)
            {
                lastSlashTime = Time.time;
                if (vectorInput.y > 0)
                {
                    SlashAndDetect(HeroAttack.AttackType.UpSlash);
                    animator.Play("UpSlash");
                }
                else if (!isOnGround && vectorInput.y < 0)
                {
                    SlashAndDetect(HeroAttack.AttackType.DownSlash);
                    animator.Play("DownSlash");
                }
                else
                {
                    // 如果垂直方向键没有被按下
                    slashCount++;
                    switch (slashCount)
                    {
                        case 1:
                            SlashAndDetect(HeroAttack.AttackType.Slash);
                            animator.Play("Slash");
                            break;
                        case 2:
                            SlashAndDetect(HeroAttack.AttackType.AltSlash);
                            animator.Play("AltSlash");
                            slashCount = 0;
                            break;
                    }
                }
            }
    }

    private void Attack_performed(InputAction.CallbackContext context)
    {

    }

    private void Attack_canceled(InputAction.CallbackContext context)
    {

    }

    private void ResetComboTimer()
    {
        if (Time.time >= lastSlashTime + maxComboDelay && slashCount != 0)
        {
            slashCount = 0;
        }
    }

    /// <summary>
    /// 检测范围并攻击
    /// </summary>
    private void SlashAndDetect(HeroAttack.AttackType attackType)
    {
        List<Collider2D> colliders = new List<Collider2D>();
        attacker.Play(attackType, ref colliders);
        bool hasEnemy = false;
        bool hasDamageAll = false;
        // 检测是否攻击到敌人
        foreach (Collider2D c in colliders)
        {
            if (c.gameObject.layer == LayerMask.NameToLayer("Enemy Detector"))
            {
                hasEnemy = true;
                break;
            }
        }
        // 检测是否攻击到陷阱
        foreach (Collider2D c in colliders)
        {
            if (c.gameObject.layer == LayerMask.NameToLayer("Damage All"))
            {
                hasDamageAll = true;
                break;
            }
        }
        if (hasEnemy)
        {
            if (attackType == HeroAttack.AttackType.DownSlash)
            {
                AddDownRecoilForce();
            }
            else
            {
                StartCoroutine(AddRecoilForce());
            }
        }
        if (hasDamageAll)
        {
            if (attackType == HeroAttack.AttackType.DownSlash)
            {
                audioEffectPlayer.PlayOneShot(HeroAudioController.AudioClipType.SwordHitReject);
                AddDownRecoilForce();
            }
        }
        foreach (Collider2D col in colliders)
        {
            Breakable breakable = col.GetComponent<Breakable>();
            if (breakable != null)
            {
                breakable.Hurt(slashDamage, transform);
            }
        }
    }

    public void AddDownRecoilForce()
    {
        rb2d.velocity.Set(rb2d.velocity.x, 0);
        rb2d.AddForce(Vector2.up * downRecoilForce, ForceMode2D.Force);
    }

    private IEnumerator AddRecoilForce()
    {
        canMove = false;
        if (isFacingLeft)
        {
            rb2d.AddForce(Vector2.right * recoilForce, ForceMode2D.Force);
        }
        else
        {
            rb2d.AddForce(Vector2.left * recoilForce, ForceMode2D.Force);
        }
        yield return new WaitForSeconds(0.2f);
        canMove = true;
    }

    /// <summary>
    /// 受到伤害
    /// </summary>
    /// <param name="enemy"></param>
    /// <returns></returns>
    public IEnumerator TakeDamage(Enemy enemy)
    {
        ProCamera2DShake.Instance.Shake(ProCamera2DShake.Instance.ShakePresets[2]);
        gameManager.SetEnableInput(false);
        audioEffectPlayer.Play(HeroAudioController.AudioType.HeroDamage, true);
        FindObjectOfType<HealthUI>().Hurt();
        if (!data.GetDeadStatement())
        {
            StartCoroutine(FindObjectOfType<Invincibility>().SetInvincibility());
            if (isFacingLeft)
            {
                rb2d.velocity = new Vector2(-1f, 1f) * hurtForce;
            }
            else
            {
                rb2d.velocity = new Vector2(1f, 1f) * hurtForce;
            }
        }
        animator.Play("Damage");
        yield return null;
    }

    public IEnumerator TakeDamage()
    {
        ProCamera2DShake.Instance.Shake(ProCamera2DShake.Instance.ShakePresets[2]);
        gameManager.SetEnableInput(false);
        audioEffectPlayer.Play(HeroAudioController.AudioType.HeroDamage, true);
        FindObjectOfType<HealthUI>().Hurt();
        if (!data.GetDeadStatement())
        {
            StartCoroutine(FindObjectOfType<Invincibility>().SetInvincibility());
            if (isFacingLeft)
            {
                rb2d.velocity = new Vector2(-1f, 1f) * hurtForce;
            }
            else
            {
                rb2d.velocity = new Vector2(1f, 1f) * hurtForce;
            }
        }
        animator.Play("Damage");
        yield return null;
    }

    #endregion

    #region Others

    public void FirstLand()
    {
        StopInput();
        effecter.DoEffect(HeroEffect.EffectType.BurstRocks, true);
    }
    public void HardLand()
    {
        StopInput();
    }
    public void StartShake()
    {
        var shakePreset = ProCamera2DShake.Instance.ShakePresets[0];
        ProCamera2DShake.Instance.Shake(shakePreset);
    }

    public void StopShake()
    {
        ProCamera2DShake.Instance.StopShaking();
    }

    public void PlayHitParticles()
    {
        effecter.DoEffect(HeroEffect.EffectType.HitLeft, true);
        effecter.DoEffect(HeroEffect.EffectType.HitRight, true);
    }

    public void PlayAshParticles()
    {
        effecter.DoEffect(HeroEffect.EffectType.AshLeft, true);
        effecter.DoEffect(HeroEffect.EffectType.AshRight, true);
    }

    public void PlayShadeParticle()
    {
        effecter.DoEffect(HeroEffect.EffectType.Shade, true);
    }

    public void PlayRespawnAnimation()
    {
        animator.SetTrigger(animatorRespawnTrigger);
    }

    public bool GetIsOnGround()
    {
        return isOnGround;
    }

    public void PlayMusicAudioClip(AudioClip audioClip)
    {
        audioMusicPlayer.PlayOneShot(audioClip);
    }

    public void ResetFallDistance()
    {
        animator.GetBehaviour<FallingBehaviour>().ResetAllParams();
    }

    public void SlideWall_ResetJumpCount()
    {
        jumpCount = 1;
    }

    public void SetIsSliding(bool state)
    {
        isSliding = state;
        if (!data.GetDeadStatement())
        {
            animator.SetBool(animatorSlidingBool, isSliding);
        }
    }

    public void SetIsOnGrounded(bool state)
    {
        isOnGround = state;
        if (!data.GetDeadStatement())
        {
            animator.SetBool(animatorGroundedBool, isOnGround);
        }
    }

    public void SetHeroParent(Transform newParent)
    {
        transform.parent = newParent;
        if (newParent == null)
        {
	    DontDestroyOnLoad(gameObject);
        }
    }

    #endregion
}

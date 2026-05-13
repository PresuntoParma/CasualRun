using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    public float speed;

    public Transform target;
    public float lerpSpeed = 1f;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    private bool canRun;

    private Vector3 pos;

    public GameObject endScreen;

    private float currentSpeed;
    private Vector3 startPosition;
    public bool invincible = false;

    public TextMesh uiTextPowerUp;

    [Header("Coin Setup")]
    public GameObject coinCollector;

    [Header("Animation")]
    public AnimationManager animationManager;

    private float baseSpeedToAnimation = 5f;


    private void Start()
    {
        startPosition = transform.position;
        ResetSpeed();
    }

    void Update()
    {
        if (!canRun) return;

        pos = target.position;
        pos.y = transform.position.y;
        pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
        transform.Translate(transform.forward * Time.deltaTime * currentSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagToCheckEnemy))
        {
            if (!invincible)
            {
                MoveBack();
                EndGame(AnimationManager.AnimationType.dead);
                
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }

    public void EndGame(AnimationManager.AnimationType animationType = AnimationManager.AnimationType.idle)
    {
        animationManager.Play(animationType);
        endScreen.SetActive(true);
        canRun = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagToCheckEndLine))
        {
            EndGame();
        }
    }

    public void CanRun()
    {
        canRun = true;
        animationManager.Play(AnimationManager.AnimationType.run, currentSpeed / baseSpeedToAnimation);
    }

    private void MoveBack()
    {
        transform.DOMoveZ(-1, 0.3f).SetRelative();
    }

    #region "Power Ups"

    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        currentSpeed = speed + f;

        animationManager.Play(
        AnimationManager.AnimationType.run,
        currentSpeed / baseSpeedToAnimation
    );
    }
    public void ResetSpeed()
    {
        currentSpeed = speed;

        animationManager.Play(
        AnimationManager.AnimationType.run,
        currentSpeed / baseSpeedToAnimation
    );
    }

    public void SetInvencible(bool b)
    {
        invincible = b;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, DG.Tweening.Ease ease)
    {
        //var p = transform.position;
        //p.y = startPosition.y + amount;
        //transform.position = p;

        transform.DOMoveY(startPosition.y + amount,
        animationDuration).SetEase(ease);//.OnComplete(ResetHeight);a
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight()
    {
        //var p = transform.position;
        //p.y = startPosition.y;
        //transform.position = p;

        transform.DOMoveY(startPosition.y, 0.3f);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }


    #endregion

}

using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _pausePanel;
    
    [SerializeField] private ParticleSystem _playerParticle;
    [SerializeField] private ParticleSystem _breakableParticle;
    [SerializeField] private ParticleSystem _titleParticles;

    private Animator _playerAnimator;
    private Animator _pauseAnimator;

    private string _currentState;
    
    private const string JUMP_ANIM_NAME = "JumpAnim";
    private const string PAUSE_PARAM_NAME = "hasPaused";

    private void Awake()
    {
        _playerAnimator = _player.GetComponent<Animator>();
        _pauseAnimator = _pausePanel.GetComponent<Animator>();
    }

    public void PlayPlayerParticleSystemAt(Vector2 position)
    {
        _playerParticle.transform.position = position;
        _playerParticle.Play();
    }
    
    public void PlayBreakableParticleSystemAt(Vector2 position)
    {
        _breakableParticle.transform.position = position;
        _breakableParticle.Play();
    }

    public void PlayPauseAnimation()
    {
        _pauseAnimator.enabled = true;
        _pauseAnimator.SetBool(PAUSE_PARAM_NAME, true);
    }
    
    public void PlayClosePauseAnimation()
    {
        _pauseAnimator.enabled = true;
        _pauseAnimator.SetBool(PAUSE_PARAM_NAME, false);
    }

    public void PlayPlayerJumpAnimation()
    {
        _playerAnimator.Play(JUMP_ANIM_NAME, -1, 0);
        _playerAnimator.Play(JUMP_ANIM_NAME);
    }

    public void PlayTitleParticles()
    {
        _titleParticles.Play();
    }
}

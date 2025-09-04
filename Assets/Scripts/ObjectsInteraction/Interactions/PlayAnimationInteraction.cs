using UnityEngine;

public class PlayAnimationInteraction : Interaction
{
    [SerializeField]
    private string _trigger;

    [SerializeField]
    private bool _doesPlayOnce;

    private Animator _animator;
    private bool _wasPlayed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (_doesPlayOnce && _wasPlayed)
            return;

        _animator.SetTrigger(_trigger);
        _wasPlayed = true;
    }
}
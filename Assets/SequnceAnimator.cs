using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequnceAnimator : MonoBehaviour
{
    public float Wait = 0.2f;
    public int stevec = 3;
    List<Animator> _animators;
    void Start()
    {
        _animators = new List<Animator>(GetComponentsInChildren<Animator>());

        StartCoroutine(DoAnimation());
    }
    IEnumerator DoAnimation() {
        while (stevec > 0) {
            foreach (var animator in _animators) {
                animator.SetTrigger("DoAnimation");
                yield return new WaitForSeconds(Wait);
            }
            stevec--;
        }
    }

   
}

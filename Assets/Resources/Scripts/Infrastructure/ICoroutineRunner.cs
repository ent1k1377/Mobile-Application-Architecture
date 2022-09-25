using System.Collections;
using UnityEngine;

namespace Resources.Scripts.Infrastructure
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
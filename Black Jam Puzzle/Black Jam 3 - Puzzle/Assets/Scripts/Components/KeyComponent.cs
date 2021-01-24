using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mikabrytu.BJ3.Events;
using Mikabrytu.BJ3.Systems;
using System;

namespace Mikabrytu.BJ3.Components
{
    public class KeyComponent : MonoBehaviour
    {
        [SerializeField] private string[] _allowedTags;

        private PickSystem pickSystem;

        private void Start()
        {
            pickSystem = new PickSystem(transform, GetComponent<Collider2D>(), _allowedTags);

            EventManager.AddListener<OnPickableDropEvent>(OnDrop);
        }

        private void Update()
        {
            pickSystem.Follow();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            pickSystem.Register(collision);
        }

        private void OnDrop(OnPickableDropEvent e)
        {
            pickSystem.Unregister();
        }
    }
}

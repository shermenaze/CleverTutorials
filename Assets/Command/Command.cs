using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Command
    {
        public Command() { }
        public virtual void Execute(Actor actor) { }
    }
}
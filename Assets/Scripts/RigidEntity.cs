using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Unmovable obstacles on the board
/// </summary>
class RigidEntity : BoardEntity {

    public override void OnTarget()
    {
        //Does nothing right now, since this is a rock or some shit it might take crack damage or something
    }

    public override void OnSelect()
    {
        //May display health/attack/sturdiness in the future
    }
}


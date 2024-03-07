using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public static class Extensions
{
    
    public static void SetShapeArc(this ParticleSystem.ShapeModule shape, float angle)
    {
	shape.arc = angle;
    }

    public static void SetRateOverTime(this ParticleSystem.EmissionModule emission, float rateOverTime)
    {
	emission.rateOverTime = rateOverTime;
    }

    public static void SetMaxParticles(this ParticleSystem.MainModule emission, int maxParticles)
    {
	emission.maxParticles = maxParticles;
    }

    public static void SetPositionZ(this Transform t,float newZ)
    {
	t.position = new Vector3(t.position.x, t.position.y, newZ);
    }
}

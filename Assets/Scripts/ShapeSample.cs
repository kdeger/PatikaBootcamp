using UnityEngine;
using System.Collections.Generic;
public class ShapeSample : MonoBehaviour
{
    [ContextMenu("GetTotalVolume")]
    public void GetTotalVolume()
    {
        var cube = new Cube(5);
        var sphere = new Sphere(6);
        var volumeList = new List<IVolume>() { cube, sphere };
        var volumeFloatList = new List<float>() { cube.GetShapeVolume(), sphere.GetShapeVolume() };

        var volumeCalculator = new VolumeCalculatorFromIVolume(volumeList);
        var volumeCalculatorFloat = new VolumeCalculatorFromFloat(volumeFloatList);

        Debug.Log("Total volume: " + volumeCalculator.GetTotalVolume());
        Debug.Log("Total volume from float: " + volumeCalculatorFloat.GetTotalVolume());
    }
}

public interface ICalculateVolume
{
    float GetTotalVolume();
}
public abstract class VolumeCalculator<T, Y> : ICalculateVolume
{
    public List<T> Shapes = new List<T>();
    public Y VolumeCalculatorName;

    public VolumeCalculator(List<T> shapes)
    {
        Shapes = shapes;
    }

    public abstract float GetTotalVolume();
}

public class VolumeCalculatorFromFloat : VolumeCalculator<float, string>
{
    public VolumeCalculatorFromFloat(List<float> shapes) : base(shapes)
    {
        Shapes = shapes;
    }

    public override float GetTotalVolume()
    {
        float totalVolume = 0;
        foreach (var shape in Shapes)
        {
            totalVolume += shape;
        }
        return totalVolume;
    }
}

public class VolumeCalculatorFromIVolume : VolumeCalculator<IVolume, char>
{
    public VolumeCalculatorFromIVolume(List<IVolume> shapes) : base(shapes)
    {
        Shapes = shapes;
    }
    
    public override float GetTotalVolume()
    {
        float totalVolume = 0;
        foreach (var shape in Shapes)
        {
            totalVolume += shape.GetShapeVolume();
        }
        return totalVolume;
    }
}


public interface Shape
{
    float GetShapeArea();
}

public interface IVolume
{
    float GetShapeVolume();
}
public class Circle : Shape
{
    public float Radius { get; set; }
    public float GetShapeArea()
    {
        return Mathf.PI * Mathf.Pow(Radius, 2);
    }
}

public class Rectangle : Shape
{
    public float Width { get; set; }
    public float Height { get; set; }
    public float GetShapeArea()
    {
        return Width * Height;
    }


}

public class Triangle : Shape
{
    public float Base { get; set; }
    public float Height { get; set; }
    public float GetShapeArea()
    {
        return Base * Height / 2;
    }

}

public class Cube : Shape, IVolume
{
    public float Width { get; set; }

    public Cube(float width)
    {
        Width = width;
    }
    public float GetShapeArea()
    {
        return 2 * (3 * Mathf.Pow(Width, 2));
    }
    public float GetShapeVolume()
    {
        return Mathf.Pow(Width, 3);
    }
}

public class Sphere : Shape, IVolume
{
    public float Radius { get; set; }
    public Sphere(float radius)
    {
        Radius = radius;
    }
    public float GetShapeArea()
    {
        return 4 * Mathf.PI * Mathf.Pow(Radius, 2);
    }
    public float GetShapeVolume()
    {
        return 4 / 3 * Mathf.PI * Mathf.Pow(Radius, 3);
    }
}

public class NoShape : Shape
{
    public float GetShapeArea()
    {
        return 0;
    }

    public float GetShapeVolume()
    {
        throw new System.NotImplementedException();
    }
}
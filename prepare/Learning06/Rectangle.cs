public class Rectangle : Shape
{
    private double _lenght;
    private double _width;
    public Rectangle(string color, double lenght, double width) : base (color)
    {
        _lenght = lenght;
        _width = width;
    }
    public override double GetArea()
    {
        double area = _lenght * _width;
        return area;
    }
}
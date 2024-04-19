using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class Program  // В начале надо закоментить второе Задание, потом первое и раскоментить второе и все работает корректно
    {
        public abstract class GeometricFigure
        {
            protected double area;
            protected double perimeter;

            public double AreaFigure
            {
                get { return area; }
            }

            public double PerimeterFigure
            {
                get { return perimeter; }
            }

            public abstract void CalculateArea();

            public abstract void CalculatePerimeter();
        }


        public class Triangle : GeometricFigure
        {
            private double side1;
            private double side2;
            private double side3;

            public double Side1
            {
                get { return side1; }
            }

            public double Side2
            {
                get { return side2; }
            }

            public double Side3
            {
                get { return side3; }
            }

            public Triangle(double side1, double side2, double side3)
            {
                if (!IsValidTriangle(side1, side2, side3))
                    throw new ArgumentException("Некорректные значения сторон треугольника.");

                this.side1 = side1;
                this.side2 = side2;
                this.side3 = side3;

                CalculateArea();
                CalculatePerimeter();
            }

            private bool IsValidTriangle(double side1, double side2, double side3)
            {

                return side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;
            }

            public override void CalculateArea()
            {
                double s = (side1 + side2 + side3) / 2;
                area = Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
            }

            public override void CalculatePerimeter()
            {
                perimeter = side1 + side2 + side3;
            }
        }


        public class Square : GeometricFigure
        {
            private double side;

            public double Side
            {
                get { return side; }
            }

            public Square(double side)
            {
                if (side <= 0)
                    throw new ArgumentException("Некорректное значение стороны квадрата.");

                this.side = side;

                CalculateArea();
                CalculatePerimeter();
            }

            public override void CalculateArea()
            {
                area = side * side;
            }

            public override void CalculatePerimeter()
            {
                perimeter = 4 * side;
            }
        }


        public class Rhombus : GeometricFigure
        {
            private double side;
            private double angle;

            public double Side
            {
                get { return side; }
            }

            public double Angle
            {
                get { return angle; }
            }

            public Rhombus(double side, double angle)
            {
                if (side <= 0)
                    throw new ArgumentException("Некорректное значение стороны ромба.");

                this.side = side;
                this.angle = angle;

                CalculateArea();
                CalculatePerimeter();
            }

            public override void CalculateArea()
            {
                area = side * side * Math.Sin(angle * Math.PI / 180);
            }

            public override void CalculatePerimeter()
            {
                perimeter = 4 * side;
            }
        }


        public class Rectangle : GeometricFigure
        {
            private double length;
            private double width;

            public double Length
            {
                get { return length; }
            }

            public double Width
            {
                get { return width; }
            }

            public Rectangle(double length, double width)
            {
                if (length <= 0 || width <= 0)
                    throw new ArgumentException("Некорректные значения длины и/или ширины прямоугольника.");

                this.length = length;
                this.width = width;

                CalculateArea();
                CalculatePerimeter();
            }
            public override void CalculateArea()
            {
                area = length * width;
            }

            public override void CalculatePerimeter()
            {
                perimeter = 2 * (length + width);
            }
        }


        public class Parallelogram : GeometricFigure
        {
            private double baseLength;
            private double height;
            private double angle;

            public double BaseLength
            {
                get { return baseLength; }
            }

            public double Height
            {
                get { return height; }
            }

            public double Angle
            {
                get { return angle; }
            }

            public Parallelogram(double baseLength, double height, double angle)
            {
                if (baseLength <= 0 || height <= 0)
                    throw new ArgumentException("Некорректные значения длины основания и/или высоты параллелограмма.");

                this.baseLength = baseLength;
                this.height = height;
                this.angle = angle;

                CalculateArea();
                CalculatePerimeter();
            }

            public override void CalculateArea()
            {
                area = baseLength * height * Math.Sin(angle * Math.PI / 180);
            }

            public override void CalculatePerimeter()
            {
                perimeter = 2 * (baseLength + height);
            }
        }


        public class Trapezoid : GeometricFigure
        {
            private double base1;
            private double base2;
            private double height;
            private double side1;
            private double side2;

            public double Base1
            {
                get { return base1; }
            }

            public double Base2
            {
                get { return base2; }
            }

            public double Height
            {
                get { return height; }
            }

            public double Side1
            {
                get { return side1; }
            }

            public double Side2
            {
                get { return side2; }
            }

            public Trapezoid(double base1, double base2, double height, double side1, double side2)
            {
                if (base1 <= 0 || base2 <= 0 || height <= 0 || side1 <= 0 || side2 <= 0)
                    throw new ArgumentException("Некорректные значения сторон и/или высоты трапеции.");

                this.base1 = base1;
                this.base2 = base2;
                this.height = height;
                this.side1 = side1;
                this.side2 = side2;

                CalculateArea();
                CalculatePerimeter();
            }

            public override void CalculateArea()
            {
                area = (base1 + base2) * height / 2;
            }

            public override void CalculatePerimeter()
            {
                perimeter = base1 + base2 + side1 + side2;
            }
        }


        public class Circle : GeometricFigure
        {
            private double radius;

            public double Radius
            {
                get { return radius; }
            }

            public Circle(double radius)
            {
                if (radius <= 0)
                    throw new ArgumentException("Некорректное значение радиуса круга.");

                this.radius = radius;

                CalculateArea();
                CalculatePerimeter();
            }

            public override void CalculateArea()
            {
                area = Math.PI * radius * radius;
            }

            public override void CalculatePerimeter()
            {
                perimeter = 2 * Math.PI * radius;
            }
        }


        public class Ellipse : GeometricFigure
        {
            private double semiMajorAxis;
            private double semiMinorAxis;

            public double SemiMajorAxis
            {
                get { return semiMajorAxis; }
            }

            public double SemiMinorAxis
            {
                get { return semiMinorAxis; }
            }

            public Ellipse(double semiMajorAxis, double semiMinorAxis)
            {
                if (semiMajorAxis <= 0 || semiMinorAxis <= 0)
                    throw new ArgumentException("Некорректные значения полуосей эллипса.");

                this.semiMajorAxis = semiMajorAxis;
                this.semiMinorAxis = semiMinorAxis;

                CalculateArea();
                CalculatePerimeter();
            }

            public override void CalculateArea()
            {
                area = Math.PI * semiMajorAxis * semiMinorAxis;
            }

            public override void CalculatePerimeter()
            {
                perimeter = 2 * Math.PI * Math.Sqrt((semiMajorAxis * semiMajorAxis + semiMinorAxis * semiMinorAxis) / 2);
            }
        }


        public interface SimplePolygon
        {
            double Height { get; set; }
            double BaseLength { get; set; }
            double Angle { get; set; }
            int NumberOfSides { get; }
            double[] SideLengths { get; set; }

            double CalculateArea();
            double CalculatePerimeter();
        }


        public class CompositeFigure
        {
            private SimplePolygon[] polygons;

            public CompositeFigure(SimplePolygon[] polygons)
            {
                this.polygons = polygons;
            }

            public double CalculateTotalArea()
            {
                double totalArea = 0;
                foreach (SimplePolygon polygon in polygons)
                {
                    totalArea += polygon.CalculateArea();
                }
                return totalArea;
            }
        }
        //public interface IDrawable
        //{
        //    void Draw();
        //}


        //public abstract class Shape : IDrawable
        //{
        //    protected int size;
        //    protected ConsoleColor color;
        //    protected int x;
        //    protected int y;

        //    public Shape(int size, ConsoleColor color, int x, int y)
        //    {
        //        this.size = size;
        //        this.color = color;
        //        this.x = x;
        //        this.y = y;
        //    }

        //    public abstract void Draw();
        //}


        //public class Rectangle : Shape
        //{
        //    public Rectangle(int size, ConsoleColor color, int x, int y) : base(size, color, x, y)
        //    {
        //    }

        //    public override void Draw()
        //    {
        //        Console.ForegroundColor = color;

        //        for (int i = 0; i < size; i++)
        //        {
        //            Console.SetCursorPosition(x, y + i);
        //            Console.WriteLine(new string('*', size));
        //        }

        //        Console.ResetColor();
        //    }
        //}

        //public class Rhombus : Shape
        //{
        //    public Rhombus(int size, ConsoleColor color, int x, int y) : base(size, color, x, y)
        //    {
        //    }

        //    public override void Draw()
        //    {
        //        Console.ForegroundColor = color;

        //        for (int i = 0; i <= size / 2; i++)
        //        {
        //            Console.SetCursorPosition(x, y + i);
        //            Console.WriteLine(new string(' ', (size / 2) - i) + new string('*', i * 2 + 1));
        //        }

        //        for (int i = size / 2 - 1; i >= 0; i--)
        //        {
        //            Console.SetCursorPosition(x, y + size - i - 1);
        //            Console.WriteLine(new string(' ', (size / 2) - i) + new string('*', i * 2 + 1));
        //        }

        //        Console.ResetColor();
        //    }
        //}


        //public class Triangle : Shape
        //{
        //    public Triangle(int size, ConsoleColor color, int x, int y) : base(size, color, x, y)
        //    {
        //    }

        //    public override void Draw()
        //    {
        //        Console.ForegroundColor = color;

        //        for (int i = 0; i < size; i++)
        //        {
        //            Console.SetCursorPosition(x, y + i);
        //            Console.WriteLine(new string('*', i + 1));
        //        }

        //        Console.ResetColor();
        //    }
        //}


        //public class Trapezoid : Shape
        //{
        //    public Trapezoid(int size, ConsoleColor color, int x, int y) : base(size, color, x, y)
        //    {
        //    }

        //    public override void Draw()
        //    {
        //        Console.ForegroundColor = color;

        //        for (int i = 0; i < size / 2; i++)
        //        {
        //            Console.SetCursorPosition(x, y + i);
        //            Console.WriteLine(new string(' ', (size / 2) - i) + new string('*', i * 2 + 1));
        //        }

        //        for (int i = size / 2 - 1; i >= 0; i--)
        //        {
        //            Console.SetCursorPosition(x, y + size - i - 1);
        //            Console.WriteLine(new string(' ', (size / 2) - i) + new string('*', i * 2 + 1));
        //        }

        //        Console.ResetColor();
        //    }
        //}


        //public class Polygon : Shape
        //{
        //    private int sides;

        //    public Polygon(int size, ConsoleColor color, int x, int y, int sides) : base(size, color, x, y)
        //    {
        //        this.sides = sides;
        //    }

        //    public override void Draw()
        //    {
        //        Console.ForegroundColor = color;

        //        double angle = (2 * Math.PI) / sides;
        //        double radius = size / 2.0;

        //        for (int i = 0; i < sides; i++)
        //        {
        //            double xPos = x + radius + (Math.Cos(angle * i) * radius);
        //            double yPos = y + radius - (Math.Sin(angle * i) * radius);

        //            Console.SetCursorPosition((int)Math.Round(xPos), (int)Math.Round(yPos));
        //            Console.Write('*');
        //        }

        //        Console.ResetColor();
        //    }
        //}
        //public class ShapeCollection : IEnumerable<IDrawable>
        //{
        //    private List<IDrawable> shapes;

        //    public ShapeCollection()
        //    {
        //        shapes = new List<IDrawable>();
        //    }

        //    public void Add(IDrawable shape)
        //    {
        //        shapes.Add(shape);
        //    }

        //    public void DrawAll()
        //    {
        //        foreach (IDrawable shape in shapes)
        //        {
        //            shape.Draw();
        //        }
        //    }

        //    public IEnumerator<IDrawable> GetEnumerator()
        //    {
        //        return shapes.GetEnumerator();
        //    }

        //    IEnumerator IEnumerable.GetEnumerator()
        //    {
        //        return GetEnumerator();
        //    }
        //}


        static void Main(string[] args)
        {
            CompositeFigure compositeFigure;

            Triangle triangle = new Triangle(3, 4, 5);
            Square square = new Square(5);
            Rhombus rhombus = new Rhombus(6, 30);
            Rectangle rectangle = new Rectangle(4, 6);
            Parallelogram parallelogram = new Parallelogram(5, 7, 45);
            Trapezoid trapezoid = new Trapezoid(4, 6, 5, 4, 6);
            Circle circle = new Circle(5);
            Ellipse ellipse = new Ellipse(5, 3);

            compositeFigure = new CompositeFigure(new SimplePolygon[] { (SimplePolygon)triangle, (SimplePolygon)square, (SimplePolygon)rhombus, (SimplePolygon)rectangle, (SimplePolygon)parallelogram, (SimplePolygon)trapezoid, (SimplePolygon)circle, (SimplePolygon)ellipse });

            Console.WriteLine($"Площадь составной фигуры: {compositeFigure.CalculateTotalArea()}");
        //    ShapeCollection shapeCollection = new ShapeCollection();

        //    Console.WriteLine("Выберите фигуру:");
        //    Console.WriteLine("1. Прямоугольник");
        //    Console.WriteLine("2. Ромб");
        //    Console.WriteLine("3. Треугольник");
        //    Console.WriteLine("4. Трапеция");
        //    Console.WriteLine("5. Многоугольник");

        //    Console.Write("Введите номер фигуры: ");
        //    int choice = int.Parse(Console.ReadLine());

        //    Console.Write("Введите размер фигуры: ");
        //    int size = int.Parse(Console.ReadLine());

        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.Write("Введите цвет фигуры (Black, Red, Green, Yellow, Blue, Magenta, Cyan, White): ");
        //    ConsoleColor color = Enum.Parse<ConsoleColor>(Console.ReadLine(), true);
        //    Console.ResetColor();

        //    Console.Write("Введите положение фигуры по X: ");
        //    int x = int.Parse(Console.ReadLine());

        //    Console.Write("Введите положение фигуры по Y: ");
        //    int y = int.Parse(Console.ReadLine());

        //    switch (choice)
        //    {
        //        case 1:
        //            shapeCollection.Add(new Rectangle(size, color, x, y));
        //            break;
        //        case 2:
        //            shapeCollection.Add(new Rhombus(size, color, x, y));
        //            break;
        //        case 3:
        //            shapeCollection.Add(new Triangle(size, color, x, y));
        //            break;
        //        case 4:
        //            shapeCollection.Add(new Trapezoid(size, color, x, y));
        //            break;
        //        case 5:
        //            Console.Write("Введите количество сторон многоугольника: ");
        //            int sides = int.Parse(Console.ReadLine());
        //            shapeCollection.Add(new Polygon(size, color, x, y, sides));
        //            break;
        //        default:
        //            Console.WriteLine("Некорректный выбор.");
        //            break;
        //    }

        //    Console.Clear();
        //    shapeCollection.DrawAll();

        }
    }
}
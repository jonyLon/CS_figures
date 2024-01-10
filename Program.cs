namespace CS_figures
{

    internal class Program
    {
        abstract class Figure
        {
            protected double a { get; set; }
            public virtual double GetArea() { return a * a; }
            public virtual double GetPerimeter() { return a * 4; }
        }

        class Triangle : Figure
        {
            protected double b { get; set; }
            protected double c { get; set; }
            public Triangle(double a, double b, double c)
            {
                 this.a = a; this.b = b; this.c = c;
            }
            public override double GetArea()
            {
                double hp = GetPerimeter()/2;

                return Math.Sqrt(hp*(hp - a)*(hp - b)*(hp - c));
            }
            public override double GetPerimeter() {
                return a+b+c;
            }
        }
        class Square : Figure
        {
            public Square(double a)
            {
                this.a = a;
            }
        }

        class Romb : Figure
        {
            public Romb(double a)
            {
                this.a = a;
            }
        }

        class Rectangle : Figure
        {
            protected double b { get; set; }
            public Rectangle(double a, double b)
            {
                this.a = a; this.b = b;
            }

            public override double GetArea()
            {
                return a*b;
            }
            public override double GetPerimeter()
            {
                return a * 2 + b * 2;
            }
        }

        class Parallelogram : Figure
        {
            protected double b { get; set; }

            protected int hight { get; set; }
            public Parallelogram(double a, double b, int hight)
            {
                this.a = a; this.b = b;
                this.hight = hight;
            }

            public override double GetArea()
            {
                return b*hight;
            }
            public override double GetPerimeter()
            {
                return a * 2 + b * 2;
            }
        }

        class Trapezium : Figure
        {
            protected double b { get; set; }
            protected double c { get; set; }
            protected double d { get; set; }

            protected int hight { get; set; }
            public Trapezium(double a, double b, double c, double d, int hight)
            {
                this.a = a; this.b = b;
                this.c = c; this.d = d;
                this.hight = hight;
            }

            public override double GetArea()
            {
                return (a+b)*hight/2;
            }
            public override double GetPerimeter()
            {
                return a + b + c + d;
            }
        }

        class Circle : Figure
        {
            public Circle(double r)
            {
                a = r;
            }
            public override double GetArea()
            {
                return base.GetArea() * Math.PI;
            }
            public override double GetPerimeter()
            {
                return 2 * Math.PI * a;
            }
        }

        class Elipse : Figure
        {
            protected double b { get; set; }
            public Elipse(double axsiA, double axisB)
            {
                a = axsiA;
                b = axisB;
            }
            public override double GetArea()
            {
                return Math.PI * a * b;
            }
            public override double GetPerimeter()
            {
                return 2 * Math.PI * Math.Sqrt((a*a+b*b)/2);
            }
        }

        class CompositeFigure : Figure
        {
            protected Figure[] arr { get; set; }
            public CompositeFigure(params Figure[] arr)
            {
                this.arr = arr;
            }
            public override double GetArea()
            {
                double sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i].GetArea();
                }
                return sum;
            }
            public override double GetPerimeter()
            {
                double sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i].GetPerimeter();
                }
                return sum;
            }
        }

        static void Main(string[] args)
        {
            CompositeFigure cf = new CompositeFigure(new Triangle(5,4,6), new Square(8), new Romb(4), new Rectangle(7,5), new Parallelogram(5,6,3), new Trapezium(4,8,6,6,4),new Circle(5),new Elipse(4,6));
            Console.WriteLine(cf.GetPerimeter());
            Console.WriteLine(cf.GetArea());
        }

    }
}
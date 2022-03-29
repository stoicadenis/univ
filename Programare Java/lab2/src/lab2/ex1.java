package lab2;

class Parabola
{
	private double a;
	private double b;
	private double c;
	private double xp;
	private double yp;
	private static double x;
	private static double y;

	public Parabola(double aa, double bb, double cc)
	{
		a = aa;
		b = bb;
		c = cc;
	}

	public Parabola(Parabola p)
	{
		a = p.a;
		b = p.b;
		c = p.c;
	}

	public void afisare()
	{
		System.out.println("f(x) = " + this.a + "x^2 + " + this.b + "x + " + this.c);
	}

	public void calcVarf()
	{
		xp = -b/(2*a);
		yp = (Math.pow(b, 2) + 4*a*c)/(4*a);
	}

	public void calcCoord(Parabola p1, Parabola p2)
	{
		x = (p1.xp + p2.xp)/2;
		y = (p1.yp + p2.yp)/2;
	}

	public static double getX()
	{
		return x;
	}

	public static double getY()
	{
		return y;
	}
}

class MainApp
{
	public static void main(String[] args) 
	{
		Parabola p1 = new Parabola(2,3,4);
		Parabola p2 = new Parabola(3,5,10);
		
		p1.afisare();
		p2.afisare();
		
		p1.calcVarf();
		p2.calcVarf();
		
		p1.calcCoord(p1, p2);
		
		System.out.println("Coordonatele mijlocului sunt: (" + Parabola.getX() + ", " + Parabola.getY() + ")");
	}
}


package lab1;

import java.util.Random;

public class ex4 {

	public static void main(String[] args) {
		Random rand = new Random();
		int a, b;
		
		a = rand.nextInt(30);
		b = rand.nextInt(30);
		System.out.println("a= " + a);
		System.out.println("b= " + b);
		while(a != b)
			if(a > b)
				a = a - b;
			else
				b = b - a;
		System.out.println("CMMDC este " + a);
	}

}

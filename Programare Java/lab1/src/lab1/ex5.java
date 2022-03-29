package lab1;

import java.util.Random;

public class ex5 {

	public static void main(String[] args) {
		Random rand = new Random();
		int nr = rand.nextInt(20);
		int UrmTerm, nr1 = 0, nr2 = 1;
		
		boolean Apartine_Fibonacci = false;
		for(int i = 0; i < 9; i++)
		{
			if(i == 0)
				if(nr1 == nr)
				{
					Apartine_Fibonacci = true;
					break;
				}
			if(i == 1)
				if(nr2 == nr)
				{
					Apartine_Fibonacci = true;
					break;
				}
			UrmTerm = nr1 + nr2;
			nr1 = nr2;
			nr2 = UrmTerm;
			
			if(UrmTerm == nr)
			{
				Apartine_Fibonacci = true;
				break;
			}
		}
		
		if(Apartine_Fibonacci)
			System.out.println("Numarul " + nr + " este numar din sirul lui Fibonacci");
		else
			System.out.println("Numarul " + nr + " nu este numar din sirul lui Fibonacci");
	}

}

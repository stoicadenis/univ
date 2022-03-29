package lab6;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class ex2 {

	public static void main(String[] args) {
		BufferedReader input = new BufferedReader(new InputStreamReader(System.in));
		int x = 0, y;
		boolean gasit = false;
		boolean impartitor = false;
		do
		{
			try {
				if(!impartitor)
					x = Integer.parseInt(input.readLine());
				y = Integer.parseInt(input.readLine());
				gasit = true;
				
				if(y == 0)
				{
					impartitor = true;
					throw new IOException();
				}
				
				System.out.println("Rezultatul impartirii este: " + x/y);
			}
			catch(IOException e)
			{
				System.out.println("Introduceti alt impartitor: ");
				impartitor = true;
				gasit = false;
			}
			catch(NumberFormatException e)
			{
				gasit = false;
				impartitor = false;
				System.out.println("Introduceti numere, nu caractere!");
			}
		}while(!gasit);
	}

}

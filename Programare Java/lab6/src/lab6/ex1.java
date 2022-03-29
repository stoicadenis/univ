package lab6;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;

@SuppressWarnings("serial")
class Exceptie extends Exception
{
	private int nr_x;
	private int nr_y;
	
	public Exceptie(int x, int y)
	{
		nr_x = x;
		nr_y = y;
	}
	
	public String toString()
	{
		return nr_x + " mai mare decat " + nr_y;
	}
}

class Numere
{
	public static void Verificare(int x, int y, BufferedWriter output) throws Exceptie, IOException
	{
		if(x < y)
		{
			output.write(String.valueOf(x) + " " + String.valueOf(y));
		}
		else
		{
			throw new Exceptie(x, y);
		}
	}
}

public class ex1 {

	public static void main(String[] args) throws IOException {
		BufferedReader input = new BufferedReader(new InputStreamReader(System.in));
		BufferedWriter output = new BufferedWriter(new FileWriter("src/lab6/out.txt"));
		int x, y;
		boolean gasit = false;
		do
		{
			try
			{
				x = Integer.parseInt(input.readLine());
				y = Integer.parseInt(input.readLine());
				gasit = true;
				Numere.Verificare(x, y, output);
			}
			catch(Exceptie e)
			{
				System.out.println("Exceptie: " + e);
				gasit = false;
			}
		}while(!gasit);
		output.close();
	}

}

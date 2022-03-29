package lab2;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;

class Produs
{
	private String nume;
	private double cantitate;
	private double pret;
	private static Produs p_max = new Produs("", 0, 0);
	private static Produs p_min = new Produs("", 9999, 0);

	public Produs(String n, double p, double c)
	{
		nume = n;
		cantitate = c;
		pret = p;
	}

	public void afisare()
	{
		System.out.println(nume + " | " + pret + " | " + cantitate);
	}
	
	public double getCantitate()
	{
		return this.cantitate;
	}
	
	public static void findMax(Produs x)
	{
		if(x.pret > p_max.pret)
			p_max = x;
	}

	public static void findMin(Produs x)
	{
		if(x.pret < p_min.pret)
			p_min = x;
	}

	public static void showMax(BufferedWriter out) throws IOException
	{
		out.write("Produsul cu pretul cel mai mare este: " + p_max.nume + ", pret: " + p_max.pret + ", cantitate: " + p_max.cantitate + "\n");
	}

	public static void showMin(BufferedWriter out) throws IOException
	{
		out.write("Produsul cu pretul cel mai mic este: " + p_min.nume + ", pret: " + p_min.pret + ", cantitate: " + p_min.cantitate);
	}
}

// nu merge tot MainApp deoarece este deja la ex1 => error
public class ex2
{
	public static void main(String[] args) throws IOException {
		BufferedReader input = new BufferedReader(new FileReader("src/lab2/input.txt"));
		BufferedWriter output = new BufferedWriter(new FileWriter("src/lab2/destinatie.txt"));

		Produs[] p = new Produs[5];
		int i;
		String citire;
		String[] prelucrare;

		for(i = 0; i < 5; i++)
		{
			citire = input.readLine();
			prelucrare = citire.split(";");
			p[i] = new Produs(prelucrare[0], Double.parseDouble(prelucrare[1]), Double.parseDouble(prelucrare[2]));
			
			Produs.findMax(p[i]);
			Produs.findMin(p[i]);
			
			p[i].afisare();
		}
		input.close();
		
		Produs.showMax(output);
		Produs.showMin(output);
		output.close();
		System.out.println("Minimul si maximul produsului cu pretul cel mai mic, respectiv cel mai mare a fost incarcat in fisier cu SUCCES!");
		
		BufferedReader cit = new BufferedReader(new InputStreamReader(System.in));
		double val;
		
		System.out.print("Cititi o valoare pentru cantitate: ");
		val = Double.parseDouble(cit.readLine());
		System.out.println("Produsele cu o cantitate mai mica decat cea citita de la tastatura sunt: ");
		for(i = 0; i < 5; i++)
		{
			if(p[i].getCantitate() < val)
				p[i].afisare();
		}
	}
}

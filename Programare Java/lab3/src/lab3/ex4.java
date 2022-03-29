package lab3;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;

class Melodie
{
	private String nume_melodie;
	private String nume_artist;
	private int an_lansare;
	private long numar_vizualizari_youtube;
	
	public Melodie(String nm, String na, int an, long nr)
	{
		this.nume_melodie = nm;
		this.nume_artist = na;
		this.an_lansare = an;
		this.numar_vizualizari_youtube = nr;
	}
	
	public void afisare()
	{
		System.out.println(this.nume_melodie + " | " + this.nume_artist + " | " + this.an_lansare + " | " + this.numar_vizualizari_youtube);
	}
	
	public String getNumeMelodie()
	{
		return this.nume_melodie;
	}
	
	public String getNumeArtist()
	{
		return this.nume_artist;
	}
	
	public int getAn()
	{
		return this.an_lansare;
	}
	
	public long getNrViews()
	{
		return this.numar_vizualizari_youtube;
	}
	
	public static void compareNrViews(Melodie a, Melodie b)
	{
		Melodie aux;
		
		if(a.numar_vizualizari_youtube < b.numar_vizualizari_youtube)
		{
			aux = a;
			a = b;
			b = a;
		}
	}
}

public class ex4 {

	public static void main(String[] args) throws NumberFormatException, IOException {
		BufferedReader input = new BufferedReader(new FileReader("src/lab3/melodii.txt"));
		BufferedReader citire = new BufferedReader(new InputStreamReader(System.in));
		Melodie[] m = new Melodie[6];
		Melodie aux;
		int i, j;
		String nume;
		
		for(i = 0; i < 6; i++)
		{
			m[i] = new Melodie(input.readLine(), input.readLine(), Integer.parseInt(input.readLine()), Long.parseLong(input.readLine()));
			m[i].afisare();
		}
		
		System.out.println();
		for(i = 0; i < 6; i++)
			for(j = i+1; j < 6; j++)
			{
				if(m[i].getNrViews() < m[j].getNrViews())
				{
					aux = m[i];
					m[i] = m[j];
					m[j] = aux;
				}
			}
		for(i = 0; i < 6; i++)
			m[i].afisare();
		
		System.out.println("Cititi un nume de artist pe care doriti sa-l cautati: ");
		nume = citire.readLine();
		for(i = 0; i < 6; i++)
		{
			if(m[i].getNumeArtist().equals(nume))
				m[i].afisare();
		}
	}

}

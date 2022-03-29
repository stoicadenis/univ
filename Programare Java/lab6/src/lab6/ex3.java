package lab6;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;

class ExceptieLength extends Exception
{
	public String toString()
	{
		return "CNP-ul introdus nu este valid!";
	}
}

class ExceptiePrimaCifra extends Exception
{
	public String toString()
	{
		return "Prima cifra a CNP-ului nu este valida!";
	}
}

class ExceptieData extends Exception
{
	public String toString()
	{
		return "Datele din CNP nu sunt valide!";
	}
}

class Persoana
{
	private int[] cnpVect = new int[13];
	private String nume;
	private int zi;
	private int luna;
	private int an;
	private int varsta;
	
	public Persoana(int[] cnp, String nume, int zi, int luna, int an)
	{
		this.cnpVect = cnp;
		this.nume = nume;
		this.zi = zi;
		this.luna = luna;
		this.an = an;
		
		String[] buffer = new String[3];
		buffer = String.valueOf(java.time.LocalDate.now()).split("-");
		varsta = Integer.parseInt(buffer[0]) - an;
		if(this.luna >= Integer.parseInt(buffer[1]))
		{
			if(this.zi > Integer.parseInt(buffer[2]))
				varsta--;
		}			
		else
			varsta--;			
	}
	
	public String toString()
	{
		String cnp = new String();
		for(int i = 0; i < this.cnpVect.length; i++)
			cnp = cnp + cnpVect[i];
		return this.nume + " " + cnp + " " + this.zi + "/" + this.luna + "/" + this.an + " " + this.varsta;
	}
}

public class ex3 {

	public static void main(String[] args) throws IOException {
		BufferedReader input = new BufferedReader(new InputStreamReader(System.in));
		String cnp = new String();
		String nume = new String();
		int[] cnpVect = new int[13];
		int ctr = 0;
		int n;
				
		System.out.println("Cate persoane cititi?");
		n = Integer.parseInt(input.readLine());
		Persoana[] p = new Persoana[n];

		do
		{
			try
			{
				//System.out.println(java.time.LocalDate.now());
				cnp = input.readLine();
				nume = input.readLine();
				if(cnp.length() != 13)
					throw new ExceptieLength();
				
				String[] buffer = new String[13];
				buffer = cnp.split("");
				for(int i = 0; i < 13; i++)
				{
					cnpVect[i] = Integer.parseInt(buffer[i]);
				}
				
				if(cnpVect[0] < 1 || cnpVect[0] > 6)
					throw new ExceptiePrimaCifra();
				
				int zi = 0, luna = 0, an = 0;
				zi = Integer.parseInt(Integer.toString(cnpVect[5]) + Integer.toString(cnpVect[6]));
				luna = Integer.parseInt(Integer.toString(cnpVect[3]) + Integer.toString(cnpVect[4]));
				an = Integer.parseInt(Integer.toString(cnpVect[1]) + Integer.toString(cnpVect[2]));
				if(zi < 1 || zi > 31 || luna < 1 || luna > 12)
					throw new ExceptieData();
				
				if(cnpVect[0] == 1 || cnpVect[0] == 2)
					if(an >= 0 && an <= 9)
						an = Integer.parseInt("190" + Integer.toString(an));
					else
						an = Integer.parseInt("19" + Integer.toString(an));
				else if(cnpVect[0] == 5 || cnpVect[0] == 6)
					if(an >= 0 && an <= 9)
						an = Integer.parseInt("200" + Integer.toString(an));
					else
						an = Integer.parseInt("20" + Integer.toString(an));
				
				p[ctr] = new Persoana(cnpVect, nume, zi, luna, an);
				ctr++;
			}
			catch(ExceptieLength e)
			{
				System.out.println("ExceptieLength: " + e);
			}
			catch(NumberFormatException e)
			{
				System.out.println("Exceptie: Nu ati introdus doar numere in CNP");
			}
			catch(ExceptiePrimaCifra e)
			{
				System.out.println("ExceptiePrimaCifra: " + e);
			}
			catch(ExceptieData e)
			{
				System.out.println("ExceptieData: " + e);
			}
		}while(ctr < n);
		
		for(int i = 0; i < p.length; i++)
		{
			System.out.println(p[i]);
		}
	}

}

package lab3;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Random;

class Vers
{
	private String vers;
	
	public Vers(String v)
	{
		this.vers = v;
	}
	
	public String getString()
	{
		return this.vers;
	}
	
	public int getNumberOfWords()
	{
		String[] prelucrare = new String[this.vers.length()];
		
		prelucrare = this.vers.split(" ");
		
		return prelucrare.length;
	}
	
	public int getNumberOfVowels()
	{
		int count = 0;
		for(int i = 0;i < this.vers.length(); i++)
		{
			if(vers.charAt(i) == 'a' || vers.charAt(i) == 'A' || vers.charAt(i) == 'e' || vers.charAt(i) == 'E' || vers.charAt(i) == 'i' || vers.charAt(i) == 'I' ||
					vers.charAt(i) == 'o' || vers.charAt(i) == 'O' || vers.charAt(i) == 'u' || vers.charAt(i) == 'U')
			{
				count++;
			}
		}
		
		return count;
	}
	
	public boolean verifyLastLetters(String lettersGroup)
	{
		return vers.substring(this.vers.length() - lettersGroup.length(), this.vers.length()).equals(lettersGroup);
	}
	
	public void setStringUpperRandom()
	{
		Random rand = new Random();
		
		if(rand.nextDouble() < 0.1)
			this.vers.toUpperCase();
	}
}

public class ex1 {
	@SuppressWarnings("resource")
	public static void main(String[] args) throws IOException {
		BufferedReader tasta = new BufferedReader(new InputStreamReader(System.in));
		BufferedReader input = new BufferedReader(new FileReader("src/lab3/cantec_in.txt"));
		BufferedWriter output = new BufferedWriter(new FileWriter("src/lab3/cantec_out.txt"));
		
		Vers[] v = new Vers[8];
		String lettersGroup;
		
		System.out.println("Dati gruparea de litere: ");
		lettersGroup = tasta.readLine();
		
		for(int i = 0; i < 8; i++)
		{
			v[i] = new Vers(input.readLine());
			if(v[i].verifyLastLetters(lettersGroup))
				output.write("*");
			output.write(v[i].getNumberOfWords() + " ");
			output.write(v[i].getNumberOfVowels() + " ");
			v[i].setStringUpperRandom();
			output.write(v[i].getString());
			output.newLine();
		}
		
		output.close();
	}

}

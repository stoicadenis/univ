package lab3;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;

public class ex3 {

	public static void main(String[] args) throws IOException {
		BufferedReader input = new BufferedReader(new FileReader("src/lab3/judete_in.txt"));
		BufferedReader citire = new BufferedReader(new InputStreamReader(System.in));
		String[] judet = new String[41];
		String str;
		int i;
		for(i = 0; i < 41; i++)
			judet[i] = input.readLine();
			
		Arrays.sort(judet);
		System.out.println("Judetele sortate sunt: ");
		for(i = 0; i < 41; i++)
		{
			System.out.println(judet[i]);
		}
		
		System.out.print("Cititi un nume de judet ce doriti sa il cautati: ");
		str = citire.readLine();
		System.out.println("Judetul se afla la pozitia: " + Arrays.binarySearch(judet, str));
	}
}

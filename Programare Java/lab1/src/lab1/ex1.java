package lab1;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class ex1 {

	public static void main(String[] args) throws IOException {
		BufferedReader input = new BufferedReader(new InputStreamReader(System.in));
		int Lungime, latime, perimetru, arie;
		
		Lungime = Integer.parseInt(input.readLine());
		latime = Integer.parseInt(input.readLine());
		
		perimetru = 2*(Lungime + latime);
		arie = Lungime * latime;
		
		System.out.println("Perimetrul este " + perimetru);
		System.out.println("Aria este " + arie);
	}

}

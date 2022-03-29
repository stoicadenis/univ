package lab1;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class ex3 {

	public static void main(String[] args) throws NumberFormatException, IOException {
		BufferedReader input = new BufferedReader(new InputStreamReader(System.in));
		int n = Integer.parseInt(input.readLine());
		int i, d = 2;
		for(i = 1; i <= n; i++)
			if(n % i == 0)
				System.out.println(i);
		
		boolean prim = true;
		
		while(d < n && prim)
		{
			if(n % d == 0)
				prim = false;
			d++;
		}
		if(prim)
			System.out.println("Numarul " + n + " este prim!");
		else
			System.out.println("Numarul " + n + " nu este prim!");
	}

}

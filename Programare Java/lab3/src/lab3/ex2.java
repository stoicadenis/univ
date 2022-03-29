package lab3;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class ex2 {

	public static void main(String[] args) throws IOException {
		BufferedReader input = new BufferedReader(new InputStreamReader(System.in));
		
		String str1;
		String str2;
		String newStr;
		
		int poz, poz2;
		
		System.out.print("Cititi string-ul principal: ");
		str1 = input.readLine();
		System.out.print("Cititi stringul ce doriti sa-l inserati: ");
		str2 = input.readLine();
		System.out.print("Cititi pozitia unde doriti sa se insereze stringul: ");
		poz = Integer.parseInt(input.readLine());
		
		newStr = str1.substring(0, poz);
		newStr = newStr.concat(str2);
		newStr = newStr.concat(str1.substring(poz, str1.length()));
		
		System.out.println("Sirul dupa inserare este: " + newStr);
		
		System.out.print("Cititi pozitia de unde doriti sa stergeti: ");
		poz = Integer.parseInt(input.readLine());
		System.out.print("Cititi cate litere doriti sa stergeti din sir: ");
		poz2 = Integer.parseInt(input.readLine());
		
		if(poz > newStr.length()-1)
			System.out.println("Pozitia citita este mai mare decat size-ul stringului!");
		else
		{
			newStr = newStr.replace(newStr.substring(poz, poz2+1), "");
			System.out.println("Stringul dupa stergere este: " + newStr);
		}
	}



}

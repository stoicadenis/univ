package lab5;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

class Carte{
	private String titlu;
	private String autor;
	private int an_aparitie;
	
	public Carte(String titlu,String autor,int an_aparitie)
	{
		this.titlu=titlu;
		this.autor=autor;
		this.an_aparitie=an_aparitie;
	}

	public String getTitlu() {
		return titlu;
	}

	public void setTitlu(String titlu) {
		this.titlu = titlu;
	}

	public String getAutor() {
		return autor;
	}

	public void setAutor(String autor) {
		this.autor = autor;
	}

	public int getAn_aparitie() {
		return an_aparitie;
	}

	public void setAn_aparitie(int an_aparitie) {
		this.an_aparitie = an_aparitie;
	}
	
	public String toString()
	{
		return titlu+","+autor+","+an_aparitie;
	}
}

class ComparaTitlu implements Comparator<Carte>{

	@Override
	public int compare(Carte o1, Carte o2) {
		// TODO Auto-generated method stub
		return o1.getTitlu().compareTo(o2.getTitlu());
	}
	
}

public class ex2 {

	@SuppressWarnings({ "rawtypes", "resource" })
	public static void main(String[] args) throws IOException {
		// TODO Auto-generated method stub
		BufferedReader flux_intrare=new BufferedReader(new FileReader("src/lab5/input.txt"));
		Map<Integer,Carte> carti=new HashMap<Integer,Carte>();
		
		String linie;
		String[] s;
		
		int id;
		String titlu;
		String autor;
		int an;
		
		linie=flux_intrare.readLine();
		while(linie!=null)
		{
			s=linie.split("; ");
			id=Integer.parseInt(s[0]);
			titlu=s[1];
			autor=s[2];
			an=Integer.parseInt(s[3]);
			
			carti.put(id,new Carte(titlu,autor,an));
			
			linie=flux_intrare.readLine();
		}
		System.out.println("Colectia este:");
		Set setul=carti.entrySet();
		
		Iterator it=setul.iterator();
		
		while(it.hasNext())
		{
			Entry pereche=(Entry)it.next();
			
			int cheie=(int)pereche.getKey();
			Carte valoare=(Carte)pereche.getValue();
			
			System.out.println("Cheia: "+cheie+" Valoarea: "+valoare.toString());			
		}
		
		List<Carte> valori=new ArrayList<Carte>();
		valori.addAll(carti.values());
		
		System.out.println("\nValorile sunt:");
		for(Carte val:valori)
		{
			System.out.println(val);
		}
		
		System.out.println("\nValorile ordonate dupa titlu sunt:");
		Collections.sort(valori,new ComparaTitlu());
		for(Carte val:valori)
		{
			System.out.println(val);
		}
	}

}

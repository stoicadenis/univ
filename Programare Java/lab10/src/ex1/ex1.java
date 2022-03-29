package ex1;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.time.LocalDate;
import java.time.Month;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

class Angajat{
	private String nume;
	private String post;
	private LocalDate data_angajare;
	private float salariu;
	
	public Angajat(String nume,String post,LocalDate data_angajare,float salariu)
	{
		this.nume=nume;
		this.post=post;
		this.data_angajare=data_angajare;
		this.salariu=salariu;
	}

	public String getNume() {
		return nume;
	}

	public void setNume(String nume) {
		this.nume = nume;
	}

	public String getPost() {
		return post;
	}

	public void setPost(String post) {
		this.post = post;
	}

	public LocalDate getData_angajare() {
		return data_angajare;
	}

	public void setData_angajare(LocalDate data_angajare) {
		this.data_angajare = data_angajare;
	}

	public float getSalariu() {
		return salariu;
	}

	public void setSalariu(float salariu) {
		this.salariu = salariu;
	}

	@Override
	public String toString() {
		return nume+", "+post+", "+data_angajare+", "+salariu;
	}
}

public class ex1 {

	public static void main(String[] args) throws IOException {
		// TODO Auto-generated method stub
		
		BufferedReader flux_intrare=new BufferedReader(new FileReader("in.txt"));
		List<Angajat> angajati=new ArrayList<Angajat>();
		
		String linie;
		linie=flux_intrare.readLine();
		
		while(linie!=null)
		{
			String[] s;
			
			s=linie.split(";");
			String nume=s[0];
			String post=s[1];
			LocalDate data_angajare=LocalDate.parse(s[2]);
			float salariu=Float.parseFloat(s[3]);
			
			angajati.add(new Angajat(nume,post,data_angajare,salariu));
			
			linie=flux_intrare.readLine();
		}
		
		angajati.forEach(System.out::println);
		
		System.out.println("\nAngajatii cu salariu peste 2500 RON:");
		angajati
		.stream()
		.filter((Angajat a) -> a.getSalariu()>2500)
		.forEach(System.out::println);
		
		System.out.println("\nAngajatii din aprilie, anul curent, cu functie de conducere:");
		List<Angajat> lista = angajati
		.stream()
		.filter((Angajat a) -> a.getData_angajare().getMonth()==Month.APRIL)
		.filter((Angajat a) -> a.getData_angajare().getYear()==LocalDate.now().getYear())
		.filter((Angajat a) -> a.getPost().contains("sef") || a.getPost().contains("director"))
		.collect(Collectors.toList());
		
		lista.forEach(System.out::println);
		
		System.out.println("\nAngajatii fara functie de conducere, in ordine descrescatoare a salariilor:");
		angajati
		.stream()
		.filter((Angajat a) -> !a.getPost().contains("sef") && !a.getPost().contains("director"))
		.sorted((Angajat a,Angajat b) -> {
			if(b.getSalariu()>a.getSalariu()) return 1;
			else
			{
				if(b.getSalariu()<a.getSalariu())
				{
					return -1;
				}
				else
				{
					return 0;
				}
			}
		})
		.forEach(System.out::println);
		
		System.out.println("\nNumele angajatilor, scrise cu majuscule:");
		List<String> listaNume = angajati
		.stream()
		.map(Angajat::getNume)
		.map(String::toUpperCase)
		.collect(Collectors.toList());
		
		listaNume.forEach(System.out::println);
		
		System.out.println("\nSalariile mai mici de 3000 de RON:");
		angajati
		.stream()
		.map(Angajat::getSalariu)
		.filter((s) -> s<3000)
		.forEach(System.out::println);
	}

}

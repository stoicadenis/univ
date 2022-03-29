package lab4;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;

enum tip{achizitionat, expus, vandut};

class Echipament implements Serializable
{
	private String denumire;
	private int nr_inv;
	private int pret;
	private String zona_mag;
	private tip t;
	
	public Echipament(String d, int nr, int p, String z, String stare)
	{
		denumire = d;
		nr_inv = nr;
		pret = p;
		zona_mag = z;
		t = tip.valueOf(stare);
	}
	
	public String toString()
	{
		return this.denumire + " | " + this.nr_inv + " | " + this.pret + " | " + this.zona_mag + " | " + this.t.name();
	}
	
	public String getDenumire() {
		return denumire;
	}
	public void setDenumire(String denumire) {
		this.denumire = denumire;
	}
	public int getNr_inv() {
		return nr_inv;
	}
	public void setNr_inv(int nr_inv) {
		this.nr_inv = nr_inv;
	}
	public double getPret() {
		return pret;
	}
	public void setPret(int pret) {
		this.pret = pret;
	}
	public String getZona_mag() {
		return zona_mag;
	}
	public void setZona_mag(String zona_mag) {
		this.zona_mag = zona_mag;
	}
	public tip getT() {
		return t;
	}
	public void setT(tip t) {
		this.t = t;
	}	
}

class Imprimanta extends Echipament
{
	private int ppm;
	private String p_car;
	private int rezolutie;
	private String mod_scriere;
	
	public Imprimanta(String d, int nr, int p, String z, String stare, int pp, String p_car, int rezolutie, String mod) {
		super(d, nr, p, z, stare);
		this.ppm = pp;
		this.p_car = p_car;
		this.rezolutie = rezolutie;
		this.mod_scriere = mod;
	}
	
	public String toString()
	{
		return super.toString() + " | " + this.ppm + " | " + this.p_car + " | " + this.rezolutie + " | " + this.mod_scriere;
	}

	public int getPpm() {
		return ppm;
	}

	public void setPpm(int ppm) {
		this.ppm = ppm;
	}

	public String getMod_scriere() {
		return mod_scriere;
	}

	public void tiparireColor() {
		this.mod_scriere = "Color";
	}
	
	public void tiparireAlbNegru() {
		this.mod_scriere = "Alb Negru";
	}	
}

class Copiator extends Echipament
{
	private int ppm;
	private int p_ton;
	public String format_copiere;
	
	public Copiator(String d, int nr, int p, String z, String stare, int pp, int p_ton, String format) {
		super(d, nr, p, z, stare);
		this.ppm = pp;
		this.p_ton = p_ton;
		this.format_copiere = format;
	}

	public String toString()
	{
		return super.toString() + " | " + this.ppm + " | " + this.p_ton + " | " + this.format_copiere;
	}
	
	public int getPpm() {
		return ppm;
	}

	public void setPpm(int ppm) {
		this.ppm = ppm;
	}

	public String getFormat_copiere() {
		return format_copiere;
	}

	public void setFormatA4() {
		this.format_copiere = "A4";
	}
	
	public void setFormatA3() {
		this.format_copiere = "A3";
	}
}

class Sistem_de_calcul extends Echipament
{
	private String tip_mon;
	private double vit_proc;
	private int c_hdd;
	private String sistem_de_operare;
	
	public Sistem_de_calcul(String d, int nr, int p, String z, String stare, String tip_mon, double vit_proc, int c_hdd, String sistem_de_operare) {
		super(d, nr, p, z, stare);
		this.tip_mon = tip_mon;
		this.vit_proc = vit_proc;
		this.c_hdd = c_hdd;
		this.sistem_de_operare = sistem_de_operare;
	}
	
	public String toString()
	{
		return super.toString() + " | " + this.tip_mon + " | " + this.vit_proc + " | " + this.c_hdd + " | " + this.sistem_de_operare;
	}

	public String getTip_mon() {
		return tip_mon;
	}

	public void setTip_mon(String tip_mon) {
		this.tip_mon = tip_mon;
	}

	public double getVit_proc() {
		return vit_proc;
	}

	public void setVit_proc(double vit_proc) {
		this.vit_proc = vit_proc;
	}

	public int getC_hdd() {
		return c_hdd;
	}

	public void setC_hdd(int c_hdd) {
		this.c_hdd = c_hdd;
	}

	public String getSistem_de_operare() {
		return sistem_de_operare;
	}

	public void instalWin() {
		this.sistem_de_operare = "Windows";
	}
	
	public void instalLinux() {
		this.sistem_de_operare = "Linux";
	}
	
}

public class ex1 {
	
	static void serializare(Object o) throws IOException
	{
		FileOutputStream f = new FileOutputStream("src/lab4/echip.bin");
		ObjectOutputStream os = new ObjectOutputStream(f);
		os.writeObject(o);
		os.close();
		f.close();
	}
	
	static Object deserializare() throws IOException, ClassNotFoundException
	{
		FileInputStream f = new FileInputStream("src/lab4/echip.bin");
		ObjectInputStream ois = new ObjectInputStream(f);
		Object o = ois.readObject();
		ois.close();
		f.close();
		return o;
	}
	
	public static void main(String[] args) throws IOException, InterruptedException, ClassNotFoundException {
		BufferedReader input = new BufferedReader(new FileReader("src/lab4/echipamente.txt"));
		BufferedReader cit = new BufferedReader(new InputStreamReader(System.in));
		String[] prelucrare = new String[10];
		Echipament[] e = new Echipament[6];
		
		for(int i = 0; i < 6; i++)
		{
			prelucrare = input.readLine().split(";");
			if(prelucrare[5].equals("imprimanta"))
			{
				e[i] = new Imprimanta(prelucrare[0], Integer.parseInt(prelucrare[1]), Integer.parseInt(prelucrare[2]), prelucrare[3], prelucrare[4], Integer.parseInt(prelucrare[6]), prelucrare[7], Integer.parseInt(prelucrare[8]), prelucrare[9]);
			}
			else if(prelucrare[5].equals("copiator"))
			{
				e[i] = new Copiator(prelucrare[0], Integer.parseInt(prelucrare[1]), Integer.parseInt(prelucrare[2]), prelucrare[3], prelucrare[4], Integer.parseInt(prelucrare[6]), Integer.parseInt(prelucrare[7]), prelucrare[8]);
			}
			else if(prelucrare[5].equals("sistem de calcul"))
			{
				e[i] = new Sistem_de_calcul(prelucrare[0], Integer.parseInt(prelucrare[1]), Integer.parseInt(prelucrare[2]), prelucrare[3], prelucrare[4], prelucrare[6], Double.parseDouble(prelucrare[7]), Integer.parseInt(prelucrare[8]), prelucrare[9]);
			}
		}
		input.close();
		System.out.println("Datele au fost incarcate cu SUCCES din fisier!");
		
		int opt;
		boolean ok = true;
		do
		{
			System.out.println("0. Iesire");
			System.out.println("1. Afisarea imprimantelor");
			System.out.println("2. Afisarea copiatoarelor");
			System.out.println("3. Afisarea sistemelor de calcul");
			System.out.println("4. Modificarea starii in care se afla un echipament");
			System.out.println("5. Setarea unui anumit mod de scriere pentru o imprimanta");
			System.out.println("6. Setarea unui format de copiere pentru copiatoare");
			System.out.println("7. Instalarea unui anumit sistem de operare pe un sistem de calcul");
			System.out.println("8. Afisarea echipamentelor vandute");
			System.out.println("9. Serializarea colectiei de obiecte");
			System.out.println("10. Deserializarea colectiei de obiecte + afisare");
			System.out.print("Cititi optiunea dorita: ");
			opt = Integer.parseInt(cit.readLine());
			
			switch(opt)
			{
				case 0:
				{
					System.out.println("Ati parasit meniul! :(");
					ok = false;
					break;
				}
				case 1:
				{
					for(int i = 0; i < 6; i++)
						if(e[i] instanceof Imprimanta)
							System.out.println((Imprimanta)e[i]);
					Thread.sleep(3000);
					break;
				}
				case 2:
				{
					for(int i = 0; i < 6; i++)
						if(e[i] instanceof Copiator)
							System.out.println((Copiator)e[i]);
					Thread.sleep(3000);
					break;
				}
				case 3:
				{
					for(int i = 0; i < 6; i++)
						if(e[i] instanceof Sistem_de_calcul)
							System.out.println((Sistem_de_calcul)e[i]);
					Thread.sleep(3000);
					break;
				}
				case 4:
				{
					String nume;
					System.out.println("Cititi denumirea marcii careia doriti sa ii actualizati stare: ");
					nume = cit.readLine();
					for(int i = 0; i < 6; i++)
						if(e[i].getDenumire().contains(nume))
						{
							tip t = null;
							int alegere;
							System.out.print("Cititi modificarea starii (0 - achizitionat, 1 - expus, 2 - vandut): ");
							alegere = Integer.parseInt(cit.readLine());
							if(alegere == 0)
								e[i].setT(t.achizitionat);
							else if(alegere == 1)
								e[i].setT(t.expus);
							else if(alegere == 2)
								e[i].setT(t.vandut);
							System.out.println("Modificarea s-a produs cu succes!");
							break;
						}
					break;
				}
				case 5:
				{
					String nume;
					System.out.println("Cititi denumirea marcii imprimantei careia doriti sa ii actualizati stare: ");
					nume = cit.readLine();
					for(int i = 0; i < 6; i++)
						if(e[i].getDenumire().contains(nume) && e[i] instanceof Imprimanta)
						{
							int mod;
							System.out.print("Cititi modul in care doriti sa tipariti (0 - Alb Negru, 1 - Color):");
							mod = Integer.parseInt(cit.readLine());
							if(mod == 0)
								((Imprimanta) e[i]).tiparireAlbNegru();
							else if(mod == 1)
								((Imprimanta) e[i]).tiparireColor();
							break;
						}
					break;
				}
				case 6:
				{
					String nume;
					System.out.println("Cititi denumirea marcii copiatorului careia doriti sa ii actualizati stare: ");
					nume = cit.readLine();
					for(int i = 0; i < 6; i++)
						if(e[i].getDenumire().contains(nume) && e[i] instanceof Copiator)
						{
							int format;
							System.out.print("Cititi formatul in care doriti sa copiati (0 - A3, 1 - A4): ");
							format = Integer.parseInt(cit.readLine());
							if(format == 0)
								((Copiator)e[i]).setFormatA3();
							else if(format == 1)
								((Copiator)e[i]).setFormatA4();
							break;
						}
					break;
				}
				case 7:
				{
					String nume;
					System.out.println("Cititi denumirea marcii copiatorului careia doriti sa ii actualizati stare: ");
					nume = cit.readLine();
					for(int i = 0; i < 6; i++)
						if(e[i].getDenumire().contains(nume) && e[i] instanceof Sistem_de_calcul)
						{
							int sistem;
							System.out.print("Cititi sistemul de operare ce doriti sa-l instalati (0 - Windows, 1 - Linux): ");
							sistem = Integer.parseInt(cit.readLine());
							if(sistem == 0)
								((Sistem_de_calcul)e[i]).instalWin();
							else if(sistem == 1)
								((Sistem_de_calcul)e[i]).instalLinux();
							break;
						}
					break;
				}
				case 8:
				{
					for(int i = 0; i < 6; i++)
					{
						if(e[i].getT() == tip.vandut)
							if(e[i] instanceof Imprimanta)
								System.out.println((Imprimanta)e[i]);
							else if(e[i] instanceof Copiator)
								System.out.println((Copiator)e[i]);
							else if(e[i] instanceof Sistem_de_calcul)
								System.out.println((Sistem_de_calcul)e[i]);
					}
					break;
				}
				case 9:
				{
					serializare(e);
					System.out.println("Serializare finalizata cu succes!");
					break;
				}
				case 10:
				{
					Echipament[] e2;
					e2 = (Echipament[])deserializare();
					for(Echipament x:e2)
						System.out.println(x);
					break;
				}
			}
		}while(ok);
	}

}

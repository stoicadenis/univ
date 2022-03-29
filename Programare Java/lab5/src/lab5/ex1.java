package lab5;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Set;
import java.util.Vector;

interface Operatiuni{
	public float calculeaza_dobanda();
	public float actualizare_suma();
	public void depunere(float suma);
	public void extragere(float suma);
}

class ContBancar implements Operatiuni{
	private String numarCont;
	private float suma;
	private String moneda;
	private Calendar data_deschiderii;
	private Calendar data_ultimei_operatiuni;

	public ContBancar(String nr,float sum,String mon,Calendar desc,Calendar ult)
	{
		numarCont=nr;
		suma=sum;
		moneda=mon;
		data_deschiderii=desc;
		data_ultimei_operatiuni=ult;
	}

	public String getNumarCont()
	{
		return numarCont;
	}

	public float getSuma()
	{
		return suma;
	}

	public String getMoneda()
	{
		return moneda;
	}

	public Calendar getData_deschiderii()
	{
		return data_deschiderii;
	}

	public Calendar getData_ultimei_operatiuni()
	{
		return data_ultimei_operatiuni;
	}

	public int comparaDataDeschiderii(Calendar o)
	{
		if(this.data_deschiderii.get(Calendar.DAY_OF_MONTH)==o.get(Calendar.DAY_OF_MONTH) && this.data_deschiderii.get(Calendar.MONTH)==o.get(Calendar.MONTH)
				&& this.data_deschiderii.get(Calendar.YEAR)==o.get(Calendar.YEAR))
		{
			return 0;
		}
		return 1;
	}

	public int comparaDataUltimeiOperatiuni(Calendar o)
	{
		if(this.data_ultimei_operatiuni.get(Calendar.DAY_OF_MONTH)==o.get(Calendar.DAY_OF_MONTH) && this.data_ultimei_operatiuni.get(Calendar.MONTH)==o.get(Calendar.MONTH)
				&& this.data_ultimei_operatiuni.get(Calendar.YEAR)==o.get(Calendar.YEAR))
		{
			return 0;
		}
		return 1;
	}

	@Override
	public float calculeaza_dobanda() {
		Calendar data_curenta=Calendar.getInstance();
		long crt=data_curenta.getTimeInMillis();
		long ult=data_ultimei_operatiuni.getTimeInMillis();
		return (crt-ult)/86400000;
	}
	@Override
	public float actualizare_suma() {
		if(moneda.equals("RON"))
		{
			if(suma<500)
			{
				suma=(float) (suma+(0.3*calculeaza_dobanda()));
			}
			else
			{
				suma=(float) (suma+(0.8*calculeaza_dobanda()));
			}
		}
		else
		{
			if(moneda.equals("EUR"))
			{
				suma=(float) (suma+(0.1*calculeaza_dobanda()));
			}
		}
		data_ultimei_operatiuni=Calendar.getInstance();
		return suma;
	}
	@Override
	public void depunere(float suma) {
		float suma_actualizata;
		suma_actualizata=actualizare_suma();
		this.suma=suma_actualizata+suma;
	}
	@Override
	public void extragere(float suma) {
		float suma_actualizata;
		suma_actualizata=actualizare_suma();
		this.suma=suma_actualizata-suma;
	}

	public String toString()
	{
		return "Cont: "+numarCont+" "+suma+" "+moneda+" "+data_deschiderii.get(Calendar.DAY_OF_MONTH)+"."+(data_deschiderii.get(Calendar.MONTH)+1)+"."+data_deschiderii.get(Calendar.YEAR)+
				" "+data_ultimei_operatiuni.get(Calendar.DAY_OF_MONTH)+"."+(data_ultimei_operatiuni.get(Calendar.MONTH)+1)+"."+data_ultimei_operatiuni.get(Calendar.YEAR)+"\n";
	}
}

class Client{
	private String nume;
	private String adresa;
	private Set<ContBancar> conturi;

	public Client(String num,String adr)
	{
		nume=num;
		adresa=adr;
		conturi=new HashSet<ContBancar>();
	}

	public Set<ContBancar> getConturi()
	{
		return conturi;
	}

	public String getNume()
	{
		return nume;
	}

	public String getAdresa()
	{
		return adresa;
	}

	public void adaugareCont(ContBancar cont)
	{
		if(conturi.size()==5)
		{
			System.out.println("Clientul "+nume+" a atins numarul maxim de conturi!");
			return;
		}
		conturi.add(cont);
	}

	public String toString()
	{
		return "Client: "+nume+" "+adresa+"\n"+conturi.toString()+"\n";
	}
}

class Banca{
	private String denumire_banca;
	private List<Client> clienti;

	public Banca(String den)
	{
		denumire_banca=den;
		clienti=new ArrayList<Client>();
	}

	public String getDenumire_banca()
	{
		return denumire_banca;
	}

	public List<Client> getClienti()
	{
		return clienti;
	}

	public void adaugareClient(Client client) throws IOException
	{
		for(int i=0;i<clienti.size();i++)
		{
			if(clienti.get(i).getNume().equals(client.getNume()) && clienti.get(i).getAdresa().equals(client.getAdresa()))
			{				
				System.out.println("Clientul era deja inscris la aceasta banca!");
				return;				
			}
		}

		clienti.add(client);
		BufferedReader flux_intrare=new BufferedReader(new InputStreamReader(System.in));

		System.out.print("Dati numarul contului: ");
		String nr=flux_intrare.readLine();

		System.out.print("Dati suma: ");
		String summ;
		float sum;
		summ=flux_intrare.readLine();
		sum=Float.parseFloat(summ);

		System.out.print("Dati moneda: ");
		String mon=flux_intrare.readLine();

		int zi;
		int luna;
		int an;
		String zii;
		String lunaa;
		String ann;

		System.out.print("Dati data deschiderii:\n");
		Calendar c1 = Calendar.getInstance();
		System.out.print("Zi: ");
		zii=flux_intrare.readLine();
		zi=Integer.parseInt(zii);
		System.out.print("Luna: ");
		lunaa=flux_intrare.readLine();
		luna=Integer.parseInt(lunaa);
		System.out.print("An: ");
		ann=flux_intrare.readLine();
		an=Integer.parseInt(ann);
		c1.set(an, luna-1, zi);

		System.out.print("Dati data ultimei operatiuni:\n");
		Calendar c2 = Calendar.getInstance();
		System.out.print("Zi: ");
		zii=flux_intrare.readLine();
		zi=Integer.parseInt(zii);
		System.out.print("Luna: ");
		lunaa=flux_intrare.readLine();
		luna=Integer.parseInt(lunaa);
		System.out.print("An: ");
		ann=flux_intrare.readLine();
		an=Integer.parseInt(ann);
		c2.set(an, luna-1, zi);

		ContBancar cont=new ContBancar(nr, sum, mon, c1, c2);
		clienti.get(clienti.size()-1).adaugareCont(cont);		
	}

	public String toString()
	{
		return "Banca: "+denumire_banca+"\n"+clienti.toString()+"\n";
	}
}

public class ex1 {

	public static void main(String[] args) throws IOException {
		Vector<Banca> banci=new Vector<Banca>();

		int opt;
		String optt;

		do
		{
			System.out.println("\n1.Adaugare banca");
			System.out.println("2.Adaugare client");
			System.out.println("3.Adaugare cont");
			System.out.println("4.Afisare date introduse");
			System.out.println("5.Depunerea unei sume intr-un cont");
			System.out.println("6.Extragerea unei sume dintr-un cont");
			System.out.println("7.Transfer de bani intre doua conturi");
			System.out.println("0.IESIRE DIN PROGRAM");

			System.out.print("Optiunea este: ");
			BufferedReader flux_intrare=new BufferedReader(new InputStreamReader(System.in)); 
			optt=flux_intrare.readLine();
			opt=Integer.parseInt(optt);

			switch(opt)
			{
			case 1:
			{
				int ok=0;
				String denumire;
				System.out.print("Dati denumirea bancii: ");
				denumire=flux_intrare.readLine();
				for(int i=0;i<banci.size();i++)
				{
					if(banci.elementAt(i).getDenumire_banca().equals(denumire))
					{
						ok=1;
						System.out.println("Banca era deja adaugata!");
						break;
					}	
				}
				if(ok==0)
				{
					banci.add(new Banca(denumire));
				}
			}
			break;
			case 2:
			{
				int ok=0;
				int i;

				String nume;
				System.out.print("Dati numele clientului: ");
				nume=flux_intrare.readLine();
				String adresa;
				System.out.print("Dati adresa clientului: ");
				adresa=flux_intrare.readLine();
				String denumire;
				System.out.print("Dati denumirea bancii: ");
				denumire=flux_intrare.readLine();

				for(i=0;i<banci.size();i++)
				{
					if(banci.elementAt(i).getDenumire_banca().equals(denumire))
					{
						ok=1;
						break;
					}
				}
				if(ok==0)
				{
					System.out.println("Banca introdusa nu exista!");
				}
				else
				{
					banci.elementAt(i).adaugareClient(new Client(nume,adresa));
				}
			}
			break;
			case 3:
			{
				int ok=0;
				int i,j = 0;

				System.out.print("Dati numarul contului: ");
				String nr=flux_intrare.readLine();

				System.out.print("Dati suma: ");
				String summ;
				float sum;
				summ=flux_intrare.readLine();
				sum=Float.parseFloat(summ);

				System.out.print("Dati moneda: ");
				String mon=flux_intrare.readLine();

				int zi;
				int luna;
				int an;
				String zii;
				String lunaa;
				String ann;

				System.out.print("Dati data deschiderii:\n");
				Calendar c1 = Calendar.getInstance();
				System.out.print("Zi: ");
				zii=flux_intrare.readLine();
				zi=Integer.parseInt(zii);
				System.out.print("Luna: ");
				lunaa=flux_intrare.readLine();
				luna=Integer.parseInt(lunaa);
				System.out.print("An: ");
				ann=flux_intrare.readLine();
				an=Integer.parseInt(ann);
				c1.set(an, luna-1, zi);

				System.out.print("Dati data ultimei operatiuni:\n");
				Calendar c2 = Calendar.getInstance();
				System.out.print("Zi: ");
				zii=flux_intrare.readLine();
				zi=Integer.parseInt(zii);
				System.out.print("Luna: ");
				lunaa=flux_intrare.readLine();
				luna=Integer.parseInt(lunaa);
				System.out.print("An: ");
				ann=flux_intrare.readLine();
				an=Integer.parseInt(ann);
				c2.set(an, luna-1, zi);

				String nume;
				System.out.print("Dati numele clientului: ");
				nume=flux_intrare.readLine();
				String adresa;
				System.out.print("Dati adresa clientului: ");
				adresa=flux_intrare.readLine();
				String denumire;
				System.out.print("Dati denumirea bancii: ");
				denumire=flux_intrare.readLine();

				List<Client> clienti = null;

				for(i=0;i<banci.size() && ok==0;i++)
				{
					if(banci.elementAt(i).getDenumire_banca().equals(denumire))
					{
						clienti=banci.elementAt(i).getClienti();

						for(j=0;j<clienti.size();j++)
						{
							if(clienti.get(j).getNume().equals(nume) && clienti.get(j).getAdresa().equals(adresa))
							{				
								ok=1;
								break;			
							}
						}
					}
				}

				if(ok==0)
				{
					System.out.println("Datele bancii sau ale clientului sunt invalide!");
				}
				else
				{
					clienti.get(j).adaugareCont(new ContBancar(nr, sum, mon, c1, c2));
				}
			}
			break;
			case 4:
			{
				for(int i=0;i<banci.size();i++)
				{
					System.out.println(banci.elementAt(i).toString());	
				}
			}
			break;
			case 5:
			{
				int ok=0;
				int i,j = 0;

				String denumire;
				System.out.print("Dati denumirea bancii: ");
				denumire=flux_intrare.readLine();

				String nume;
				System.out.print("Dati numele clientului: ");
				nume=flux_intrare.readLine();
				String adresa;
				System.out.print("Dati adresa clientului: ");
				adresa=flux_intrare.readLine();

				System.out.print("Dati numarul contului: ");
				String nr=flux_intrare.readLine();

				System.out.print("Dati suma: ");
				String summ;
				float sum;
				summ=flux_intrare.readLine();
				sum=Float.parseFloat(summ);

				System.out.print("Dati moneda: ");
				String mon=flux_intrare.readLine();

				int zi;
				int luna;
				int an;
				String zii;
				String lunaa;
				String ann;

				System.out.print("Dati data deschiderii:\n");
				Calendar c1 = Calendar.getInstance();
				System.out.print("Zi: ");
				zii=flux_intrare.readLine();
				zi=Integer.parseInt(zii);
				System.out.print("Luna: ");
				lunaa=flux_intrare.readLine();
				luna=Integer.parseInt(lunaa);
				System.out.print("An: ");
				ann=flux_intrare.readLine();
				an=Integer.parseInt(ann);
				c1.set(an, luna-1, zi);

				System.out.print("Dati data ultimei operatiuni:\n");
				Calendar c2 = Calendar.getInstance();
				System.out.print("Zi: ");
				zii=flux_intrare.readLine();
				zi=Integer.parseInt(zii);
				System.out.print("Luna: ");
				lunaa=flux_intrare.readLine();
				luna=Integer.parseInt(lunaa);
				System.out.print("An: ");
				ann=flux_intrare.readLine();
				an=Integer.parseInt(ann);
				c2.set(an, luna-1, zi);

				for(i=0;i<banci.size() && ok==0;i++)
				{
					if(banci.elementAt(i).getDenumire_banca().equals(denumire))
					{
						List<Client> clienti=banci.elementAt(i).getClienti();

						for(j=0;j<clienti.size() && ok==0;j++)
						{
							if(clienti.get(j).getNume().equals(nume) && clienti.get(j).getAdresa().equals(adresa))
							{				
								Set<ContBancar> conturi=clienti.get(j).getConturi();

								Iterator<ContBancar> it=conturi.iterator();
								while(it.hasNext())
								{
									ContBancar cont=it.next();
									if(cont.getNumarCont().equals(nr) && cont.getSuma()==sum && cont.getMoneda().equals(mon) && 
											cont.comparaDataDeschiderii(c1)==0 && cont.comparaDataUltimeiOperatiuni(c2)==0)
									{
										String sumaa_depusa;
										float suma_depusa;
										System.out.print("Dati suma depusa: ");
										sumaa_depusa=flux_intrare.readLine();
										suma_depusa=Float.parseFloat(sumaa_depusa);
										cont.depunere(suma_depusa);

										ok=1;
										break;
									}
								}
							}
						}
					}
				}
				if(ok==0)
				{
					System.out.println("Datele bancii, ale clientului sau ale contului sunt invalide!");
				}
			}
			break;
			case 6:
			{
				int ok=0;
				int i,j = 0;

				String denumire;
				System.out.print("Dati denumirea bancii: ");
				denumire=flux_intrare.readLine();

				String nume;
				System.out.print("Dati numele clientului: ");
				nume=flux_intrare.readLine();
				String adresa;
				System.out.print("Dati adresa clientului: ");
				adresa=flux_intrare.readLine();

				System.out.print("Dati numarul contului: ");
				String nr=flux_intrare.readLine();

				System.out.print("Dati suma: ");
				String summ;
				float sum;
				summ=flux_intrare.readLine();
				sum=Float.parseFloat(summ);

				System.out.print("Dati moneda: ");
				String mon=flux_intrare.readLine();

				int zi;
				int luna;
				int an;
				String zii;
				String lunaa;
				String ann;

				System.out.print("Dati data deschiderii:\n");
				Calendar c1 = Calendar.getInstance();
				System.out.print("Zi: ");
				zii=flux_intrare.readLine();
				zi=Integer.parseInt(zii);
				System.out.print("Luna: ");
				lunaa=flux_intrare.readLine();
				luna=Integer.parseInt(lunaa);
				System.out.print("An: ");
				ann=flux_intrare.readLine();
				an=Integer.parseInt(ann);
				c1.set(an, luna-1, zi);

				System.out.print("Dati data ultimei operatiuni:\n");
				Calendar c2 = Calendar.getInstance();
				System.out.print("Zi: ");
				zii=flux_intrare.readLine();
				zi=Integer.parseInt(zii);
				System.out.print("Luna: ");
				lunaa=flux_intrare.readLine();
				luna=Integer.parseInt(lunaa);
				System.out.print("An: ");
				ann=flux_intrare.readLine();
				an=Integer.parseInt(ann);
				c2.set(an, luna-1, zi);

				for(i=0;i<banci.size() && ok==0;i++)
				{
					if(banci.elementAt(i).getDenumire_banca().equals(denumire))
					{
						List<Client> clienti=banci.elementAt(i).getClienti();

						for(j=0;j<clienti.size() && ok==0;j++)
						{
							if(clienti.get(j).getNume().equals(nume) && clienti.get(j).getAdresa().equals(adresa))
							{				
								Set<ContBancar> conturi=clienti.get(j).getConturi();

								Iterator<ContBancar> it=conturi.iterator();
								while(it.hasNext())
								{
									ContBancar cont=it.next();
									if(cont.getNumarCont().equals(nr) && cont.getSuma()==sum && cont.getMoneda().equals(mon) && 
											cont.comparaDataDeschiderii(c1)==0 && cont.comparaDataUltimeiOperatiuni(c2)==0)
									{
										String sumaa_extrasa;
										float suma_extrasa;
										System.out.print("Dati suma extrasa: ");
										sumaa_extrasa=flux_intrare.readLine();
										suma_extrasa=Float.parseFloat(sumaa_extrasa);
										cont.extragere(suma_extrasa);

										ok=1;
										break;
									}
								}
							}
						}
					}
				}
				if(ok==0)
				{
					System.out.println("Datele bancii, ale clientului sau ale contului sunt invalide!");
				}
			}
			break;
			case 7:
			{
				int ok=0;
				int i,j = 0;

				System.out.println("Date client expeditor:");
				String denumire;
				System.out.print("Dati denumirea bancii: ");
				denumire=flux_intrare.readLine();

				String nume;
				System.out.print("Dati numele clientului: ");
				nume=flux_intrare.readLine();
				String adresa;
				System.out.print("Dati adresa clientului: ");
				adresa=flux_intrare.readLine();

				System.out.print("Dati numarul contului: ");
				String nr=flux_intrare.readLine();

				System.out.print("Dati suma: ");
				String summ;
				float sum;
				summ=flux_intrare.readLine();
				sum=Float.parseFloat(summ);

				System.out.print("Dati moneda: ");
				String mon=flux_intrare.readLine();

				int zi;
				int luna;
				int an;
				String zii;
				String lunaa;
				String ann;

				System.out.print("Dati data deschiderii:\n");
				Calendar c1 = Calendar.getInstance();
				System.out.print("Zi: ");
				zii=flux_intrare.readLine();
				zi=Integer.parseInt(zii);
				System.out.print("Luna: ");
				lunaa=flux_intrare.readLine();
				luna=Integer.parseInt(lunaa);
				System.out.print("An: ");
				ann=flux_intrare.readLine();
				an=Integer.parseInt(ann);
				c1.set(an, luna-1, zi);

				System.out.print("Dati data ultimei operatiuni:\n");
				Calendar c2 = Calendar.getInstance();
				System.out.print("Zi: ");
				zii=flux_intrare.readLine();
				zi=Integer.parseInt(zii);
				System.out.print("Luna: ");
				lunaa=flux_intrare.readLine();
				luna=Integer.parseInt(lunaa);
				System.out.print("An: ");
				ann=flux_intrare.readLine();
				an=Integer.parseInt(ann);
				c2.set(an, luna-1, zi);

				List<Client> clienti = null;
				Set<ContBancar> conturi = null;
				ContBancar cont = null;

				for(i=0;i<banci.size() && ok==0;i++)
				{
					if(banci.elementAt(i).getDenumire_banca().equals(denumire))
					{
						clienti=banci.elementAt(i).getClienti();

						for(j=0;j<clienti.size() && ok==0;j++)
						{
							if(clienti.get(j).getNume().equals(nume) && clienti.get(j).getAdresa().equals(adresa))
							{				
								conturi=clienti.get(j).getConturi();

								Iterator<ContBancar> it=conturi.iterator();
								while(it.hasNext())
								{
									cont=it.next();
									if(cont.getNumarCont().equals(nr) && cont.getSuma()==sum && cont.getMoneda().equals(mon) && 
											cont.comparaDataDeschiderii(c1)==0 && cont.comparaDataUltimeiOperatiuni(c2)==0)
									{
										ok=1;
										break;
									}
								}
							}
						}
					}
				}
				if(ok==0)
				{
					System.out.println("Datele bancii, ale clientului sau ale contului expeditorului sunt invalide!");
				}

				int ok1=0;
				int i1,j1 = 0;

				System.out.println("Date client destinatar:");
				String denumire1;
				System.out.print("Dati denumirea bancii: ");
				denumire1=flux_intrare.readLine();

				String nume1;
				System.out.print("Dati numele clientului: ");
				nume1=flux_intrare.readLine();
				String adresa1;
				System.out.print("Dati adresa clientului: ");
				adresa1=flux_intrare.readLine();

				System.out.print("Dati numarul contului: ");
				String nr1=flux_intrare.readLine();

				System.out.print("Dati suma: ");
				String summ1;
				float sum1;
				summ1=flux_intrare.readLine();
				sum1=Float.parseFloat(summ1);

				System.out.print("Dati moneda: ");
				String mon1=flux_intrare.readLine();

				int zi1;
				int luna1;
				int an1;
				String zii1;
				String lunaa1;
				String ann1;

				System.out.print("Dati data deschiderii:\n");
				Calendar c11 = Calendar.getInstance();
				System.out.print("Zi: ");
				zii1=flux_intrare.readLine();
				zi1=Integer.parseInt(zii1);
				System.out.print("Luna: ");
				lunaa1=flux_intrare.readLine();
				luna1=Integer.parseInt(lunaa1);
				System.out.print("An: ");
				ann1=flux_intrare.readLine();
				an1=Integer.parseInt(ann1);
				c11.set(an1, luna1-1, zi1);

				System.out.print("Dati data ultimei operatiuni:\n");
				Calendar c21 = Calendar.getInstance();
				System.out.print("Zi: ");
				zii1=flux_intrare.readLine();
				zi1=Integer.parseInt(zii1);
				System.out.print("Luna: ");
				lunaa1=flux_intrare.readLine();
				luna1=Integer.parseInt(lunaa1);
				System.out.print("An: ");
				ann1=flux_intrare.readLine();
				an1=Integer.parseInt(ann1);
				c21.set(an1, luna1-1, zi1);

				List<Client> clienti1 = null;
				Set<ContBancar> conturi1 = null;
				ContBancar cont1 = null;

				for(i1=0;i1<banci.size() && ok1==0;i1++)
				{
					if(banci.elementAt(i1).getDenumire_banca().equals(denumire1))
					{
						clienti1=banci.elementAt(i1).getClienti();

						for(j1=0;j1<clienti1.size() && ok1==0;j1++)
						{
							if(clienti1.get(j1).getNume().equals(nume1) && clienti1.get(j1).getAdresa().equals(adresa1))
							{				
								conturi1=clienti1.get(j1).getConturi();

								Iterator<ContBancar> it=conturi1.iterator();
								while(it.hasNext())
								{
									cont1=it.next();
									if(cont1.getNumarCont().equals(nr1) && cont1.getSuma()==sum1 && cont1.getMoneda().equals(mon1) && 
											cont1.comparaDataDeschiderii(c11)==0 && cont1.comparaDataUltimeiOperatiuni(c21)==0)
									{
										ok1=1;
										break;
									}
								}
							}
						}
					}
				}
				if(ok1==0)
				{
					System.out.println("Datele bancii, ale clientului sau ale contului destinatarului sunt invalide!");
				}

				if(ok==1 && ok1==1)
				{
					if(!cont.getMoneda().equals(cont1.getMoneda()))
					{
						System.out.println("Cele doua conturi au valuta diferita!");
					}
					else
					{
						String sumaa_transfer;
						float suma_transfer;
						System.out.print("Dati suma de transfer: ");
						sumaa_transfer=flux_intrare.readLine();
						suma_transfer=Float.parseFloat(sumaa_transfer);
						if(suma_transfer>cont.getSuma())
						{
							System.out.println("Clientul expeditor nu detine suma necesara transferului!");
						}
						else
						{
							cont.extragere(suma_transfer);
							cont1.depunere(suma_transfer);
						}
					}
				}
			}
			break;
			case 0:
			{
				System.exit(0);
			}
			break;
			default:
			{
				System.out.println("OPTIUNE GRESITA!");
			}
			break;
			}
		}while(true);

	}

}

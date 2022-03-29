package lab11;

class Parcare{
	private int nrTotal;
	private int nrOcupate;
	
	public Parcare(int nrTotal,int nrOcupate)
	{
		this.nrTotal=nrTotal;
		this.nrOcupate=nrOcupate;
	}
	
	public synchronized void aIntrat(int nrIntrare)
	{
		while(nrOcupate==nrTotal)
		{
			try {
				wait();
			}catch(InterruptedException e) {}
		}
		
		nrOcupate++;
		System.out.println("+ A intrat o masina pe intrarea "+nrIntrare+". In parcare sunt "+nrOcupate+" masini");
		notify();
	}
	
	public synchronized void aIesit()
	{
		if(nrOcupate==0)
		{
			try {
				wait();
			}catch(InterruptedException e) {}
		}
		
		nrOcupate--;
		notify();
		System.out.println("- A iesit o masina. In parcare sunt "+nrOcupate+" masini");
	}
}

class Intrare extends Thread{
	private Parcare p;
	
	public Intrare(Parcare p)
	{
		this.p=p;
	}
	
	public void run() {
		while(true)
		{
			p.aIntrat(Integer.parseInt(getName()));
			
			try {
				sleep((int)(Math.random()*1000));
			}
			catch(InterruptedException e) {}
		}
	}
}

class Iesire extends Thread{
	private Parcare p;
	
	public Iesire(Parcare p)
	{
		this.p=p;
	}
	
	public void run() {
		while(true)
		{
			p.aIesit();
		}
	}
}

public class ex2 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Parcare p=new Parcare(10, 0);
		
		Intrare i1=new Intrare(p);
		i1.setName("1");
		
		Intrare i2=new Intrare(p);
		i2.setName("2");
		
		Intrare i3=new Intrare(p);
		i3.setName("3");
		
		Iesire ies=new Iesire(p);
		
		i1.start();
		i2.start();
		i3.start();
		ies.start();
	}

}

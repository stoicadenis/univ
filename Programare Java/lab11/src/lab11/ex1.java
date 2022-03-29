package lab11;

import java.util.Random;

class ContBancar{
	private int sumaCont=0;
	
	public synchronized void aExtras(int sumaExtrasa)
	{
		while(sumaExtrasa>sumaCont)
		{
			try {
				wait();
			}
			catch(InterruptedException e) {}
		}
		sumaCont=sumaCont-sumaExtrasa;
		notify();
		System.out.println("- A fost extrasa suma de "+sumaExtrasa+"RON si in cont au ramas "+sumaCont+"RON");
	}
	
	public synchronized void aDepus(int sumaDepusa)
	{
		sumaCont=sumaCont+sumaDepusa;
		System.out.println("+ A fost depusa suma de "+sumaDepusa+"RON, in cont sunt: "+sumaCont+" RON");
		notify();
	}
}

class Depunere extends Thread{
	private ContBancar cont;
	
	public Depunere(ContBancar cont)
	{
		this.cont=cont;
	}
	
	public void run() {
		while(true)
		{
			Random random=new Random();
			int sumaDepusa=random.nextInt((1000-1)+1)+1;
			
			cont.aDepus(sumaDepusa);
			
			try {
				sleep((int)(Math.random()*1000));
			}
			catch(InterruptedException e) {}
		}
	}
}

class Extragere extends Thread{
	private ContBancar cont;
	
	public Extragere(ContBancar cont) {
		this.cont=cont;
	}
	
	public void run() {
		while(true)
		{
			Random random=new Random();
			int sumaExtrasa=random.nextInt((1000-1)+1)+1;
			
			cont.aExtras(sumaExtrasa);
		}
	}
}

public class ex1 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		ContBancar cont=new ContBancar();
		Depunere dep=new Depunere(cont);
		Extragere ext=new Extragere(cont);
		
		dep.start();
		ext.start();
	}

}

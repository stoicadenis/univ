package lab2;

import java.util.Scanner;
import java.io.*;



class PRODUCTS {
	private String name_of_product;
	private double price_of_product, quantity_of_product;
	public PRODUCTS(String name_of_product, double price_of_product, double quantity_of_product) {
		this.name_of_product = name_of_product;
		this.price_of_product = price_of_product;
		this.quantity_of_product = quantity_of_product;
	}
	
	public void showProducts()
	{
		System.out.println(this.name_of_product + " " + this.price_of_product + " " + this.quantity_of_product);
	}
}



public class ex3 {
	public static void main(String args[]) throws FileNotFoundException {
		String name;
		int price, quantity;
		
		
		File input_file = new File("src/lab2/input.txt");
		Scanner scanner = new Scanner(input_file);
		int count = 4;
		
		PRODUCTS[] product_arr = new PRODUCTS[10];
	
		String [] put_tokens;
		
		int temp_count = 0; //reinitalize count pentru adaugarea lui obiecte in array
		while(scanner.hasNext()) {
			put_tokens = scanner.nextLine().split(";");
			product_arr[temp_count] = new PRODUCTS(put_tokens[0], Double.parseDouble(put_tokens[1]), Double.parseDouble(put_tokens[2]));
			temp_count++;
		}
		
			for(int i=0;i<product_arr.length;i++) {
				if(product_arr[i] != null) {
					product_arr[i].showProducts();
				}
			}
		}
	}
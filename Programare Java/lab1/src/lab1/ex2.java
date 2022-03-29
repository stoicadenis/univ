package lab1;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

public class ex2 {

	@SuppressWarnings("resource")
	public static void main(String[] args) throws IOException {
		BufferedReader input = new BufferedReader(new FileReader("src/lab1/in.txt"));
		BufferedWriter output = new BufferedWriter(new FileWriter("src/lab1/out.txt"));
		int[] nums = new int[6];
		int i;
		
		for(i = 0; i < 6; i++)
			nums[i] = Integer.parseInt(input.readLine());
		input.close();
		
		int sum = 0, val_min = 9999, val_max = -1;
		float ma = 0;
		for(i = 0; i < 6; i++)
		{
			sum += nums[i];
			if(nums[i] < val_min)
				val_min = nums[i];
			if(nums[i] > val_max)
				val_max = nums[i];
		}
		ma = (float)sum/6;
		
		System.out.println("Suma numerelor este " + sum);
		output.write(String.valueOf(sum) + "\n");
		
		System.out.println("Media aritmetica este " + ma);
		output.write(String.valueOf(ma) + "\n");
		
		System.out.println("Valoarea minima este " + val_min);
		output.write(String.valueOf(val_min) + "\n");
		
		System.out.println("Valoarea maxima este " + val_max);
		output.write(String.valueOf(val_max));
		
		output.close();
	}

}

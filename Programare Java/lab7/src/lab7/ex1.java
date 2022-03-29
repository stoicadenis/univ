package lab7;

import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JTextField;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

@SuppressWarnings("serial")
class ExceptieNull extends Exception
{
	public void afisare()
	{
		JOptionPane.showMessageDialog(null, "Operand NULL");
	}
}

@SuppressWarnings("serial")
class ExceptieZero extends Exception
{
	public void afisare()
	{
		JOptionPane.showMessageDialog(null, "Operand2 e zero!");
	}
}

public class ex1 {

	private JFrame frame;
	private JTextField txtOperand1;
	private JTextField txtOperand2;
	private JTextField txtRezultat;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					ex1 window = new ex1();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public ex1() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.setBounds(100, 100, 608, 443);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setTitle("Exercitiul 1");
		frame.getContentPane().setLayout(null);
		
		JLabel lblOperand1 = new JLabel("Operand 1");
		lblOperand1.setBounds(190, 37, 69, 20);
		frame.getContentPane().add(lblOperand1);
		
		JLabel lblOperand2 = new JLabel("Operand 2");
		lblOperand2.setBounds(190, 68, 69, 20);
		frame.getContentPane().add(lblOperand2);
		
		txtOperand1 = new JTextField();
		txtOperand1.setBounds(259, 37, 134, 20);
		frame.getContentPane().add(txtOperand1);
		txtOperand1.setColumns(10);
		
		txtOperand2 = new JTextField();
		txtOperand2.setColumns(10);
		txtOperand2.setBounds(259, 68, 134, 20);
		frame.getContentPane().add(txtOperand2);
		
		JButton btnAdunare = new JButton("Adunare");
		btnAdunare.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int op1, op2, rezultat;
				try {
					if(txtOperand1.getText().equals("") || txtOperand2.getText().equals(""))
						throw new ExceptieNull();
					op1 = Integer.parseInt(txtOperand1.getText());
					op2 = Integer.parseInt(txtOperand2.getText());
					rezultat = op1 + op2;
					txtRezultat.setText(String.valueOf(rezultat));
				}
				catch(ExceptieNull e1)
				{
					e1.afisare();
				}
				catch(NumberFormatException e2)
				{
					JOptionPane.showMessageDialog(null, "Introduceti numere in casetele de OPERANZI!");
				}
				
			}
		});
		btnAdunare.setBounds(139, 119, 120, 39);
		frame.getContentPane().add(btnAdunare);
		
		JButton btnScadere = new JButton("Scadere");
		btnScadere.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int op1, op2, rezultat;
				try {
					if(txtOperand1.getText().equals("") || txtOperand2.getText().equals(""))
						throw new ExceptieNull();
					op1 = Integer.parseInt(txtOperand1.getText());
					op2 = Integer.parseInt(txtOperand2.getText());
					rezultat = op1 - op2;
					txtRezultat.setText(String.valueOf(rezultat));
				}
				catch(ExceptieNull e1)
				{
					e1.afisare();
				}
				catch(NumberFormatException e2)
				{
					JOptionPane.showMessageDialog(null, "Introduceti numere in casetele de OPERANZI!");
				}
			}
		});
		btnScadere.setBounds(303, 119, 126, 39);
		frame.getContentPane().add(btnScadere);
		
		JButton btnInmultire = new JButton("Inmultire");
		btnInmultire.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int op1, op2, rezultat;
				try {
					if(txtOperand1.getText().equals("") || txtOperand2.getText().equals(""))
						throw new ExceptieNull();
					op1 = Integer.parseInt(txtOperand1.getText());
					op2 = Integer.parseInt(txtOperand2.getText());
					rezultat = op1 * op2;
					txtRezultat.setText(String.valueOf(rezultat));
				}
				catch(ExceptieNull e1)
				{
					e1.afisare();
				}
				catch(NumberFormatException e2)
				{
					JOptionPane.showMessageDialog(null, "Introduceti numere in casetele de OPERANZI!");
				}
			}
		});
		btnInmultire.setBounds(139, 170, 120, 39);
		frame.getContentPane().add(btnInmultire);
		
		JButton btnImpartire = new JButton("Impartire");
		btnImpartire.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int op1, op2, rezultat;
				try {
					if(txtOperand1.getText().equals("") || txtOperand2.getText().equals(""))
						throw new ExceptieNull();
					op1 = Integer.parseInt(txtOperand1.getText());
					op2 = Integer.parseInt(txtOperand2.getText());
					
					if(op2 == 0)
						throw new ExceptieZero();
					rezultat = op1 / op2;
					txtRezultat.setText(String.valueOf(rezultat));
				}
				catch(ExceptieNull e1)
				{
					e1.afisare();
				}
				catch(NumberFormatException e2)
				{
					JOptionPane.showMessageDialog(null, "Introduceti numere in casetele de OPERANZI!");
				}
				catch(ExceptieZero e3)
				{
					e3.afisare();
				}
			}
		});
		btnImpartire.setBounds(303, 169, 126, 40);
		frame.getContentPane().add(btnImpartire);
		
		txtRezultat = new JTextField();
		txtRezultat.setBounds(139, 239, 290, 27);
		frame.getContentPane().add(txtRezultat);
		txtRezultat.setColumns(10);
		
		JButton btnClear = new JButton("Clear");
		btnClear.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				txtOperand1.setText("");
				txtOperand2.setText("");
				txtRezultat.setText("");
			}
		});
		btnClear.setBounds(139, 277, 290, 32);
		frame.getContentPane().add(btnClear);
	}
}

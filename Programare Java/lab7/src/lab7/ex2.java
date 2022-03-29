package lab7;

import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JTextField;
import javax.swing.JList;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

import javax.swing.DefaultListModel;
import javax.swing.JButton;
import java.awt.Color;
import java.awt.BorderLayout;
import javax.swing.SwingConstants;

public class ex2 {

	private JFrame frame;
	private JTextField txtFormatii;
	private JList listFormatii;
	private String[] items = new String[255];
	private int contor = 0;
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					ex2 window = new ex2();
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
	public ex2() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.setBounds(100, 100, 648, 440);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(new BorderLayout(0, 0));
		
		txtFormatii = new JTextField();
		frame.getContentPane().add(txtFormatii, BorderLayout.NORTH);
		txtFormatii.setColumns(10);
		
		DefaultListModel listModel = new DefaultListModel();
		listFormatii = new JList(listModel);
		
		listFormatii.setModel(listModel);
		listFormatii.setBackground(Color.WHITE);
		listFormatii.setVisibleRowCount(10);
		
		
		txtFormatii.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				listModel.addElement(txtFormatii.getText());
				listFormatii.setModel(listModel);
			}
		});
		
		frame.getContentPane().add(listFormatii, BorderLayout.CENTER);
		JButton btnStergere = new JButton("Sterge");
		btnStergere.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int[] new_array = listFormatii.getSelectedIndices();
				int new_length = new_array.length;
				for(int i=new_length-1;i>=0;--i) {
					listModel.removeElementAt(new_array[i]);
				}
			}
		});
		frame.getContentPane().add(btnStergere, BorderLayout.SOUTH);
	}
}
